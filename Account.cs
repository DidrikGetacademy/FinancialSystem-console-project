using Microsoft.EntityFrameworkCore;

namespace ØkonomiSystemet
{
    public class Account
    {
        private readonly DbConnection dbContext;
        public User user;

        public Account()
        {
            dbContext = new DbConnection();
            dbContext.Database.EnsureCreated();
            user = new User();
        }

        public bool RegisterUser()
        {
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();


            if (dbContext.Users.Any(u => u.Username == username))
            {
                Console.WriteLine("User with this username already exists. Please choose a different username.");
                return false;
            }
 
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            User newUser = new User()
            {
                Username = username,
                Password = password,

            };

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
            Console.WriteLine("User registered successfully");
            return true;
        }

        public bool Login()
        {
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            User existingUser = dbContext.Users.Include(u => u.UserSavingProjects).FirstOrDefault(u => u.Username == username && u.Password == password);
            if (existingUser != null)
            {
                existingUser.IsOnline = true;
                dbContext.SaveChanges();

                user.Username = existingUser.Username;
                user.IsOnline = existingUser.IsOnline;
                user.id = existingUser.id;
                user.UserSavingProjects = existingUser.UserSavingProjects;
         
                Console.Clear();
                Console.WriteLine($"Login successful! {existingUser.Username}");
                return true;
            }
            else
            {
                Console.WriteLine("Login Failed. Incorrect username or password");
                return false;
            }


        }
    }
}