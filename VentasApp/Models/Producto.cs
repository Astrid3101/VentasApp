using System.ComponentModel.DataAnnotations;

namespace VentasApp.Models
{
    public class Producto
    {

        public int IdProducto { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        public string CodigoProducto { get; set; }

        public string CodigoBarras { get; set; }

        public string SKU { get; set; }

        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
