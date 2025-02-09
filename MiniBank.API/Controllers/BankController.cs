using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MiniBank.Models;
using MiniBank.Repository;

namespace MiniBank.API.Controllers
{
    [Route("api/bank")]
    [ApiController]
    public class BankController : ControllerBase
    {
        //private readonly CustomerCsvRepository _repo;
        private readonly SqlClientCustomerRepository _repo;


        public BankController()
        {
           // _repo = new CustomerCsvRepository("C:\\Users\\user\\Source\\Repos\\MiniBank-Practical-JSON-unitTests--homework18\\MiniBank.Repository\\Data\\Customers.csv");
            _repo = new SqlClientCustomerRepository();
        }


        //[HttpGet("customers")]
        //public async Task<List<Customer>> GetCustomers()
        //{
        //    var result=await _repo.GetCustomers();
        //    return result;

        //}


    }
}
