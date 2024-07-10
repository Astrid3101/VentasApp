using System.ComponentModel.DataAnnotations;

namespace VentasApp.Models
{
    public class TipoCambio
    {
        public int IdTipo { get; set; }
        public string Moneda { get; set; }
        public decimal Cambio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
