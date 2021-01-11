using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.ViewComponents{
    public class Search:ViewComponent{

        public IViewComponentResult Invoke(string searchS){

            ViewBag.SearchString=searchS;
            return View();
        }
    }
}