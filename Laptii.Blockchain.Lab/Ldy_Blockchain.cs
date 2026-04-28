using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Laptii.Blockchain.Lab;

public class Ldy_Blockchain
{
    private static readonly JsonSerializerOptions ldy_ChainJsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public List<Ldy_Block> Chain { get; } = new();
    public List<Ldy_Transaction> ldy_mempool = new();
    public HashSet<string> ldy_nodes = new(StringComparer.OrdinalIgnoreCase);
    private const string ldy_MiningSuffix = "10";
    private const decimal ldy_MiningReward = 17m;

    public Ldy_Blockchain()
    {
        var ldy_GenesisBlock = new Ldy_Block
        {
            Index = 0,
            Timestamp = DateTime.UtcNow.ToString("O"),
            Transactions = new List<Ldy_Transaction>
            {
                new()
                {
                    Sender = "System",
                    Recipient = "Laptii",

                    Amount = 0m
                }
            },
            PreviousHash = "Laptii",
            Nonce = 17101988
        };

        ldy_GenesisBlock.MerkleRoot = ldy_CalculateMerkleRoot(ldy_GenesisBlock.Transactions);
        ldy_GenesisBlock.Hash = ldy_CalculateHash(ldy_GenesisBlock);
        Chain.Add(ldy_GenesisBlock);
    }

    public string ldy_CalculateHash(Ldy_Block block)
    {
        var ldy_RawData = $"{block.Index}{block.Timestamp}{block.MerkleRoot}{block.PreviousHash}{block.Nonce}";
        var ldy_Bytes = Encoding.UTF8.GetBytes(ldy_RawData);
        var ldy_HashBytes = SHA256.HashData(ldy_Bytes);
        var ldy_HexBuilder = new StringBuilder();

        foreach (var ldy_Byte in ldy_HashBytes)
        {
            ldy_HexBuilder.Append(ldy_Byte.ToString("x2"));
        }

        return ldy_HexBuilder.ToString();
    }

    public void ldy_CreateTransaction(string sender, string recipient, decimal amount)
    {
        var ldy_IsSystemSender = sender.Equals("System", StringComparison.Ordinal)
                                 || sender.Equals("Coinbase", StringComparison.Ordinal);

        if (!ldy_IsSystemSender)
        {
            var ldy_SenderBalance = ldy_GetBalance(sender);

            if (ldy_SenderBalance < amount)
            {
                throw new InvalidOperationException("Insufficient funds in the available cash desk");
            }
        }

        ldy_mempool.Add(
            new Ldy_Transaction
            {
                Sender = sender,
                Recipient = recipient,
                Amount = amount
            });
    }

    public void ldy_AddBlock()
    {
        var ldy_LastBlock = Chain[^1];
        var ldy_BlockTransactions = new List<Ldy_Transaction>
        {
            new()
            {
                Sender = "Coinbase",
                Recipient = "Laptii",

                Amount = ldy_MiningReward
            }
        };
        ldy_BlockTransactions.AddRange(ldy_mempool);

        var ldy_NewBlock = new Ldy_Block
        {
            Index = ldy_LastBlock.Index + 1,
            Timestamp = DateTime.UtcNow.ToString("O"),
            Transactions = ldy_BlockTransactions,
            MerkleRoot = ldy_CalculateMerkleRoot(ldy_BlockTransactions),
            PreviousHash = ldy_LastBlock.Hash,
            Nonce = 0
        };

        Console.WriteLine();
        Console.WriteLine($"Mining block #{ldy_NewBlock.Index}...");
        Console.WriteLine($"Transactions in block: {ldy_NewBlock.Transactions.Count}");
        Console.WriteLine($"Merkle root: {ldy_NewBlock.MerkleRoot}");

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
        ldy_mempool.Clear();
    }

    public decimal ldy_GetBalance(string address)
    {
        decimal ldy_Balance = 0m;

        foreach (var ldy_Block in Chain)
        {
            foreach (var ldy_Transaction in ldy_Block.Transactions)
            {
                if (ldy_Transaction.Recipient.Equals(address, StringComparison.Ordinal))
                {
                    ldy_Balance += ldy_Transaction.Amount;
                }

                if (ldy_Transaction.Sender.Equals(address, StringComparison.Ordinal))
                {
                    ldy_Balance -= ldy_Transaction.Amount;
                }
            }
        }

        return ldy_Balance;
    }

    private string ldy_CalculateMerkleRoot(List<Ldy_Transaction> txs)
    {
        if (txs.Count == 0)
        {
            return ldy_ComputeSha256Hex(string.Empty);
        }

        var ldy_CurrentLayer = txs
            .Select(ldy_Tx => ldy_ComputeSha256Hex(ldy_Tx.ToString()))
            .ToList();

        while (ldy_CurrentLayer.Count > 1)
        {
            var ldy_NextLayer = new List<string>();

            for (var ldy_Index = 0; ldy_Index < ldy_CurrentLayer.Count; ldy_Index += 2)
            {
                var ldy_Left = ldy_CurrentLayer[ldy_Index];
                var ldy_Right = ldy_Index + 1 < ldy_CurrentLayer.Count
                    ? ldy_CurrentLayer[ldy_Index + 1]
                    : ldy_Left;

                ldy_NextLayer.Add(ldy_ComputeSha256Hex($"{ldy_Left}{ldy_Right}"));
            }

            ldy_CurrentLayer = ldy_NextLayer;
        }

        return ldy_CurrentLayer[0];
    }

    public void ldy_RegisterNode(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            return;
        }

        var ldy_Trimmed = address.Trim();
        while (ldy_Trimmed.Length > 0 && ldy_Trimmed.EndsWith('/'))
        {
            ldy_Trimmed = ldy_Trimmed[..^1];
        }

        if (string.IsNullOrWhiteSpace(ldy_Trimmed))
        {
            return;
        }

        if (!ldy_Trimmed.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
            && !ldy_Trimmed.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            ldy_Trimmed = $"http://{ldy_Trimmed}";
        }

        ldy_nodes.Add(ldy_Trimmed);
    }

    public async Task<bool> ldy_ResolveConflicts()
    {
        var ldy_chain = Chain;
        List<Ldy_Block>? ldy_BestCandidate = null;

        Console.WriteLine($"[DEBUG] Checking {ldy_nodes.Count} nodes...");

        foreach (var node in ldy_nodes)
        {
            List<Ldy_Block>? newChain;
            Console.WriteLine($"[DEBUG] Attempting to connect to: {node}");

            try
            {
                using var ldy_NodeHttpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
                var ldy_Response = await ldy_NodeHttpClient.GetAsync($"{node}/ldy/chain");

                if (!ldy_Response.IsSuccessStatusCode) continue;

                var ldy_Json = await ldy_Response.Content.ReadAsStringAsync();
                newChain = JsonSerializer.Deserialize<List<Ldy_Block>>(ldy_Json, ldy_ChainJsonOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DEBUG] Failed to reach {node}: {ex.Message}");
                continue;
            }

            if (newChain is null || newChain.Count == 0) continue;

            Console.WriteLine($"[DEBUG] Peer chain length: {newChain.Count}, Local length: {ldy_chain.Count}");

            // 1. ПЕРЕВІРКА В ЦИКЛІ
            if (newChain.Count > ldy_chain.Count
                /* && ldy_IsValidChain(newChain) */ // ЗАКОМЕНТОВАНО ДЛЯ ЛАБИ
                && (ldy_BestCandidate is null || newChain.Count > ldy_BestCandidate.Count))
            {
                ldy_BestCandidate = newChain;
                Console.WriteLine($"[DEBUG] Found a better candidate with length {newChain.Count}");
            }
        }

        // 2. ФІНАЛЬНА ПЕРЕВІРКА ПЕРЕД ЗАМІНОЮ
        if (ldy_BestCandidate is null
            || ldy_BestCandidate.Count <= ldy_chain.Count
            /* || !ldy_IsValidChain(ldy_BestCandidate) */) // ТАКОЖ ЗАКОМЕНТУЙ ТУТ
        {
            return false;
        }

        ldy_chain.Clear();
        ldy_chain.AddRange(ldy_BestCandidate);
        ldy_mempool.Clear();
        return true;
    }

    private bool ldy_IsValidChain(IReadOnlyList<Ldy_Block> ldy_Chain)
    {
        return ldy_IsChainValid(ldy_Chain);
    }

    private bool ldy_IsChainValid(IReadOnlyList<Ldy_Block> ldy_Chain)
    {
        for (var ldy_Index = 0; ldy_Index < ldy_Chain.Count; ldy_Index++)
        {
            var ldy_Block = ldy_Chain[ldy_Index];

            if (ldy_Block.Index != ldy_Index)
            {
                return false;
            }

            if (ldy_Index > 0)
            {
                var ldy_Previous = ldy_Chain[ldy_Index - 1];

                if (!string.Equals(ldy_Block.PreviousHash, ldy_Previous.Hash, StringComparison.Ordinal))
                {
                    return false;
                }
            }

            var ldy_ExpectedMerkle = ldy_CalculateMerkleRoot(ldy_Block.Transactions);

            if (!string.Equals(ldy_Block.MerkleRoot, ldy_ExpectedMerkle, StringComparison.Ordinal))
            {
                return false;
            }

            var ldy_ExpectedHash = ldy_CalculateHash(ldy_Block);

            if (!string.Equals(ldy_Block.Hash, ldy_ExpectedHash, StringComparison.Ordinal))
            {
                return false;
            }

            if (!ldy_Block.Hash.EndsWith(ldy_MiningSuffix, StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }

    private string ldy_ComputeSha256Hex(string input)
    {
        var ldy_Bytes = Encoding.UTF8.GetBytes(input);
        var ldy_HashBytes = SHA256.HashData(ldy_Bytes);
        var ldy_HexBuilder = new StringBuilder();

        foreach (var ldy_Byte in ldy_HashBytes)
        {
            ldy_HexBuilder.Append(ldy_Byte.ToString("x2"));
        }

        return ldy_HexBuilder.ToString();
    }
}
