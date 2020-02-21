using System;
using System.ComponentModel.DataAnnotations;

namespace Site_de_Vendas_com_autenticacao.Models {
    public class Compra {
        public int Id { get; set; }
        public string PessoaId { get; set; }
        
        [Display(Name = "Quantidade de Ingressos")]
        [Range(1,10,ErrorMessage = "escolha de 1 a 10 ingressos")]
        public int QtdIgressos { get; set; }
        
        [Display(Name = "Nome do evento")]
        public string EventoNome { get; set; }
        
        [Display(Name = "Preço do evento")]
        public double EventoPreco { get; set; }
        
        [Display(Name = "Data do evento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EventoData { get; set; }
        
        [Display(Name = "Nome da casa de show")]
        public string CasaNome { get; set; }
        
        [Display(Name = "Endereço da casa de show")]
        public string CasaEndereço { get; set; }
        
        [Display(Name = "Genero do show")]
        public string GeneroNome { get; set; }
        
        [Required(ErrorMessage = "coloque um nome")]
        public string NomeComprador { get; set; }
        
    }
}