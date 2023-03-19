using HBO.Data;
using HBO.Models;
using HBO.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HBO.Controllers;

public class MovieController : Controller
{
    private readonly IConfiguration _config;

    public MovieController(IConfiguration config)
    {
        _config = config;
        _dapper = new ApplicationDbContextDP(_config);
    }

    private readonly ApplicationDbContextDP _dapper;
    public IActionResult Random()
    {

        var movie = _dapper.LoadDataSingle<Movie>("select * from tci.movie where MovieId=1");
        List<Customer> customers = _dapper.LoadData<Customer>("select * from tci.customer").ToList();


        var model = new RandomMovieViewModel() { Movie = movie, Customers = customers };
        return View(model);
    }
}
