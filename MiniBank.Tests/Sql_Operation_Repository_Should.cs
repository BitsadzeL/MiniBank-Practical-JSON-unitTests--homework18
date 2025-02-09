using MiniBank.Repository;

namespace MiniBank.Tests
{
    public class Sql_Operation_Repository_Should
    {
        SqlClientOperationRepository _sqlClientOperationRepository;
        public Sql_Operation_Repository_Should()
        {
            _sqlClientOperationRepository = new();
        }

        [Fact]
        public async Task Make_Credit_Operation()
        {
            decimal amount = 50;
            int accountId = 3;

            await _sqlClientOperationRepository.Insert(accountId, amount);
          

        }

        [Fact]
        public async Task Make_Debit_Operation()
        {
            decimal amount = 300;
            int accountId = 3;
            await _sqlClientOperationRepository.Withdraw(accountId, amount);
        }

        [Fact]
        public async Task Make_Transfer_Operation()
        {
            int srcAccId = 2;
            int destAccId = 3;
            decimal amount = 1000;

            await _sqlClientOperationRepository.Transfer(srcAccId, destAccId, amount);

        }
    }
}
