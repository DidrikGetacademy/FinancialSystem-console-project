using Microsoft.EntityFrameworkCore;

namespace ØkonomiSystemet
{
    public class DbConnection : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Savings> Savings {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FinancialSystemDb;Integrated Security=True;TrustServerCertificate=True;");
        }

        public void WriteSavings(string title, string desc, User user)
        {
            using var dbContext = new DbConnection();

            var existingUser = dbContext.Users.FirstOrDefault(u => u.id == user.id);
            if (existingUser != null)
            {
                Savings savingsInstance = new()
                {
                    Title = title,
                    Description = desc,
                    UserId = user.id,
                    User = existingUser 
                };

                dbContext.Savings.Add(savingsInstance); 
                dbContext.SaveChanges(); 
            }
            else
            {
                Console.WriteLine($"User with ID {user.id} does not exist.");
            }
        }


        public void removeSavings(Savings databaseproject)
        {
            Savings.Remove(databaseproject);
        }




    }
}
