using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Site_de_Vendas_com_autenticacao.Data;
using Site_de_Vendas_com_autenticacao.Models;

namespace Site_de_Vendas_com_autenticacao.Repositories.Interface {
    public class GeneroRepository : IGeneroRepository {
        private readonly ApplicationDbContext _dbContext;

        public GeneroRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Genero Buscar(int id) {
            return _dbContext.Generos.FirstOrDefault(x => x.Id == id);
        }

        public void Adicionar(Genero entidade) {
            _dbContext.Add(entidade);
            _dbContext.SaveChanges();
        }

        public void Remover(Genero entidade) {
            _dbContext.Generos.Remove(entidade);
            _dbContext.SaveChanges();
        }

        public List<Genero> Listar() {
            return _dbContext.Generos.ToList();
        }

        public void Editar(Genero entidade) {
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}