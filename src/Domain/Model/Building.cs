namespace Core.Domain.Model
{
    public sealed class Building : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public FacultyWreaper[] Faculty { get; set; }
        
        public Building()
        {
        }
    }
}
