using System;
using System.Collections.Generic;

namespace Core.Domain.Model
{
    public sealed class Building : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        public ICollection<FacultyWreaper> Faculties { get; set; }

        public ICollection<Place> Places { get; set; }

        private bool Equals(Building other)
        {
            return Id == other.Id && string.Equals(Name, other.Name) && string.Equals(Address, other.Address) && string.Equals(Description, other.Description) && DateTime.Equals(other.DateTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var a = obj as Building;
            return a != null && Equals(a);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Address?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Description?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ DateTime.GetHashCode();
                return hashCode;
            }
        }
    }
}
