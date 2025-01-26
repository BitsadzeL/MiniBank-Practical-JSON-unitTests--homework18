

using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using MiniBank.Models;
using System.Data;

namespace MiniBank.Repository
{
    public class SqlClientOperationRepository
    {
        private const string _connectionString = "Server=DESKTOP-VU8IK37\\SQLEXPRESS;Database=MiniBank;Trusted_Connection=true;TrustServerCertificate=true";

        SqlClientAccountRepository sqlClientAccountRepository= new SqlClientAccountRepository();

        public async Task Insert(int accountId, decimal amount)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new("spInsertOperation", connection))
                {

                    Account account = await sqlClientAccountRepository.GetAccount(accountId);

                    account.Balance += amount;
                    await sqlClientAccountRepository.UpdateAccount(account);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("operationType", OperationType.Credit);
                    command.Parameters.AddWithValue("amount", amount);
                    command.Parameters.AddWithValue("accountId", accountId);
                    command.Parameters.AddWithValue("happenedAt", DateTime.Now);
                    command.Parameters.AddWithValue("currency", account.Currency);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Withdraw(int accountId, decimal amount)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new("spInsertOperation", connection))
                {

                    Account currentAcc = await sqlClientAccountRepository.GetAccount(accountId);
                    currentAcc.Balance -= amount;
                    await sqlClientAccountRepository.UpdateAccount(currentAcc);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("operationType", OperationType.Debit);
                    command.Parameters.AddWithValue("amount", amount);
                    command.Parameters.AddWithValue("accountId", accountId);
                    command.Parameters.AddWithValue("happenedAt", DateTime.Now);
                    command.Parameters.AddWithValue("currency", currentAcc.Currency);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();


                }
            }
        }

        public async Task Transfer(int sourceAccountId, int destinationAccountId, decimal amount)
        {
            
                    Account sourceAccount = await sqlClientAccountRepository.GetAccount(sourceAccountId);
                    Account destinationAccount = await sqlClientAccountRepository.GetAccount(destinationAccountId);

                    sourceAccount.Balance -= amount;
                    destinationAccount.Balance += amount;

                    await sqlClientAccountRepository.UpdateAccount(sourceAccount);
                    await sqlClientAccountRepository.UpdateAccount(destinationAccount);


                    await Create(new Operation()
                    {
                        OperationType = OperationType.Debit,
                        Currency = sourceAccount.Currency,
                        Amount = amount,
                        HappendAt = DateTime.Now,
                        AccountId = sourceAccount.Id
                    });



                    await Create(new Operation()
                    {
                        OperationType = OperationType.Credit,
                        Currency = destinationAccount.Currency,
                        Amount = amount,
                        HappendAt = DateTime.Now,
                        AccountId = destinationAccount.Id
                    });



          






        }



        public async Task Create(Operation operation)
        {
            string commandText = "spInsertOperation";

            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("operationType", operation.OperationType);
                    command.Parameters.AddWithValue("currency", operation.Currency);
                    command.Parameters.AddWithValue("amount", operation.Amount);
                    command.Parameters.AddWithValue("accountId", operation.AccountId);
                    command.Parameters.AddWithValue("happenedAt", operation.HappendAt);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }

        }


    }
}
