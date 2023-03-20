namespace HBO.Dto;

public class CustomerToAdd
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;


    public string Email { get; set; } = string.Empty;


    public int GenderId { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsSubscribetToNewsLetter { get; set; }
    public int MembershipTypeId { get; set; }

}
