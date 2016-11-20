using System;

namespace Domain.Model
{
    public sealed class Place : IEntity
    {
        public long Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Building Building { get; set; }

        public Guid BuildingId { get; set; }

        public VirtualCampusUser User { get; set; }

        public string UserId { get; set; }

        private bool Equals(Place other)
        {
            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var a = obj as Place;
            return a != null && Equals(a);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Latitude.GetHashCode() * 397) ^ Longitude.GetHashCode();
            }
        }
    }
}
