﻿using System;
using System.IO;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
 using Site_de_Vendas_com_autenticacao.Repositories.Interface;
 using Site_de_Vendas_com_autenticacao.Models;
 using Site_de_Vendas_com_autenticacao.Models.ViewModel;
 using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Site_de_Vendas_com_autenticacao.Controllers {
    [Authorize(Policy = "Admin")]
    public class GeneroController : Controller {
        private readonly IGeneroRepository _generoRepository;
        private IHostingEnvironment _env;

        public GeneroController(IGeneroRepository generoRepository, IHostingEnvironment enviroment) {
            _generoRepository = generoRepository;
            _env = enviroment;
        }

        // GET
        public IActionResult Index() {
            var listaGeneros = _generoRepository.Listar();
            var viewModel = new GeneroViewModel(){ListaGeneros = listaGeneros};
            return View(viewModel);
        }

        [HttpPost] public IActionResult Criar(GeneroViewModel model) {
            if (ModelState.IsValid) {
                Genero generoMusical = new Genero();
                generoMusical.Nome = model.GeneroMusical.Nome;
                generoMusical.Imagem = Uploadimg(model.FileImage);
                _generoRepository.Adicionar(generoMusical);
                return RedirectToAction(nameof(Index));
            } else {
                return View("Index");
            }
        }

        [HttpGet] public IActionResult Editar(int id) {
            var genero = _generoRepository.Buscar(id);
            return View(genero);
        }

        [HttpPost] public IActionResult Editar([FromForm] Genero genero) {
            _generoRepository.Editar(genero);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet] public IActionResult Detalhar(int id) {
            var genero = _generoRepository.Buscar(id);
            return View(genero);
        }
        
        public string Uploadimg(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\upload\imagens\";
                var uploadPath = _env.WebRootPath + imagePath;
                
                //create repository
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                
                //create uniq file name
                var uniqFileName = Guid.NewGuid().ToString();
                var filename = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + filename;

                imagePath = imagePath + @"\";
                var filePath = @".." + Path.Combine(imagePath, filename);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                
                return filePath;
            }
            return string.Empty;
        }

        [HttpPost] public IActionResult Deletar(int id) {
            var casa = _generoRepository.Buscar(id);
            if (Directory.Exists(casa.Imagem)) {
                Directory.Delete(casa.Imagem, true);
            }
            _generoRepository.Remover(casa);
            return RedirectToAction(nameof(Index));
        }
    }
}