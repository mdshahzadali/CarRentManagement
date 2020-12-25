using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentManagement.Models
{
    public class CarViewModel
    {
        [Display(Name = "Car Name")]
        [Required(ErrorMessage = "Car name is required")]
        public string CarName { get; set; }
        [Display(Name = "Hourly Rent")]
        public decimal HourlyRent { get; set; }
        [Display(Name = "Car Number")]
        public string CarNumber { get; set; }
        public bool IsAvailable { get; set; }

        //Not mapped propety used only image upload
        [Display(Name = "Choose the car image")]
        public IFormFile CarImage { get; set; }
    }
}
