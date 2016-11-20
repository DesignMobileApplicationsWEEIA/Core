namespace Domain.Model.Database
{
    public class Logo : IEntity
    {
        public long Id { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public long BuildingId { get; set; }

        public Building Building { get; set; }
    }
}