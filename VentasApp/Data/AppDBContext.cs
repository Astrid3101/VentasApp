using Microsoft.EntityFrameworkCore;
using VentasApp.Models;

namespace VentasApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {


        }

        public DbSet<Cliente> Clientes { get; set; }
        /*public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<TipoDeCambio> TiposDeCambio { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(tb =>
            {
                tb.HasKey(col => col.Id);

                tb.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre).HasMaxLength(100);
                tb.Property(col => col.Direccion).HasMaxLength(200);
                tb.Property(col => col.Telefono).HasMaxLength(30);
                tb.Property(col => col.Email).HasMaxLength(100);
            });

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
        }

    }
}
