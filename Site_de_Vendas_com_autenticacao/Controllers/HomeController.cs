using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Site_de_Vendas_com_autenticacao.Models;
using Site_de_Vendas_com_autenticacao.Models.ViewModel;
using Site_de_Vendas_com_autenticacao.Repositories;
using Site_de_Vendas_com_autenticacao.Repositories.Interface;

namespace Site_de_Vendas_com_autenticacao.Controllers {
    [Authorize] public class HomeController : Controller {
        private readonly IEventoRepository _eventoRepository;
        private readonly ICasaShowRepository _casaShowRepository;
        private readonly IGeneroRepository _generoRepository;
        private readonly ICompraRepository _compraRepository;
        private IHostingEnvironment _env;

        public HomeController(IEventoRepository eventoRepository, ICasaShowRepository casaShowRepository,
            IGeneroRepository generoRepository, IHostingEnvironment enviroment, ICompraRepository compraRepository) {
            _eventoRepository = eventoRepository;
            _casaShowRepository = casaShowRepository;
            _generoRepository = generoRepository;
            _env = enviroment;
            _compraRepository = compraRepository;
        }

        public IActionResult Index() {
            var list = _eventoRepository.Listar();
            return View(list);
        }

        [Authorize(Policy = "Admin")] [HttpGet]
        public IActionResult Criar() {
            var generos = _generoRepository.Listar();
            var casaShows = _casaShowRepository.Listar();
            var viewModel = new EventoViewModel() {
                CasaShows = casaShows, Generos = generos
            };
            return View(viewModel);
        }

        [Authorize(Policy = "Admin")] [HttpPost]
        public IActionResult Criar([FromForm] Evento evento) {
            evento.Id = 0;
            var casa = _casaShowRepository.Buscar(evento.CasaShowId);
            evento.QtdIngressos = casa.Capacidade;
            _eventoRepository.Adicionar(evento);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Admin")] [HttpGet]
        public IActionResult Editar(int id) {
            var evento = _eventoRepository.Buscar(id);
            var generos = _generoRepository.Listar();
            var casaShows = _casaShowRepository.Listar();
            var viewModel = new EventoViewModel() {
                CasaShows = casaShows, Evento = evento, Generos = generos
            };
            return View(viewModel);
        }

        [Authorize(Policy = "Admin")] [HttpPost]
        public IActionResult Editar([FromForm] Evento evento) {
            _eventoRepository.Editar(evento);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet] public IActionResult Comprar(int id) {
            var evento = _eventoRepository.Buscar(id);
            var casa = _casaShowRepository.Buscar(evento.CasaShowId);
            var genero = _generoRepository.Buscar(evento.GeneroId);
            Compra compra = new Compra() {
                Id = 0,
                PessoaId = "teste",
                EventoNome = evento.Nome,
                EventoPreco = evento.preco,
                EventoData = evento.Data,
                CasaNome = casa.Nome,
                CasaEndereço = casa.Endereco,
                GeneroNome = genero.Nome
            };
            CompraViewModel viewModel = new CompraViewModel() {
                Compra = compra, Evento = evento
            };
            return View(viewModel);
        }

        [HttpPost] public IActionResult Comprar(CompraViewModel model) {
            int qtd = model.Evento.QtdIngressos;
            var evento = _eventoRepository.Buscar(model.Evento.Id);
            evento.QtdIngressos = evento.QtdIngressos - model.Compra.QtdIgressos;
            ModelState.Remove("Evento.Nome");
            ModelState.Remove("Evento.preco");
            ModelState.Remove("Evento.Genero");
            ModelState.Remove("Evento.CasaShow");
            if (!ModelState.IsValid) {
                return RedirectToAction();
            }

            _compraRepository.Adicionar(model.Compra);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet] public IActionResult Detalhar(int id) {
            var evento = _eventoRepository.Buscar(id);
            var generos = _generoRepository.Listar();
            var casaShows = _casaShowRepository.Listar();
            var viewModel = new EventoViewModel() {
                CasaShows = casaShows, Evento = evento, Generos = generos
            };
            return View(viewModel);
        }

        [Authorize(Policy = "Admin")] [HttpPost]
        public IActionResult Deletar(int id) {
            var evento = _eventoRepository.Buscar(id);
            _eventoRepository.Remover(evento);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View
            (new ErrorViewModel {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}