using Domain.Model.Database;

namespace Domain.Model.Api
{
    public class ApiBuilding
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public static Building ToBuilding(ApiBuilding building)
        {
            return new Building()
            {
                Name = building.Name,
                Address = building.Address,
                Description = building.Description,
            };
        }
    }
}