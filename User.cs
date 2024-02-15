using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace ØkonomiSystemet
{
    public class User
    { 
      
        
        public bool IsOnline { get; set; }
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

      
        public List<Savings> UserSavingProjects { get; set; }

        public User()
        {
            UserSavingProjects = new List<Savings>();
        }

        public void Online()
        {
            if (IsOnline)
            {
                Console.WriteLine($"Status: {(IsOnline ? "online" : "offline")}.");
                Console.WriteLine($"Username: {Username}");
            }
        }

        public void UserMenu(Account account)
        {
            bool program = true;
            while (program)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        if (account.Login())
                        {
                            account.user.IsOnline = true;
                            program = false;
                        }

                        break;

                    case "2":
                        account.RegisterUser();
                        program  = true;
                        break;

                    case "3":
                        program = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            
        }
    }
}
