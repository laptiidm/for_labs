using Laptii.Blockchain.Lab;

var ldy_Blockchain = new Ldy_Blockchain();

Console.WriteLine("=== Blockchain Mining Demo ===");
Console.WriteLine("Genesis block initialized.");

ldy_Blockchain.ldy_AddBlock("First Transaction");
ldy_Blockchain.ldy_AddBlock("Second Transaction");

Console.WriteLine();
Console.WriteLine("=== Full Blockchain ===");

for (var ldy_Index = 0; ldy_Index < ldy_Blockchain.Chain.Count; ldy_Index++)
{
    var ldy_Block = ldy_Blockchain.Chain[ldy_Index];
    var ldy_IsHashLinked = ldy_Index == 0
        ? ldy_Block.PreviousHash == "Laptii"
        : ldy_Block.PreviousHash == ldy_Blockchain.Chain[ldy_Index - 1].Hash;

    Console.WriteLine($"Block #{ldy_Block.Index}");
    Console.WriteLine($"Timestamp   : {ldy_Block.Timestamp}");
    Console.WriteLine($"Data        : {ldy_Block.Data}");
    Console.WriteLine($"Nonce       : {ldy_Block.Nonce}");
    Console.WriteLine($"Hash        : {ldy_Block.Hash}");
    Console.WriteLine($"PreviousHash: {ldy_Block.PreviousHash}");
    Console.WriteLine($"Hash Link OK: {ldy_IsHashLinked}");
    Console.WriteLine($"Ends with 10: {ldy_Block.Hash.EndsWith("10", StringComparison.Ordinal)}");
    Console.WriteLine(new string('-', 72));
}
