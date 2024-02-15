using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ØkonomiSystemet
{
    public class Menu
    {
        
        public void MenuCase(Valuta valuta, Savings savings,User user,Account account)
        {
            valuta.VisValuta();
            var currency = valuta.getselectedValuta();
            Console.Clear();
            while (user.IsOnline)
            { 
                Console.WriteLine($"Currency: {currency}");
                user.Online();
                Console.WriteLine();
                Console.WriteLine("1.saving projects");
                Console.WriteLine("2.log off");
                int ProjectInput = Convert.ToInt32(Console.ReadLine());
                switch (ProjectInput)
                {
                    case 1:
                        Console.Clear();
                        savings.SavingsMenu(user);
                        break;

                    case 2:
                        user.IsOnline = false;
                        System.Console.WriteLine("You have logged out");
                        user.UserMenu(account);
                  
                   
         
                        break;


                    default:
                        System.Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
