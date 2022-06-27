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
    public class CompleteSignController : Controller
    {
        private readonly ILogger<SignController> _logger;

        public CompleteSignController(ILogger<SignController> logger)
        {
            _logger = logger;
        }

        public IActionResult CompleteSign()
        {
            return View();
        }
        public IActionResult CompleteSignSubCategoria(long idCategoria)
        {
            return View(idCategoria);
        }
    }
}
