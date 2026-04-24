using Laptii.Blockchain.Lab;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;

var ldy_Builder = WebApplication.CreateBuilder(args);

ldy_Builder.Services.Configure<JsonOptions>(
    ldy_Options =>
    {
        ldy_Options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        ldy_Options.SerializerOptions.WriteIndented = true;
    });

var ldy_BlockchainSingleton = new Ldy_Blockchain();
var ldy_BlockchainSyncRoot = new Ldy_BlockchainSyncRoot();

ldy_Builder.Services.AddSingleton(ldy_BlockchainSingleton);
ldy_Builder.Services.AddSingleton(ldy_BlockchainSyncRoot);

var ldy_App = ldy_Builder.Build();

ldy_App.Urls.Add("http://localhost:4567");

ldy_App.MapGet(
    "/ldy/chain",
    (Ldy_Blockchain ldy_Blockchain) =>
    {
        return Results.Ok(ldy_Blockchain.Chain);
    });

ldy_App.MapGet(
    "/ldy/mempool",
    (Ldy_Blockchain ldy_Blockchain) =>
    {
        return Results.Ok(ldy_Blockchain.ldy_mempool);
    });

ldy_App.MapGet(
    "/ldy/balance/{address}",
    (Ldy_Blockchain ldy_Blockchain, string address) =>
    {
        var ldy_Balance = ldy_Blockchain.ldy_GetBalance(address);
        return Results.Ok(
            new
            {
                address,
                balance = ldy_Balance
            });
    });

ldy_App.MapPost(
    "/ldy/transactions/new",
    (Ldy_Blockchain ldy_Blockchain, Ldy_BlockchainSyncRoot ldy_SyncRoot, Ldy_CreateTransactionRequest ldy_Request) =>
    {
        if (string.IsNullOrWhiteSpace(ldy_Request.Sender)
            || string.IsNullOrWhiteSpace(ldy_Request.Recipient)
            || ldy_Request.Amount <= 0)
        {
            return Results.BadRequest(
                new
                {
                    message = "Invalid transaction data. Sender, recipient, and positive amount are required."
                });
        }

        lock (ldy_SyncRoot)
        {
            try
            {
                ldy_Blockchain.ldy_CreateTransaction(
                    ldy_Request.Sender.Trim(),
                    ldy_Request.Recipient.Trim(),
                    ldy_Request.Amount);
            }
            catch (InvalidOperationException ldy_Exception)
            {
                return Results.BadRequest(
                    new
                    {
                        message = ldy_Exception.Message
                    });
            }
        }

        return Results.Ok(
            new
            {
                message = "Transaction added to mempool.",
                mempoolCount = ldy_Blockchain.ldy_mempool.Count
            });
    });

ldy_App.MapGet(
    "/ldy/mine",
    (Ldy_Blockchain ldy_Blockchain, Ldy_BlockchainSyncRoot ldy_SyncRoot) =>
    {
        lock (ldy_SyncRoot)
        {
            ldy_Blockchain.ldy_AddBlock();
            var ldy_NewlyMinedBlock = ldy_Blockchain.Chain[^1];

            return Results.Ok(ldy_NewlyMinedBlock);
        }
    });

ldy_App.Run();

public class Ldy_CreateTransactionRequest
{
    public string Sender { get; set; } = string.Empty;

    public string Recipient { get; set; } = string.Empty;

    public decimal Amount { get; set; }
}

public class Ldy_BlockchainSyncRoot
{
}
