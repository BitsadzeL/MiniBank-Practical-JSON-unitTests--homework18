using MiniBank.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace MiniBank.Repository
{
    public class AccountJsonRepository
    {
        private readonly string _filePath;
        private List<Account> _accounts;

        public AccountJsonRepository(string filePath)
        {
            _filePath = filePath;
            _accounts = LoadData();
        }

        public List<Account> GetAccounts()
        {           
            return _accounts;
        }

        public List<Account> GetAccountsOfCustomer(int customerId)
        {
            return _accounts.Where(x => x.CustomerId == customerId).ToList();
        }

        public Account GetAccount(int id)
        {
            var acc= _accounts.FirstOrDefault(a => a.Id == id);
            return acc;
        }

        public void Create(Account account)
        {
            account.Id = _accounts.Any() ? _accounts.Max(account => account.Id) + 1 : 1;
            _accounts.Add(account);
            SaveData();
        }

        public void Update(Account account)
        {

            var index = _accounts.FindIndex(c => c.Id == account.Id);
            if (index >= 0)
            {
                _accounts[index] = account;
                SaveData();
            }

        }

        public void Delete(int id)
        {
            _accounts.Remove(_accounts.FirstOrDefault(a => a.Id == id));
            SaveData();
        }

        private void SaveData()
        {
            string jsonString = JsonConvert.SerializeObject(_accounts, Formatting.Indented);
            File.WriteAllText(_filePath, jsonString);
        }

        private List<Account> LoadData()
        {           
            string data=File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Account>>(data);
        }
    }
}
