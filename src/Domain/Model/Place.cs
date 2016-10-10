using System;

namespace Core.Domain.Model
{
    public sealed class Place : BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Building Building { get; set; }

        public Guid BuildingId { get; set; }

        private bool Equals(Place other)
        {
            return Id.Equals(other.Id) && string.Equals(Name, other.Name) && Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude) && BuildingId.Equals(other.BuildingId);
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
                int hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Latitude.GetHashCode();
                hashCode = (hashCode*397) ^ Longitude.GetHashCode();
                hashCode = (hashCode*397) ^ BuildingId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Place place1, Place place2) => place1 != null && place1.Equals(place2);

        public static bool operator !=(Place place1, Place place2) => !(place1 == place2);
    }
}
