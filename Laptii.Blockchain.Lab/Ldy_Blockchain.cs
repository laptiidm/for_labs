using System.Security.Cryptography;
using System.Text;

namespace Laptii.Blockchain.Lab;

public class Ldy_Blockchain
{
    public List<Ldy_Block> Chain { get; } = new();
    private const string ldy_MiningSuffix = "10";

    public Ldy_Blockchain()
    {
        var ldy_GenesisBlock = new Ldy_Block
        {
            Index = 0,
            Timestamp = DateTime.UtcNow.ToString("O"),
            Data = "Genesis Block",
            PreviousHash = "Laptii",
            Nonce = 17101988
        };

        ldy_GenesisBlock.Hash = ldy_CalculateHash(ldy_GenesisBlock);
        Chain.Add(ldy_GenesisBlock);
    }

    public string ldy_CalculateHash(Ldy_Block block)
    {
        var ldy_RawData = $"{block.Index}{block.Timestamp}{block.Data}{block.PreviousHash}{block.Nonce}";
        var ldy_Bytes = Encoding.UTF8.GetBytes(ldy_RawData);
        var ldy_HashBytes = SHA256.HashData(ldy_Bytes);
        var ldy_HexBuilder = new StringBuilder();

        foreach (var ldy_Byte in ldy_HashBytes)
        {
            ldy_HexBuilder.Append(ldy_Byte.ToString("x2"));
        }

        return ldy_HexBuilder.ToString();
    }

    public void ldy_AddBlock(string data)
    {
        var ldy_LastBlock = Chain[^1];
        var ldy_NewBlock = new Ldy_Block
        {
            Index = ldy_LastBlock.Index + 1,
            Timestamp = DateTime.UtcNow.ToString("O"),
            Data = data,
            PreviousHash = ldy_LastBlock.Hash,
            Nonce = 0
        };

        Console.WriteLine();
        Console.WriteLine($"Mining block #{ldy_NewBlock.Index} with data: \"{ldy_NewBlock.Data}\"");

        do
        {
            ldy_NewBlock.Hash = ldy_CalculateHash(ldy_NewBlock);

            if (!ldy_NewBlock.Hash.EndsWith(ldy_MiningSuffix, StringComparison.Ordinal))
            {
                ldy_NewBlock.Nonce++;
            }
        } while (!ldy_NewBlock.Hash.EndsWith(ldy_MiningSuffix, StringComparison.Ordinal));

        Console.WriteLine(
            $"Mining block... Found hash: {ldy_NewBlock.Hash} with nonce: {ldy_NewBlock.Nonce}");

        Chain.Add(ldy_NewBlock);
    }
}
