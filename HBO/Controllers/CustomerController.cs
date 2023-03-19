using HBO.Models;
using Microsoft.AspNetCore.Mvc;

namespace HBO.Controllers;

public class CustomerController : Controller
{
    List<Customer> customers = new List<Customer>() {
                new Customer() {Id = 1, Name="Rahim"},
                new Customer() {Id = 2, Name="Hoshang"},
                new Customer() {Id = 3, Name="Mahsa"},
                new Customer() {Id = 4, Name="Elham"},
            };
    public IActionResult Index()
    {

        return View(customers);
    }

    public IActionResult Details(int id)
    {
        var customer = customers[id - 1];
        return View(customer);
    }
}
