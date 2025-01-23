using MiniBank.Models;
using MiniBank.Repository;

namespace MiniBank.Tests
{
    public class Sql_Client_Repository_Should
    {
        SqlClientCustomerRepository _sqlClientCustomerRepository;
        public Sql_Client_Repository_Should()
        {
            _sqlClientCustomerRepository = new();
        }

        [Fact]
        public async Task Get_All_Customers()
        {
            var result = await _sqlClientCustomerRepository.GetCustomers();
        }


        [Fact]
        public async Task Get_Customer()
        {
            int customerId = 1;
            var result = await _sqlClientCustomerRepository.GetCustomer(customerId);
        }


        [Fact]
        public async Task Add_Customer()
        {
            Customer customer = new()
            {
                Name = "Luka Bitsadze",
                IdentityNumber = "56007853217",
                PhoneNumber = "568000000",
                Email = "luka@gmail.com",
                Type = CustomerType.Phyisical
            };

            await _sqlClientCustomerRepository.Create(customer);
        }


        [Fact]
        public async Task Update_Customer()
        {
            Customer customer = new()
            {
                Id = 1,
                Name = "Jimsher Gurgenidze",
                IdentityNumber = "56007853214",
                PhoneNumber = "551447788",
                Email = "Jemal.Gurgenidze@gmail.com",
                Type = CustomerType.Phyisical
            };

            await _sqlClientCustomerRepository.Update(customer);
        }


        [Fact]
        public async Task Delete_Customer()
        {
            var customerToDelete = 2;
            await _sqlClientCustomerRepository.Delete(customerToDelete);
        }
    }
}