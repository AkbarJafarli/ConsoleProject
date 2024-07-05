using ConsoleProject.Exceptions;
using ConsoleProject.Models;

namespace ConsoleProject.Services
{
    public class UserService
    {
        public User Login(string email, string password)
        {
            foreach (var user in DB.Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            throw new NotFoundException("User not found");
        }

        public void AddUser(User user)
        {
            Array.Resize(ref DB.Users, DB.Users.Length + 1);
            DB.Users[DB.Users.Length - 1] = user;
        }
        public void CreateCategory(Category category)
        {
            {
                Array.Resize(ref DB.Categories, DB.Categories.Length + 1);
                DB.Categories[DB.Categories.Length - 1] = category;
            }
        }

        public void RemoveUser(string email)
        {
            for (int i = 0; i < DB.Users.Length; i++)
            {
                var users = DB.Users[i];
                if (users.Email == email)
                {
                    for (int j = i; j <DB.Users.Length-1; j++)
                    {
                        DB.Users[j] = DB.Users[j + 1];
                    }
                    Array.Resize(ref DB.Users,DB.Users.Length-1);
                    Console.WriteLine("Users removed :)");
                    return;
                }
            }
            throw new NotFoundException("User not found");
        }
    }
}
