using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace urban_leo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<urban_leo.Models.Contacto> DataContacto {get; set; }
    public DbSet<urban_leo.Models.Producto> DataProducto {get; set; }
    public DbSet<urban_leo.Models.Carrito> DataItemCarrito {get; set; }
    public DbSet<urban_leo.Models.Pago> Pago {get; set; }
    public DbSet<urban_leo.Models.Pedido> Pedido  {get; set; }

    public DbSet<urban_leo.Models.DetallePedido> DetallePedido  {get; set; }

}
