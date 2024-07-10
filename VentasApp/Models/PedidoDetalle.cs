using System.ComponentModel.DataAnnotations;

namespace VentasApp.Models
{
    public class PedidoDetalle
    {
        public int IdPedido { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal ITBMS { get; set; }

        public Pedido Pedido { get; set; }
        public Producto Producto { get; set; }
    }
}
