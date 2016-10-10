using System;
using System.Collections.Generic;

namespace Core.Domain.Model
{
    public sealed class Building : BaseEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public ICollection<FacultyWreaper> Faculties { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
