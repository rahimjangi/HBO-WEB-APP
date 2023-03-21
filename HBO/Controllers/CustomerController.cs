using HBO.Data;
using HBO.Dto;
using HBO.Models;
using HBO.ViewModels;
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
        string sql = @"
                    SELECT 
                            [customer].[CustomerId],
                            [customer].[FirstName],
                            [customer].[LastName],
                            [customer].[IsSubscribetToNewsLetter],
                            [membershipType].[Membership],
                            [membershipType].[SignUpFee],
                            [membershipType].[Discount],
                            [customer].[BirthDate],
                            [customer].[Email],
                            [gender].[GenderType] as Gender
                     FROM TCI.customer as customer
                            inner join tci.Gender as gender
                                on customer.GenderId=gender.GenderId
                            inner join tci.MembershipType as membershipType
                                on customer.MembershipTypeId= membershipType.MembershipId
            ";
        var customers = _dapper.LoadData<CustomerToList>(sql);

        return View(customers);
    }

    public IActionResult Details(int id)
    {
        var customer = _dapper.LoadDataSingle<Customer>("select * from tci.customer where CustomerId=" + id.ToString());
        return View(customer);
    }


    [HttpGet("[action]")]
    public IActionResult UpSert(int id = 0)
    {
        var customer = new CustomerUpSertViewModel();
        var genderList = _dapper.LoadData<Gender>(@"select 
                                                        [GenderId],
                                                        [GenderType]
                                                     from tci.Gender");
        customer.Genders.AddRange(genderList);
        var membershipTypes = _dapper.LoadData<MembershipType>(@" select [MembershipId],
                                                                        [Membership],
                                                                        [SignUpFee],
                                                                        [Discount]
                                                                  from tci.MembershipType");
        customer.MembershipTypes.AddRange(membershipTypes);
        if (id > 0)
        {
            string sql = @"select * from tci.customer where CustomerId= " + id.ToString();
            customer.CustomerToAdd = _dapper.LoadDataSingle<CustomerToAdd>(sql);
        }

        return View(customer);
    }

    [HttpPost("[action]")]
    public IActionResult UpSertPost(CustomerUpSertViewModel customer)
    {

        if (customer.CustomerToAdd.CustomerId == 0)
        {
            //insert
            string sqlInsert = @"insert into TCI.customer(
                                    [FirstName],
                                    [LastName],
                                    [IsSubscribetToNewsLetter],
                                    [MembershipTypeId],
                                    [BirthDate],
                                    [Email],
                                    [GenderId]
                                ) values (" +
                                   "'" + customer.CustomerToAdd.FirstName.ToString() +
                                    "','" + customer.CustomerToAdd.LastName.ToString() +
                                    "' ,'" + customer.CustomerToAdd.IsSubscribetToNewsLetter.ToString() +
                                    "' ," + customer.CustomerToAdd.MembershipTypeId +
                                    ",'" + customer.CustomerToAdd.BirthDate.ToString() +
                                    "','" + customer.CustomerToAdd.Email.ToString() +
                                    "'," + customer.CustomerToAdd.GenderId + ")";
            Console.WriteLine(sqlInsert);

            _dapper.ExecuteSql(sqlInsert);


        }
        else
        {

            //update
            string sqlUpdate = @"";
            _dapper.ExecuteSql(sqlUpdate);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        string sql = @"delete from tci.customer where customerId=" + id.ToString();
        _dapper.ExecuteSql(sql);
        return RedirectToAction("Index");
    }
}
