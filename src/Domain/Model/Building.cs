using System.Collections.Generic;

namespace Core.Domain.Model
{
    public sealed class Building : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
        
        public ICollection<Faculty> Faculties { get; set; }

        public ICollection<Place> Places { get; set; }

        private bool Equals(Building other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Address, other.Address) && string.Equals(Description, other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var building = obj as Building;
            return building != null && Equals(building);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Address?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Description?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
