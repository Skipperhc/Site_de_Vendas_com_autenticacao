﻿using Site_de_Vendas_com_autenticacao.Models;

namespace Site_de_Vendas_com_autenticacao.Repositories.Interface {
    public interface IEventoRepository : IRepository<Evento> {
        void Comprar(Evento evento, int qtdingressos);
    }
}