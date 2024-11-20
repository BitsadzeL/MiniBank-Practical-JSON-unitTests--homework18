using MiniBank.Models;
using MiniBank.Repository;
using static MiniBank.Models.Account;

namespace MiniBank.Tests
{
    public class Account_Json_Repository_Should
    {
        private readonly string _testFilePath = @"../../../Data/Accounts.json";



        [Fact]
        public void Get_All_Accounts()
        {
            var accountRepository = new AccountJsonRepository(_testFilePath);
            var expected = 7;    


            var actual = accountRepository.GetAccounts();

            
            Assert.Equal(expected, actual.Count);
        }


        [Fact]
        public void Get_Single_Acccount()
        {
            var accountRepository = new AccountJsonRepository(_testFilePath);
            var expected = new Account()
            {
                Id = 6,
                Iban = "GE90SB5621487456385156",
                Currency = "GEL",
                Balance = 1245,
                CustomerId = 2,
                Name = "Test"
            };

            var actual = accountRepository.GetAccount(6);

            Assert.Equal(expected, actual, new AccountEquilityComparer());

        }

        [Fact]
        public void Get_Account_Of_User()
        {

            var accountRepository = new AccountJsonRepository(_testFilePath);
            var expected = 4;
            var actual = accountRepository.GetAccountsOfCustomer(2).Count;
            Assert.Equal(expected, actual);

            
        }



        [Fact]
        public void Add_Account()
        {
            var accountRepository = new AccountJsonRepository(_testFilePath);
            var expected = 7;

            var accToAdd = new Account()
            {
                Iban = "GE90SB5621487456385156",
                Currency = "GEL",
                Balance = 500,
                CustomerId = 3,
                Name = "Test"
            };

            accountRepository.Create(accToAdd);
            var actual=accountRepository.GetAccounts().Count;
            Assert.Equal(expected, actual);    

        }


        [Fact]
        public void Delete_Account()
        {
            var accountRepository = new AccountJsonRepository(_testFilePath); ;
            var accountIdToDelete = 7;
            var expected = 6;

            //Act
            accountRepository.Delete(accountIdToDelete);

            //Assert
            var actual = accountRepository.GetAccounts().Count;
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Update_Account_Info()
        {
            var accountRepository = new AccountJsonRepository(_testFilePath);

            var accToUpdate = new Account()
            {
                Id=6,
                Iban = "GE90SB5621487456385156",
                Currency = "GEL",
                Balance = 1245,
                CustomerId = 2,
                Name = "Test"
            };

            accountRepository.Update(accToUpdate);

            var actual = accountRepository.GetAccount(6);

            Assert.Equal(accToUpdate, actual);

        }

    }
}
