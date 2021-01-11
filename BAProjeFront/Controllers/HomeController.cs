using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.Controllers{
    

    public class HomeController:Controller{
        
        public IActionResult Index(){
            return View();
        }
        public IActionResult contact(){
            return View();
        }

    }
}