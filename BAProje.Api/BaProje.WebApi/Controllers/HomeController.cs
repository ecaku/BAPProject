using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaProje.Business.Tools;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly ICustomLogger _customLogger;
        public HomeController(ICustomLogger customLogger)
        {
            _customLogger = customLogger;
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo=HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLogger.LogError($"\nErrorAddress:{errorInfo.Path}\nError Message:{errorInfo.Error.Message}\n Stack Trace:{errorInfo.Error.StackTrace}");

            return Problem(detail: "An Error Occuer");
        }

    }
}