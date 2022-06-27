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
    public class RecoverPasswordConfirmationController : Controller
    {
        private readonly ILogger<SignController> _logger;

        public RecoverPasswordConfirmationController(ILogger<SignController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("RecoverPasswordConfirmation/{idRecoverPassword}")]
        public IActionResult RecoverPasswordConfirmation(string idRecoverPassword)
        {
            return View((object)idRecoverPassword);
        }
    }
}
