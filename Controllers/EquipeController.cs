using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using gamer_project_MVC.Infra;
using gamer_project_MVC.Models;
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

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe(); // instancia do objeto equipe

            // atribuicao de valores recebidos do formulario 
            novaEquipe.Nome = form["Nome"].ToString();
            novaEquipe.Imagem = form["Imagem"].ToString();

            c.Equipe.Add(novaEquipe); // adiciona objeto na tabela do banco de dados

            c.SaveChanges(); // salva alteracoes no banco de dados 

            return LocalRedirect("~/Equipe/Listar"); // retorna para o local chamando a rota de listar (metodo index)
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}