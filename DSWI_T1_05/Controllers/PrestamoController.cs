// Archivo inicial. Implementacion pendiente.

using Microsoft.AspNetCore.Mvc;
using DSWI_T1_05.Models.Results;
using DSWI_T1_05.ViewModels.Prestamo;

namespace DSWI_T1_05.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo/Index
        // Muestra el formulario para ingresar el prestamo
        [HttpGet]
        public IActionResult Index()
        {
            var modelo = new CalcularPrestamoViewModel();

            return View(modelo);
        }

        // POST: Prestamo/Index
        // Recibe el monto y realiza los calculos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CalcularPrestamoViewModel modelo)
        {
            // Validar los datos ingresados
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            decimal montoPrestamo = modelo.MontoPrestamo.Value;

            int cantidadCuotas;
            decimal porcentajeInteres;

            // 1. Determinar la cantidad de cuotas
            if (montoPrestamo > 5000)
            {
                cantidadCuotas = 3;
            }
            else if (montoPrestamo < 1000)
            {
                cantidadCuotas = 1;
            }
            else if (montoPrestamo >= 2000 && montoPrestamo <= 3000)
            {
                cantidadCuotas = 2;
            }
            else
            {
                cantidadCuotas = 5;
            }

            // 2. Determinar el porcentaje de interes
            if (montoPrestamo < 4000)
            {
                porcentajeInteres = 0.12m;
            }
            else
            {
                porcentajeInteres = 0.10m;
            }

            // 3. Calcular el importe del interes
            decimal montoInteres = montoPrestamo * porcentajeInteres;

            // 4. Calcular la deuda total
            decimal deudaTotal = montoPrestamo + montoInteres;

            // 5. Calcular el valor de cada cuota
            decimal valorCuota = deudaTotal / cantidadCuotas;

            // 6. Guardar los resultados en el Model
            modelo.Resultado = new PrestamoResultado
            {
                MontoPrestamo = montoPrestamo,
                PorcentajeInteres = porcentajeInteres,
                MontoInteres = montoInteres,
                DeudaTotal = deudaTotal,
                CantidadCuotas = cantidadCuotas,
                ValorCuota = valorCuota
            };

            // 7. Enviar los resultados a la vista
            return View(modelo);
        }
    }
}
