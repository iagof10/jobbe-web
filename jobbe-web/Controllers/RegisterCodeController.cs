using jobbe_web.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace jobbe_web.Controllers
{
    [EnableCors(PolicyName = "AllowAny")]
    public class RegisterCodeController : Controller
    {
        private readonly ILogger<RegisterCodeController> _logger;

        public RegisterCodeController(ILogger<RegisterCodeController> logger)
        {
            _logger = logger;
        }

        public IActionResult RegisterCode()
        {
            return View();
        }
    }
}
