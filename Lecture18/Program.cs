using MiniBank.Models;
using MiniBank.Repository;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lecture18
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Hobbies { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Person> people = new List<Person>()
            //{
            //    new Person()
            //    {
            //        Id = 1,
            //        Name = "Alice",
            //        Age = 30,
            //        Hobbies = new List<string>()
            //        {
            //            "Reading Boooks",
            //            "Playing football"
            //        }
            //    },
            //    new Person()
            //    {
            //        Id = 2,
            //        Name = "Bob",
            //        Age = 16,
            //        Hobbies = new List<string>()
            //        {
            //            "Gaming",
            //            "Playing guitar"
            //        }
            //    }
            //};

            ////სერიალიზაცია Json ში
            //string jsonString = JsonSerializer.Serialize(people, new JsonSerializerOptions()
            //{
            //    WriteIndented = true
            //});

            //Newtonsoft
            //string jsonString = JsonConvert.SerializeObject(people, Formatting.Indented);
            //File.WriteAllText(@"../../../PeopleAsJson.json", jsonString);


            //დესერიალიზაცია
            //string text = File.ReadAllText("../../../PeopleAsJson.json");
            //var peopleList = JsonSerializer.Deserialize<List<Person>>(text);

            //Newtonsoft
            //var peopleList = JsonConvert.DeserializeObject<List<Person>>(text);




            //Console.WriteLine("Test");
            //AccountJsonRepository accrepo = new AccountJsonRepository(@"C:\Users\user\Desktop\minibankPractical\BCTSO-20-NC-2\MiniBank.Tests\Data\Accounts.json");
            //var a = accrepo.GetAccounts();
            //foreach (var account in a) 
            //{
            //    Console.WriteLine($"{account.Id} {account.Currency} {account.Balance} {account.CustomerId}");
            //}



            //Account account = new Account()
            //{
            //    Iban = "RandomIban",
            //    Currency = "GEL",
            //    Balance = 324,
            //    CustomerId = 2,
            //    Name="For Travelling"
            //};

            //accrepo.Create(account);

            //var a = accrepo.GetAccountsOfCustomer(2);
            //Console.WriteLine(a.Count);
            //foreach (var account in a)
            //{
            //    Console.WriteLine($"{account.Id} {account.Currency} {account.Balance} {account.CustomerId}");
            //}

            //accrepo.Delete(7);


            //Account accountToUpdate = new Account()
            //{
            //    Id=2,
            //    Balance = 1240,
            //};

            //accrepo.Update(accountToUpdate);



        }
    }
}
