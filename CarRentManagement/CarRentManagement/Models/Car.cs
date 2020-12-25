﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentManagement.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Display(Name = "Car Name")]
        [Required(ErrorMessage ="Car name is required")]
        public string CarName { get; set; }
        [Display(Name = "car image")]
        public string CarImageUrl { get; set; }
        [Required(ErrorMessage = "Rent is required")]
        public decimal HourlyRent { get; set; }
        [Display(Name = "Car Number")]
        public string CarNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
