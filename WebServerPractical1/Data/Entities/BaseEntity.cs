namespace WebServerPractical1.Data.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
