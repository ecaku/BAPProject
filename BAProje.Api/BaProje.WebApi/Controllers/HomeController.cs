using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseController
    {
        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo=HttpContext.Features.Get<IExceptionHandlerFeature>();
            return Problem(detail: "An Error Occuer");
        }

    }
}