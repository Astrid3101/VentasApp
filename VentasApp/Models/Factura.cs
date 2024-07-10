using System.ComponentModel.DataAnnotations;
namespace VentasApp.Models
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public decimal ITBMS { get; set; }

        public Pedido Pedido { get; set; }


    }
}
