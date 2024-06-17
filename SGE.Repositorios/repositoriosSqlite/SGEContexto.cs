using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class SGEContexto : DbContext
{

    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Tramite> Tramites { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=SGE.sqlite");
    }
}