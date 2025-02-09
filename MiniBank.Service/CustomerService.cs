using MiniBank.Models;
using MiniBank.Repository;
using MiniBank.Repository.Interfaces;
using MiniBank.Service.Interfaces;
using System.Data;

namespace MiniBank.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository= customerRepository;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            string commandText = "spGetSingleCustomer";
            var parameters = new Dictionary<string, object>()
                {
                    {"@customerid",id }
                };

            var result = await _customerRepository.Get(commandText, parameters, CommandType.StoredProcedure);
            return result;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            string commandText = "spGetAllCustomers";
            var result = await _customerRepository.GetAll(commandText, null, CommandType.StoredProcedure);

            return result.ToList();
        }
        public async Task Delete(int id)
        {
            string storedProcedure = "spDeleteCustomer";
            var parameters = new Dictionary<string, object>
            {
                { "@customerId", id }
            };

            await _customerRepository.Execute(storedProcedure, parameters);
        }
        public Task Create(Customer customer)
        {
            throw new NotImplementedException();
        }





        public Task Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
