﻿using System.Security.Claims;
using System.Security.Policy;
using Microsoft.AspNetCore.Authentication;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
 using Site_de_Vendas_com_autenticacao.Repositories.Interface;
 using Site_de_Vendas_com_autenticacao.Models;
 using Site_de_Vendas_com_autenticacao.Models.ViewModel;

 namespace Site_de_Vendas_com_autenticacao.Controllers {
     [Authorize(Policy = "Admin")]
    public class CasaShowController : Controller {

        private readonly ICasaShowRepository _casaShowRepository;

        public CasaShowController(ICasaShowRepository casaShowRepository) {
            _casaShowRepository = casaShowRepository;
        }

        // GET
        public IActionResult Index() {
            var listaCasas = _casaShowRepository.Listar();
            var viewModel = new CasaShowViewModel(){ListaCasaShows = listaCasas};
            return View(viewModel);
        }

        [HttpPost] public IActionResult Criar([FromForm] CasaShowViewModel casaShowViewModel) {
            if (ModelState.IsValid) {
                _casaShowRepository.Adicionar(casaShowViewModel.CasaShow);
                return RedirectToAction(nameof(Index));
            } else {
                return RedirectToAction("Index", "CasaShow");
            }
        }

        [HttpGet] public IActionResult Editar(int id) {
            var casa = _casaShowRepository.Buscar(id);
            return View(casa);
        }

        [HttpPost] public IActionResult Editar([FromForm] CasaShow casaShow) {
            _casaShowRepository.Editar(casaShow);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet] public IActionResult Detalhar(int id) {
            var casa = _casaShowRepository.Buscar(id);
            return View(casa);
        }

        [HttpPost] public IActionResult Deletar(int id) {
            var casa = _casaShowRepository.Buscar(id);
            _casaShowRepository.Remover(casa);
            return RedirectToAction(nameof(Index));
        }
    }
}