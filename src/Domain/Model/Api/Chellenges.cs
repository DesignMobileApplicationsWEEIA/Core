using System.Collections.Generic;
using Domain.Model.Database;

namespace Domain.Model.Api
{
    public class Chellenges
    {
        public IEnumerable<Achievement> Completed { get; set; }
        public IEnumerable<Achievement> ToDo { get; set; }
    }
}