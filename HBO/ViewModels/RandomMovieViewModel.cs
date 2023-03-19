using HBO.Models;

namespace HBO.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie? Movie { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
