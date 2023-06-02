using gamer_project_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_project_MVC.Infra
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string de conexão com o banco
                // data source: nome do servidor do gerenciador do banco

                //! AUTENTICAÇÃO PELO WINDOWS

                // integrated security: autenticação pelo windows
                // TrustServerCertificate: autenticação pelo windows

                //! AUTENTICACAO PELO SQLSERVER
                // user Id = "nome do seu usuário de login"
                // pwd = "senha do seu usuário"
                optionsBuilder.UseSqlServer("Data Source = NOTE18-S14; Initial catalog = gamerManha; User Id = sa; pwd = Senai@134; TrustServerCertificate = true"); //string de conexão com o banco
            }
        }

        // referência de classes e tabelas
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
    }
}