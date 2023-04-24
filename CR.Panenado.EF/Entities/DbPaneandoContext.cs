using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CR.Panenado.EF.Entities;

public partial class DbPaneandoContext : DbContext
{
    public DbPaneandoContext()
    {
    }

    public DbPaneandoContext(DbContextOptions<DbPaneandoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public virtual DbSet<PedidoFecha> PedidoFechas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoPrecio> ProductoPrecios { get; set; }

    public virtual DbSet<TipoProducto> TipoProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=AAD\\SQLEXPRESS; Database=dbPaneando; User Id=sa; Password=password;Encrypt=False;Trusted_Connection=true");
        => optionsBuilder.UseSqlServer("Server=AAD\\SQLEXPRESS; Database=dbPaneando; User Id=sa; Password=password;Encrypt=False;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.IdOrden);

            entity.ToTable("orden");

            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaDespacho)
                .HasColumnType("date")
                .HasColumnName("fecha_despacho");
            entity.Property(e => e.HoraMinutoDespacho)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("hora_minuto_despacho");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_orden_pedido");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido);

            entity.ToTable("pedido", tb => tb.HasTrigger("Registrar_PedidoFecha"));

            entity.HasIndex(e => e.Estado, "NCI_estado");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.HoraMinuto)
                .HasPrecision(0)
                .HasColumnName("hora_minuto");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdProducto });

            entity.ToTable("pedido_detalle");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Eliminado).HasColumnName("eliminado");
            entity.Property(e => e.ValorVenta).HasColumnName("valor_venta");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_detalle_pedido");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_producto_pedido_detalle");
        });

        modelBuilder.Entity<PedidoFecha>(entity =>
        {
            entity.HasKey(e => e.IdPedidoFecha);

            entity.ToTable("pedido_fecha");

            entity.Property(e => e.IdPedidoFecha).HasColumnName("id_pedido_fecha");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.DiaSemana)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dia_semana");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.HoraMinuto).HasColumnName("hora_minuto");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoFechas)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_fecha_pedido");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0D3C37449A");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdTipoProducto).HasColumnName("id_tipo_producto");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdTipoProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_tipo_producto");
        });

        modelBuilder.Entity<ProductoPrecio>(entity =>
        {
            entity.HasKey(e => e.IdProductoPrecio).HasName("PK__producto__06B7F860AB0B9BF9");

            entity.ToTable("producto_precio");

            entity.Property(e => e.IdProductoPrecio).HasColumnName("id_producto_precio");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.ValorProduccion).HasColumnName("valor_produccion");
            entity.Property(e => e.ValorVenta).HasColumnName("valor_venta");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoPrecios)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_id_producto");
        });

        modelBuilder.Entity<TipoProducto>(entity =>
        {
            entity.HasKey(e => e.IdTipoProducto).HasName("PK__tipo_pro__F5E0BFB848C8417F");

            entity.ToTable("tipo_producto");

            entity.Property(e => e.IdTipoProducto).HasColumnName("id_tipo_producto");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
