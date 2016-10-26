namespace Core.Domain.Model
{
    public class Faculty : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public long LogoId { get; set; }

        public Logo Logo { get; set; }
    }
}
