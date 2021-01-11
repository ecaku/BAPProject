using BAProjeFront.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.Areas.Admin.Controllers{
    [Area("Admin")]
    
    public class HomeController:Controller{
        
        [AdminAuthorize]
        
        public IActionResult Index(){
            return View();
        }
    }
}