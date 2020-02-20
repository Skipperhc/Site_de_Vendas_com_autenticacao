using System.ComponentModel.DataAnnotations;

namespace Site_de_Vendas_com_autenticacao.Models {
    public class CasaShow {
        public int Id { get; set; }
        
        
        [Required(ErrorMessage = "Nome Requerido")]
        [StringLength(30,ErrorMessage = "Nome grande demais")]
        [MinLength(3,ErrorMessage = "Nome muito curto")]
        public string Nome { get; set; }
        
        
        [Required(ErrorMessage = "Endereço Requerido")]
        [Display(Name="Endereço")]
        [MinLength(3,ErrorMessage = "Endereço muito curto")]
        public string Endereco { get; set; }
        
        
        [Required(ErrorMessage = "Capacidade Requerido")]
        [Range(100.0, 5000.0, ErrorMessage = "{0} precisa estar entre {1} e {2}")]
        [Display(Name="Capacidade Max")]
        public int Capacidade { get; set; }
    }
}