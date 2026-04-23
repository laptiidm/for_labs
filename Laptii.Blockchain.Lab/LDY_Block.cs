namespace Laptii.Blockchain.Lab;

public class LDY_Block
{
    public int Index { get; set; }

    public string Timestamp { get; set; } = string.Empty;

    public string Data { get; set; } = string.Empty;

    public string PreviousHash { get; set; } = string.Empty;

    public long Nonce { get; set; }

    public string Hash { get; set; } = string.Empty;
}

public class Ldy_Block : LDY_Block
{
}
