using jobbe_web.Models;
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
    public class SignController : Controller
    {
        private readonly ILogger<SignController> _logger;

        public SignController(ILogger<SignController> logger)
        {
            _logger = logger;
        }

        public IActionResult Sign()
        {
            return View();
        }

        public IActionResult RecoverPassword()
        {
            return View();
        }

        [HttpGet]
        [Route("RecoverPasswordConfirmation/{idRecoverPassword}")]
        public IActionResult RecoverPasswordConfirmation(string idRecoverPassword)
        {
            return View(idRecoverPassword);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("SaveSessionUser/{idUsuario}")]
        public bool SaveSessionUser(long idUsuario)
        {
            HttpContext.Session.SetString("IdUsuario", Convert.ToString(idUsuario));
            return true;
        }

        [HttpGet]
        [Route("GetSessionUser")]
        public long GetSessionUser()
        {
            var idUsuario = HttpContext.Session.GetString("IdUsuario");
            var idUsuarioConv = Convert.ToInt64(idUsuario);
            return idUsuarioConv;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
