using MiniBank.Models;

namespace MiniBank.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);

        Task Create(Customer customer);

        Task Delete(int id);
        Task Update(Customer customer);

    }
}
