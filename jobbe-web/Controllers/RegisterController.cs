using jobbe_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace jobbe_web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<SignController> _logger;

        public RegisterController(ILogger<SignController> logger)
        {
            _logger = logger;
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
