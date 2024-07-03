namespace ConsoleProject.Models
{
    public class Category:BaseEntity
    {
        public string Name;
        public Category(string name)
        {
            Name = name;
        }
    }
}
