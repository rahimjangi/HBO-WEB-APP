using HBO.Data;
using HBO.Models;
using Microsoft.AspNetCore.Mvc;

namespace HBO.Controllers;

public class CustomerController : Controller
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContextDP _dapper;
    public CustomerController(IConfiguration config)
    {
        _config = config;
        _dapper = new ApplicationDbContextDP(_config);
    }

    public IActionResult Index()
    {
        var customers = _dapper.LoadData<Customer>("select * from tci.customer");

        return View(customers);
    }

    public IActionResult Details(int id)
    {
        var customer = _dapper.LoadDataSingle<Customer>("select * from tci.customer where CustomerId=" + id.ToString());
        return View(customer);
    }
}
