using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Model.Database
{
    public class VirtualCampusUser : IdentityUser, IEntity
    {
        public ICollection<Place> Places { get; set; }
    }
}