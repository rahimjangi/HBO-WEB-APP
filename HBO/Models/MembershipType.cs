namespace HBO.Models;

public class MembershipType
{
    public int MembershipId { get; set; }
    public string Membership { get; set; } = string.Empty;
    public decimal SignUpFee { get; set; }
    public decimal Discount { get; set; }
}
