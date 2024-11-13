using System.Diagnostics.CodeAnalysis;

namespace MiniBank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} {Iban} {Currency}  {Balance} {CustomerId} {Name}";
        }

        public class AccountEquilityComparer : IEqualityComparer<Account>
        {
            public bool Equals(Account x, Account y) => x.Id == y.Id &&
                    x.Iban.Trim().ToLower() == y.Iban.Trim().ToLower() &&
                    x.Currency.Trim().ToLower() == y.Currency.Trim().ToLower() &&
                    x.Balance == y.Balance &&
                    x.CustomerId == y.CustomerId &&
                    x.Name.Trim().ToLower() == y.Name.Trim().ToLower();


            public int GetHashCode([DisallowNull] Account obj) => obj.Name.Length;

        }
    }
}
