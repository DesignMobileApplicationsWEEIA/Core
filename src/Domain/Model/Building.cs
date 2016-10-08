namespace Core.Domain.Model
{
    public class Building
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public Faculty[] Faculty { get; set; }
        
        public Building()
        {
        }
    }
}
