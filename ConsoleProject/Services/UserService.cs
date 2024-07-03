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
                DB.Categories[DB.Categories.Length - 1]=category;
            }
        }
    }
}
