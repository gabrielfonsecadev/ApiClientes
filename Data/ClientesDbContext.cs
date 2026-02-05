using ApiClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Data;

public class ClientesDbContext : DbContext
{
    public ClientesDbContext(DbContextOptions<ClientesDbContext> options)
        : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasIndex(c => c.Email).IsUnique();

            entity.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);
        });

        base.OnModelCreating(modelBuilder);
    }
}
