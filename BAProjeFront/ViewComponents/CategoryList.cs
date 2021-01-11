using BAProjeFront.ApiServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.ViewComponents{
    public class CategoryList:ViewComponent{

        private readonly ICategoryService _categoryService;
        public CategoryList(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }
        public IViewComponentResult Invoke(){
            return View(_categoryService.GetAllAsync().Result);
        }
    }
}