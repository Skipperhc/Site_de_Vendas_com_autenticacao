using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Site_de_Vendas_com_autenticacao.Models {
    public class Evento {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} Requerido")]
        [Display(Name="Nome do Evento")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "{0} Requerido")]
        [Range(20.0, 400.0, ErrorMessage = "{0} must be from {1} To {2}")]
        [Display(Name="Valor da entrada")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double preco { get; set; }
        
        [Required(ErrorMessage = "{0} Requerido")]
        [Display(Name="Casa de Show")]
        public CasaShow CasaShow { get; set; }
        
        [Required(ErrorMessage = "{0} Requerido")]
        [Display(Name="Gênero")]
        public Genero Genero { get; set; }
        
        [Required(ErrorMessage = "{0} Requerida")]
        [DataType(DataType.Date)]
        [Display(Name="Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        public int CasaShowId { get; set; }
        public int GeneroId { get; set; }
        
    }
}