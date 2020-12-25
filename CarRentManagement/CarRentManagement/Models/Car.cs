using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentManagement.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarImageUrl { get; set; }
        public decimal HourlyRent { get; set; }
        public string CarNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
