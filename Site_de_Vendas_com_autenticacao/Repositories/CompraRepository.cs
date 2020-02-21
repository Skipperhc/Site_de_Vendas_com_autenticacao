using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Site_de_Vendas_com_autenticacao.Data;
using Site_de_Vendas_com_autenticacao.Models;
using Site_de_Vendas_com_autenticacao.Repositories.Interface;

namespace Site_de_Vendas_com_autenticacao.Repositories {
    public class CompraRepository : ICompraRepository {
        private readonly ApplicationDbContext _dbContext;

        public CompraRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Compra Buscar(int id) {
            return _dbContext.Compras.FirstOrDefault(x => x.Id == id);
        }

        public void Adicionar(Compra entidade) {
            _dbContext.Add(entidade);
            _dbContext.SaveChanges();
        }

        public void Remover(Compra entidade) {
            _dbContext.Compras.Remove(entidade);
            _dbContext.SaveChanges();
        }

        public List<Compra> Listar() {
            return _dbContext.Compras.ToList();
        }

        public void Editar(Compra entidade) {
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}