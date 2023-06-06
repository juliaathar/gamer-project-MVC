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
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        Context c = new Context();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogador = c.Jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();

            novoJogador.Nome = form["Nome"].ToString();
            novoJogador.Email = form["Email"].ToString();
            novoJogador.Senha = form["Senha"].ToString();
            novoJogador.IdEquipe = int.Parse(form["Equipe"].ToString());

            c.Jogador.Add(novoJogador);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            Jogador jogadorBuscado = c.Jogador.First(e => e.IdJogador == id);


            c.Remove(jogadorBuscado);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            Jogador jogadorBuscado = c.Jogador.First(j => j.IdJogador == id);

            ViewBag.Jogador = jogadorBuscado;
            ViewBag.Equipe = c.Equipe.ToList();

            return View("Edit");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form)
        {
            Jogador jogador = new Jogador();

            jogador.IdJogador = int.Parse(form["IdJogador"].ToString());
            jogador.IdEquipe = int.Parse(form["IdEquipe"].ToString());
            jogador.Nome = form["Nome"].ToString();
            jogador.Email = form["Email"].ToString();

            Jogador jogadorProcurado = c.Jogador.First(j => j.IdJogador == jogador.IdJogador);

            jogadorProcurado.Nome = jogador.Nome;
            jogadorProcurado.Email = jogador.Email;
            jogadorProcurado.IdEquipe = jogador.IdEquipe;

            c.Jogador.Update(jogadorProcurado);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }
    }
}