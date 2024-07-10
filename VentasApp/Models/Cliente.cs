using System.ComponentModel.DataAnnotations;

namespace VentasApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }  
    }
}
