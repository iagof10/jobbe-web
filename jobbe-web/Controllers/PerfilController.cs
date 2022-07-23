using jobbe_web.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace jobbe_web.Controllers
{
    [EnableCors(PolicyName = "AllowAny")]
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

        [HttpGet]
        [Route("DetalhePerfil/{idUsuario}")]
        public async Task<IActionResult> DetalhePerfil(long idUsuario)
        {

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = new HttpResponseMessage();

            try
            {
                response = await httpClient.GetAsync("https://api.jobbeapp.com.br/api/UsuarioPrestador/GetInfoBasic?idUsuario=" + idUsuario).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var usuario = JsonConvert.DeserializeObject<ResponseBase<UsuarioPrestadorDtoBasicInfo>>(await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false));

                        if (usuario.Sucess)
                        {
                            ViewBag.Title = usuario.Data.Apelido + " - Jobbe";
                            ViewBag.Perfil = "https://api.jobbeapp.com.br/api/UsuarioPrestador/compact/" + usuario.Data.IdFotoPerfil;
                        }
                        else
                        {
                            ViewBag.Title = "Jobbe";
                            ViewBag.Perfil = "https://api.jobbeapp.com.br/api/UsuarioPrestador/perfilpadrao";
                        }
                    }
                }
                else
                {
                    ViewBag.Title = "Jobbe";
                    ViewBag.Perfil = "https://api.jobbeapp.com.br/api/UsuarioPrestador/perfilpadrao";
                }

            }
            catch (Exception)
            {
                ViewBag.Title = "Jobbe";
                ViewBag.Perfil = "https://api.jobbeapp.com.br/api/UsuarioPrestador/perfilpadrao";
            }

            ViewBag.Descricao = "Agora faço parte do #TEAMJOBBE, acesse o link e conheça meu perfil!";

            return View(idUsuario);
        }
    }
}
