using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using gamer_project_MVC.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gamer_project_MVC.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }

        Context c = new Context(); // instancia do context para acessar o banco e dados

        [Route("Listar")] //http://localhost/Equipe/Listar
        public IActionResult Index()
        {
            ViewBag.Equipe = c.Equipe.ToList(); //atraves do context ta acessando a tabela equipe e fazendo a listagem. A viewbag é uma variavel que guardara as equipes listadas no banco de dados

            // retorna a view da equipe (TELA)
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}