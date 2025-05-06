using System.Security.Claims;
using System.Threading.Tasks;
using corevipul1.Data;
using corevipul1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace corevipul1.Controllers
{
    public class EmployeeController1 : Controller
    {
        private readonly Corevipul1Context db;

        public EmployeeController1(Corevipul1Context db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = (from emp in db.Tblemployees
                        join c in db.Tblcountries on emp.Country equals c.Cid
                        join s in db.Tblstates on emp.State equals s.Sid
                        join z in db.Tblcities on emp.City equals z.Zid
                        select new Tblemployee
                        {
                            Id = emp.Id,
                            Name = emp.Name,
                            Age = emp.Age,
                            Salary = emp.Salary,
                            Email = emp.Email,
                            Password = emp.Password,
                            Datetime = emp.Datetime,
                            Dob = emp.Dob,
                            Gender = emp.Gender,
                            Hobbies = emp.Hobbies,
                            Photo = emp.Photo,
                            CountryName = c.Cname,
                            StateName = s.Sname,
                            CityName = z.Zname
                        }).ToList();

            return View(data);
        }

        // Create - GET
        public IActionResult Create()
        {
            ViewBag.CountryList = new SelectList(db.Tblcountries.ToList(), "Cid", "Cname");
            ViewBag.GenderList = new SelectList(db.Tblgenders.ToList(), "Gname", "Gname");
            ViewBag.HobbiesList = db.Tblhobbies.ToList();
            return View();
        }

        // Create - POST
        [HttpPost]
        public IActionResult Create(Tblemployee emp, List<string> hobbies)
        {
            emp.Hobbies = string.Join(",", hobbies);

            if (emp.UploadFile != null && emp.UploadFile.Length > 0)
            {
                // 1. Uploads folder path
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                // 2. Check if uploads folder exists, if not create it
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // 3. File saving
                var fileName = Path.GetFileName(emp.UploadFile.FileName);
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    emp.UploadFile.CopyTo(stream);
                }

                // 4. Save filename to database
                emp.Photo = uniqueFileName;
            }

            // Save data to DB
            db.Tblemployees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Edit - GET
        public IActionResult Edit(int id)
        {
            var emp = db.Tblemployees.Find(id);
            ViewBag.CountryList = new SelectList(db.Tblcountries.ToList(), "Cid", "Cname", emp.Country);
            ViewBag.StateList = new SelectList(db.Tblstates.Where(x => x.Cid == emp.Country).ToList(), "Sid", "Sname", emp.State);
            ViewBag.CityList = new SelectList(db.Tblcities.Where(x => x.Sid == emp.State).ToList(), "Zid", "Zname", emp.City);
            ViewBag.GenderList = new SelectList(db.Tblgenders.ToList(), "Gname", "Gname", emp.Gender);
            ViewBag.HobbiesList = db.Tblhobbies.ToList();
            ViewBag.SelectedHobbies = emp.Hobbies?.Split(',');
            return View(emp);
        }

        // Edit - POST
        [HttpPost]
        public IActionResult Edit(Tblemployee emp, List<string> hobbies)
        {
            emp.Hobbies = string.Join(",", hobbies);

            if (emp.UploadFile != null && emp.UploadFile.Length > 0)
            {
                var fileName = Path.GetFileName(emp.UploadFile.FileName);
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    emp.UploadFile.CopyTo(stream);
                }

                emp.Photo = uniqueFileName;
            }
            else
            {
                var existingEmp = db.Tblemployees.AsNoTracking().FirstOrDefault(x => x.Id == emp.Id);
                emp.Photo = existingEmp?.Photo;
            }

            db.Tblemployees.Update(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete - GET
        public IActionResult Delete(int id)
        {
            var emp = db.Tblemployees.Find(id);
            return View(emp);
        }

        // Delete - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = db.Tblemployees.Find(id);
            db.Tblemployees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Details
        public IActionResult Details(int id)
        {
            var emp = db.Tblemployees.Find(id);
            return View(emp);
        }

        // AJAX call for cascading State
        public JsonResult GetStates(int cid)
        {
            var states = db.Tblstates.Where(x => x.Cid == cid).ToList();
            return Json(states);
        }

        // AJAX call for cascading City
        public JsonResult GetCities(int sid)
        {
            var cities = db.Tblcities.Where(x => x.Sid == sid).ToList();
            return Json(cities);
        }

        [HttpGet]
        public IActionResult Ulogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ulogin(Tblemployee emp)
        {
            var user = db.Tblemployees
                         .FirstOrDefault(e => e.Email == emp.Email && e.Password == emp.Password);

            if (user != null)
            {
                // Login success, redirect to Index page
                return RedirectToAction("place", "TouristController1");
                Response.Redirect("place");
            }
            else
            {
                ViewBag.Error = "Invalid Email or Password";
                return View();
            }
        }

    }
}
