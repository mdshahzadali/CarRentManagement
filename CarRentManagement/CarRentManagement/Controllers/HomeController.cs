using CarRentManagement.Models;
using CarRentManagement.Models.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarRentDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, CarRentDbContext dbContext , IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var carList = _dbContext.Cars.ToList();
            return View(carList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarViewModel carModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(carModel.CarImage != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images\\CarImage");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + carModel.CarImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    carModel.CarImage.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Car car = new Car
                {
                    CarName = carModel.CarName,
                    CarImageUrl = uniqueFileName,
                    HourlyRent = carModel.HourlyRent,
                    CarNumber = carModel.CarNumber,
                    IsAvailable = true
                };
                _dbContext.Add(car);
                _dbContext.SaveChanges();
            }
            return View(carModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
