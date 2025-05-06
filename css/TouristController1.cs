using Microsoft.AspNetCore.Mvc;
using corevipul1.Models;

namespace corevipul1.Controllers
{
    public class TouristController1 : Controller
    {

        public IActionResult place()
        {
            return View();
        }
        public IActionResult TajMahal()
        {
            var place = new Touristplace
            {
                PlaceName = "Taj Mahal",
                CityName = "Agra",
                Price = 500,
                Description = "Taj Mahal is a white marble mausoleum built by Shah Jahan for Mumtaz Mahal.",
                photo = "tajmahal.jpeg"
            };
            return View(place);
        }

        public IActionResult RedFort()
        {
            var place = new Touristplace
            {
                PlaceName = "Red Fort",
                CityName = "Delhi",
                Price = 300,
                Description = "The Red Fort was the main residence of the Mughal emperors for nearly 200 years.",
                photo = "redfort.jpeg"
            };
            return View(place);
        }

        public IActionResult Charminar()
        {
            var place = new Touristplace
            {
                PlaceName = "Charminar",
                CityName = "Hyderabad",
                Price = 250,
                Description = "Charminar is a historic monument and mosque located in Hyderabad.",
                photo = "charminar.jpeg"
            };
            return View(place);
        }
    }
}
