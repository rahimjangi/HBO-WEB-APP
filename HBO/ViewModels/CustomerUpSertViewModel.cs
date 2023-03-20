using HBO.Dto;
using HBO.Models;

namespace HBO.ViewModels;

public class CustomerUpSertViewModel
{
    public CustomerToAdd CustomerToAdd { get; set; } = new CustomerToAdd();
    public Genre Genre { get; set; } = new Genre();
    public List<Gender> Genders { get; set; } = new List<Gender>();
    public List<MembershipType> MembershipTypes { get; set; } = new List<MembershipType>();
}
