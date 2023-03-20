namespace HBO.Dto;

public class CustomerToList
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Membership { get; set; } = string.Empty;
    public decimal SignUpFee { get; set; }
    public decimal Discount { get; set; }
}
