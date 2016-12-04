namespace Domain.Model.Database
{
    public class PhoneData
    {
        public double Direction { get; set; }
        public string MacAddress { get; set; }
        public PhoneLocation PhoneLocation { get; set; }
    }
}