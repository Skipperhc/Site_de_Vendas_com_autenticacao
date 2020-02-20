using System.Collections.Generic;

namespace Site_de_Vendas_com_autenticacao.Models.ViewModel {
    public class EventoViewModel {
        public Evento Evento { get; set; }
        public List<CasaShow> CasaShows { get; set; }
        public List<Genero> Generos { get; set; }
        
    }
}
