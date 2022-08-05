﻿using MotorcycleMarket.Domain.Enum;


namespace MotorcycleMarket.Domain.Entity
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
