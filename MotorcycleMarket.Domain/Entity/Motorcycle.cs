using MotorcycleMarket.Domain.Enum;

namespace MotorcycleMarket.Domain.Entity
{
    public class Motorcycle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public double Speed { get; set; }
        public string Price { get; set; }

        public DateTime DateCreate { get; set; }

        public TypeMotorcycle TypeMotorcycle { get; set; }
    }
}