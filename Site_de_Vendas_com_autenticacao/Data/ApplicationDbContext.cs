﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 using Microsoft.EntityFrameworkCore;
 using Site_de_Vendas_com_autenticacao.Models;

 namespace Site_de_Vendas_com_autenticacao.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }
        
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<CasaShow> CasaShows { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}