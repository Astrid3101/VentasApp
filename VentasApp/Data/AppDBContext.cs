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
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<TipoCambio> TipoCambios { get; set; }

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

            modelBuilder.Entity<Producto>(tb =>
            {
                tb.HasKey(col => col.IdProducto);

                tb.Property(col => col.IdProducto)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.NombreProducto).HasMaxLength(100);
                tb.Property(col => col.CodigoProducto).HasMaxLength(50);
                tb.Property(col => col.CodigoBarras).HasMaxLength(50);
                tb.Property(col => col.SKU).HasMaxLength(50);
                tb.Property(col => col.Precio).HasColumnType("decimal(18,2)");
                tb.Property(col => col.Stock).HasDefaultValue(0);
            });

            modelBuilder.Entity<Producto>().ToTable("Productos");

            modelBuilder.Entity<Pedido>(tb =>
            {
                tb.HasKey(col => col.IdPedido);

                tb.Property(col => col.DescripcionPedido).HasMaxLength(100);

                tb.Property(col => col.IdPedido)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.FechaPedido)
                .HasColumnType("datetime")
                .IsRequired();

                tb.HasOne(p => p.Cliente)
                  .WithMany(c => c.Pedidos)
                  .HasForeignKey(p => p.ClienteId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Pedido>().ToTable("Pedidos");

            modelBuilder.Entity<PedidoDetalle>(tb =>
            {
                tb.HasKey(col => col.IdPedido);

                tb.Property(col => col.IdPedido)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Cantidad).IsRequired();
                tb.Property(col => col.Precio).HasColumnType("decimal(18,2)").IsRequired();
                tb.Property(col => col.ITBMS).HasColumnType("decimal(18,2)").IsRequired();

                tb.HasOne(pd => pd.Pedido)
                    .WithMany(p => p.PedidoDetalles)
                    .HasForeignKey(pd => pd.PedidoId)
                    .OnDelete(DeleteBehavior.Cascade);

                tb.HasOne(pd => pd.Producto)
                    .WithMany(p => p.PedidoDetalles)
                    .HasForeignKey(pd => pd.ProductoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PedidoDetalle>().ToTable("PedidoDetalles");

            modelBuilder.Entity<Factura>(tb =>
            {
                tb.HasKey(col => col.IdFactura);

                tb.Property(col => col.IdFactura)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Fecha)
                    .HasColumnType("datetime")
                    .IsRequired();

                tb.Property(col => col.Total).HasColumnType("decimal(18,2)").IsRequired();
                tb.Property(col => col.ITBMS).HasColumnType("decimal(18,2)").IsRequired();

                tb.HasOne(f => f.Pedido)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(f => f.PedidoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Factura>().ToTable("Facturas");

            modelBuilder.Entity<TipoCambio>(tb =>
            {
                tb.HasKey(col => col.IdTipo);

                tb.Property(col => col.IdTipo)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Moneda).HasMaxLength(50).IsRequired();
                tb.Property(col => col.Cambio).HasColumnType("decimal(18,2)").IsRequired();
                tb.Property(col => col.Fecha)
                    .HasColumnType("datetime")
                    .IsRequired();
            });

            modelBuilder.Entity<TipoCambio>().ToTable("TipoCambios");

        }
        

    }
}
