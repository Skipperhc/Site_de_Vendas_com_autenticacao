using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Site_de_Vendas_com_autenticacao.Data;
using Site_de_Vendas_com_autenticacao.Models;

namespace Site_de_Vendas_com_autenticacao.Repositories.Interface {
    public class CasaShowRepository : ICasaShowRepository {

        private readonly ApplicationDbContext _dbContext;

        public CasaShowRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        
        public void Adicionar(CasaShow entidade) {
            _dbContext.Add(entidade);
            _dbContext.SaveChanges();
        }

        public CasaShow Buscar(int id) {
            return _dbContext.CasaShows.FirstOrDefault(x => x.Id == id);
        }

        public List<CasaShow> Listar() {
            return _dbContext.CasaShows.ToList();
        }

        public void Editar(CasaShow entidade) {
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        
        public void Remover(CasaShow entidade) {
            _dbContext.CasaShows.Remove(entidade);
            _dbContext.SaveChanges();
        }
    }
}