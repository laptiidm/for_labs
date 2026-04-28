using System.Globalization;
using System.Threading;
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
var ldy_HasUrlsArgument = args.Any(
    ldy_Arg => ldy_Arg.StartsWith("--urls", StringComparison.OrdinalIgnoreCase));
var ldy_UrlsFromConfiguration = ldy_Builder.Configuration["urls"];

if (string.IsNullOrWhiteSpace(ldy_UrlsFromConfiguration) && !ldy_HasUrlsArgument)
{
    var ldy_Port = 4567;
    if (args.Length > 0
        && int.TryParse(
            args[0],
            NumberStyles.None,
            CultureInfo.InvariantCulture,
            out var ldy_ParsedPort)
        && ldy_ParsedPort is > 0 and <= 65535)
    {
        ldy_Port = ldy_ParsedPort;
    }

    ldy_Builder.WebHost.UseUrls($"http://localhost:{ldy_Port}");
}

var ldy_App = ldy_Builder.Build();

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

        ldy_SyncRoot.ldy_Gate.Wait();

        try
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
        finally
        {
            ldy_SyncRoot.ldy_Gate.Release();
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
        ldy_SyncRoot.ldy_Gate.Wait();

        try
        {
            ldy_Blockchain.ldy_AddBlock();
            var ldy_NewlyMinedBlock = ldy_Blockchain.Chain[^1];

            return Results.Ok(ldy_NewlyMinedBlock);
        }
        finally
        {
            ldy_SyncRoot.ldy_Gate.Release();
        }
    });

ldy_App.MapPost(
    "/ldy/nodes/register",
    (Ldy_Blockchain ldy_Blockchain, Ldy_BlockchainSyncRoot ldy_SyncRoot, Ldy_RegisterNodesRequest ldy_Request) =>
    {
        if (ldy_Request.Nodes is null || ldy_Request.Nodes.Count == 0)
        {
            return Results.BadRequest(
                new
                {
                    message = "Provide a non-empty list of node URLs under 'nodes'."
                });
        }

        ldy_SyncRoot.ldy_Gate.Wait();

        try
        {
            foreach (var ldy_NodeUrl in ldy_Request.Nodes)
            {
                ldy_Blockchain.ldy_RegisterNode(ldy_NodeUrl);
            }
        }
        finally
        {
            ldy_SyncRoot.ldy_Gate.Release();
        }

        return Results.Ok(
            new
            {
                message = "Nodes registered.",
                totalNodes = ldy_Blockchain.ldy_nodes.Count
            });
    });

ldy_App.MapGet(
    "/ldy/nodes/resolve",
    async (Ldy_Blockchain ldy_Blockchain, Ldy_BlockchainSyncRoot ldy_SyncRoot) =>
    {
        await ldy_SyncRoot.ldy_Gate.WaitAsync();

        bool ldy_Replaced;

        try
        {
            ldy_Replaced = await ldy_Blockchain.ldy_ResolveConflicts();
        }
        finally
        {
            ldy_SyncRoot.ldy_Gate.Release();
        }

        return Results.Ok(
            new
            {
                replaced = ldy_Replaced,
                message = ldy_Replaced
                    ? "Chain was replaced with a longer valid chain from a peer."
                    : "Chain was kept; no longer valid peer chain found."
            });
    });

ldy_App.Run();

public class Ldy_CreateTransactionRequest
{
    public string Sender { get; set; } = string.Empty;

    public string Recipient { get; set; } = string.Empty;

    public decimal Amount { get; set; }
}

public class Ldy_RegisterNodesRequest
{
    public List<string> Nodes { get; set; } = new();
}

public class Ldy_BlockchainSyncRoot
{
    public SemaphoreSlim ldy_Gate { get; } = new(1, 1);
}
