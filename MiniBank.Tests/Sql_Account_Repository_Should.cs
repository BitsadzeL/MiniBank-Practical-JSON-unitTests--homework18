using MiniBank.Models;
using MiniBank.Repository;

namespace MiniBank.Tests
{
    public class Sql_Account_Repository_Should
    {
        
        SqlClientAccountRepository _sqlClientAccountRepository;
        public Sql_Account_Repository_Should()
        {
            _sqlClientAccountRepository = new();
        }



        [Fact]
        public async Task Add_Account()
        {
            Account acc= new()
            {
                Iban = "GE74SB7041487456391153",
                Currency = "USD",
                Balance = 10000,
                Name = "",
                CustomerId=2
            };

            await _sqlClientAccountRepository.CreateAccount(acc);
        }



        [Fact]
        public async Task Get_All_Accounts()
        {
            var result = await _sqlClientAccountRepository.GetAccounts();
        }

        [Fact]
        public async Task Get_All_Accounts_Of_User()
        {
            var result = await _sqlClientAccountRepository.GetUserAccount(2);
        }



        [Fact]
        public async Task Delete_Account()
        {
            await _sqlClientAccountRepository.DeleteAccount(1);
        }


        [Fact]
        public async Task Update_Account()
        {
            Account acc = new()
            {
                Id = 3,
                Iban = "GE74SB7041487456391153",
                Currency = "USD",
                Balance = 1250.25m,
                Name = "my car",
                CustomerId = 2
            };

            await _sqlClientAccountRepository.UpdateAccount(acc);
        }

    }
}