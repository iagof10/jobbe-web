using jobbe_web.Models;
using Microsoft.AspNetCore.Cors;
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
    public class TermsController : Controller
    {
        private readonly ILogger<TermsController> _logger;

        public TermsController(ILogger<TermsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Terms()
        {
            return View();
        }
    }
}
