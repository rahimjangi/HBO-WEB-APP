using HBO.Models;
using HBO.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HBO.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name = "Shrek"
            };
            List<Customer> customers = new List<Customer>() {
                new Customer() {Id = 1, Name="name 1"},
                new Customer() {Id = 2, Name="name 2"},
                new Customer() {Id = 3, Name="name 3"},
                new Customer() {Id = 4, Name="name 4"},
            };

            var model = new RandomMovieViewModel() { Movie = movie, Customers = customers };
            return View(model);
        }
    }
}
