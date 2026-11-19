
using System.ComponentModel.DataAnnotations;
using DSWI_T1_05.Models.Results;

namespace DSWI_T1_05.ViewModels.Prestamo
{
    public class CalcularPrestamoViewModel
    {
        [Required(ErrorMessage = "Ingrese el monto del prestamo.")]
        [Range(0.01, 999999999, ErrorMessage = "El monto debe ser mayor que cero.")]
        [Display(Name = "Monto del prestamo")]
        public decimal? MontoPrestamo { get; set; }

        // Aqui guardaremos el resultado del calculo
        public PrestamoResultado? Resultado { get; set; }
    }
}
