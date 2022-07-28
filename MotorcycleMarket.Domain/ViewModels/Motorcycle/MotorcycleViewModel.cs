using Microsoft.AspNetCore.Http;

namespace MotorcycleMarket.Domain.ViewModels.Motorcycle
{
    public class MotorcycleViewModel 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public float Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public string TypeMotorcycle { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
