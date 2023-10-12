using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Sorting
    {
        static void Main()
        {
            var phoneBook = new List<Contact>()
            {
                new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
                new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
            };

            phoneBook = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName).ToList();

            while (true)
            {
                var input = Console.ReadKey().KeyChar;
                var parsed = int.TryParse(input.ToString(), out int page);

                if (!parsed || page < 1 || page > 3)
                {
                    Console.Clear();
                    Console.WriteLine("\nТакой страницы не существует");
                }  
                else
                {
                    Console.Clear();
                    var pageContent = phoneBook.Skip((page - 1) * 2).Take(2);
                    Console.WriteLine();
                    foreach (var contact in pageContent)
                        Console.WriteLine(contact.Name + " " + contact.LastName + ": " + contact.PhoneNumber);
                    Console.WriteLine();
                }
            }
        }
    }
    public class Contact
    {
        public Contact(string name, string lastName, long phoneNumber, String email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string Name { get; }
        public string LastName { get; }
        public long PhoneNumber { get; }
        public string Email { get; }
    }
}
