using Microsoft.EntityFrameworkCore;
using System;
using static ØkonomiSystemet.DbConnection;

namespace ØkonomiSystemet
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Valuta valuta = new();
                Account account = new();
                User user = account.user;
                Menu menu = new();
                Savings savings = new(); 

                user.UserMenu(account);
                menu.MenuCase(valuta, savings, user,account);
        }
    }
}