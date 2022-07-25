using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleMarket.Domain.ViewModels.Motorcycle
{
    public class MotorcycleViewModel 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public string TypeMotorcycle { get; set; }
    }
}
