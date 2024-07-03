namespace ConsoleProject.Models
{
    public abstract class BaseEntity
    {
        private static int _id;
        public int Id { get;}
        public BaseEntity()
        {
            Id = ++_id;
        }
    }
}
