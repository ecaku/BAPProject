using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.Controllers{
    [Route("[controller]/[action]")]
    public class CategoryController:Controller{
        
        public IActionResult Index(){
            return View();
        }
        
    }
}