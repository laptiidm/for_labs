using System.Globalization;

namespace Laptii.Blockchain.Lab;

public class Ldy_Transaction
{
    public string Sender { get; set; } = string.Empty;

    public string Recipient { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public override string ToString()
    {
        return $"{Sender}|{Recipient}|{Amount.ToString(CultureInfo.InvariantCulture)}";
    }
}
