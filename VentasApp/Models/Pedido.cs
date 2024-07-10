using System.ComponentModel.DataAnnotations;

namespace VentasApp.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }

        public int ClienteId { get; set; }
        public DateTime FechaPedido { get; set; }   

        public Cliente Cliente { get; set; }


        public ICollection<Factura> Facturas { get; set; }
        public ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
