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
    public class PerfilController : Controller
    {
        private readonly ILogger<SignController> _logger;

        public PerfilController(ILogger<SignController> logger)
        {
            _logger = logger;
        }

        public IActionResult Perfil()
        {
            var idUsuario = HttpContext.Session.GetString("IdUsuario");
            long idUsuarioConv = Convert.ToInt64(idUsuario);
            return View(idUsuarioConv);
        }
    }
}
