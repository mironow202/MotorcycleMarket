using Microsoft.AspNetCore.Http;
using MotorcycleMarket.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleMarket.Domain.Entity
{
    public class Motorcycle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public float Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public TypeMotorcycle TypeMotorcycle { get; set; }
        public byte[]? Avatar { get; set; }
    }
}