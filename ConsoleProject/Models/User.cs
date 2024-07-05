namespace ConsoleProject.Models
{
    public class User:BaseEntity
    {
        private string email {  get; set; }
        public string FullName;
        public string Email;
        public string Password;
        public User(string fullname,string email,string password)
        {
            FullName = fullname;
            Email = email;
            Password = password;
        }

    
    }
}
