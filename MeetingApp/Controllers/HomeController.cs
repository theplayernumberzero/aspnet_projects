using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers{
    public class HomeController : Controller{
        public IActionResult Index(){
            int saat = DateTime.Now.Hour;
            
            ViewBag.Selamla = saat > 12 ? "İyi günler" : "Günaydınlar";
            int UserCount = Repository.Users.Where(i => i.WillAttend == true).Count();
            
            //ViewData["Username"] = "Bahadir";

            var meetingInfo = new MeetingInfo(){
                Id = 1,
                Location = "Istanbul",
                Date = new DateTime(2025, 05, 25, 20, 0, 0),
                NumberOfPeople = UserCount
            };

            return View(meetingInfo);
        }
    }
}