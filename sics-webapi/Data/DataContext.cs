using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sics_webapi.Models;

namespace sics_webapi.Data;

public class DataContext : IdentityDbContext<SicsUsuario>
{
    public DataContext(DbContextOptions options) : base(options) {}
    public DbSet<SicsServico> SicsServicos { get; set; }
    public DbSet<SicsPrestador> SicsPrestadores { get; set; }
    public DbSet<SicsCliente> SicsClientes { get; set; }
    public DbSet<SicsServicoContratado> SicsServicosContratados { get; set; }
    public DbSet<SicsServicoOferecido> SicsServicosOferecidos { get; set; }
    public DbSet<SicsTransacao> SicsTransacoes { get; set; }
    public DbSet<SicsAvaliacao> SicsAvaliacoes { get; set; }
}