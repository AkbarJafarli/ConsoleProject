namespace ConsoleProject.Models
{
    public class Medicine:BaseEntity
    {
        public string Name;
        public int Price;
        public int CategoryId;
        public int UserId;
        public DateTime CreatedDate;
        public Medicine(string name,int price,int categoryid,int userid)
        {
            Name = name;
            Price = price;
            CategoryId = categoryid;
            UserId = userid;
            CreatedDate = DateTime.Now;
        }


        public override string ToString()
        {
            return $"Is: {Id} Name: {Name} Price: {Price} CreatedDate: {CreatedDate.ToShortDateString()}";
        }
    }
}
