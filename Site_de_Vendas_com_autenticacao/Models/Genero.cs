﻿using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Site_de_Vendas_com_autenticacao.Models {
    public class Genero {
        public int Id { get; set; }
        
        
        [Required(ErrorMessage = "{0} Requerido")]
        public string Nome { get; set; }
        
        public string Imagem { get; set; }
    }
}