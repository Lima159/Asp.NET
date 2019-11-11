using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Context
{
    public class BibliotecaContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Leitor> Leitor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public BibliotecaContext() { }
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
