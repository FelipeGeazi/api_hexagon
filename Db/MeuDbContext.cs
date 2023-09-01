using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiHexagon.Db
{
    public class MeuDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public MeuDbContext(DbContextOptions<MeuDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Pessoa> Pessoas { get; set; }

     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
       {
        string connectionString = _configuration.GetConnectionString("MeuBancoConnection");
        optionsBuilder.UseSqlServer(connectionString);
        }else
        {
            // Lidar com a situação em que a connectionString é nula
            // Isso pode incluir gerar um erro, definir uma conexão padrão, etc.
        }
    }
}
    }

