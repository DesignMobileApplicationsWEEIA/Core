using System;
using System.Collections.Generic;

namespace Core.Domain.Model
{
    public sealed class Building : BaseEntity
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public List<FacultyWreaper> Faculties { get; set; }
      
        public Building()
        {
        }
    }
}
