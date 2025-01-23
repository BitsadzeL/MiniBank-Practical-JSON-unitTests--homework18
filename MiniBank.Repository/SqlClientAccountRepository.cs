using MiniBank.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MiniBank.Repository
{
    public class SqlClientAccountRepository
    {
        private const string _connectionString = "Server=DESKTOP-VU8IK37\\SQLEXPRESS;Database=MiniBank;Trusted_Connection=true;TrustServerCertificate=true";

        public async Task<List<Account>> GetAccounts()
        {
            List<Account> accounts = new List<Account>();


            using (SqlConnection connection = new (_connectionString)) 
            {
                using (SqlCommand command = new ("spGetAllAccounts",connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Account account = new Account();
                        account.Id = reader.GetInt32(0);
                        account.Iban= reader.GetString(1);
                        account.Currency= reader.GetString(2);
                        account.Balance=reader.GetDecimal(3);
                        account.Name= reader.GetString(4);
                        account.CustomerId = reader.GetInt32(5);

                        accounts.Add(account);

                    }
                }
            }

            return accounts;
        }

        public async Task<List<Account>> GetUserAccount(int Id) 
        {
            List<Account> userAccounts = new();
            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new("spGetUserAccount", connection))
                {
                    command.CommandType=CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("customerId", Id);

                    await connection.OpenAsync();
                    SqlDataReader reader=await command.ExecuteReaderAsync();

                    while(await reader.ReadAsync()) 
                    {

                        Account account = new Account();
                        account.Id = reader.GetInt32(0);
                        account.Iban = reader.GetString(1);
                        account.Currency = reader.GetString(2);
                        account.Balance = reader.GetDecimal(3);
                        account.Name = reader.GetString(4);
                        account.CustomerId = reader.GetInt32(5);

                        userAccounts.Add(account);

                    }

                }
            }

            return userAccounts;
            
        }

        public async Task CreateAccount(Account acc)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new("spAddNewAccount", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("iban", acc.Iban);
                    command.Parameters.AddWithValue("currency", acc.Currency);
                    command.Parameters.AddWithValue("balance", acc.Balance);
                    command.Parameters.AddWithValue("name", acc.Name);
                    command.Parameters.AddWithValue("customerId", acc.CustomerId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();



                }
            }
        }

        public async Task DeleteAccount(int Id)
        {
            using(SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new("spDeleteAccount", connection))
                {
                    command.CommandType=CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("accountId", Id);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAccount(Account acc)
        {
            using(SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new("spUpdateAccount", connection))
                {
                    command.CommandType =CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("accountId",acc.Id);
                    command.Parameters.AddWithValue("iban", acc.Iban);
                    command.Parameters.AddWithValue("currency", acc.Currency);
                    command.Parameters.AddWithValue("balance", acc.Balance);
                    command.Parameters.AddWithValue("name",acc.Name);
                    command.Parameters.AddWithValue("customerId",acc.CustomerId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
