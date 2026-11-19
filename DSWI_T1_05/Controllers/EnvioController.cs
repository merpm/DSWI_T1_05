
using Microsoft.AspNetCore.Mvc;
using DSWI_T1_05.Models.ViewModels.Envio;

namespace DSWI_T1_05.Controllers
{
    public class EnvioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalcularEnvioViewModel());
        }

        [HttpPost]
        public IActionResult Index(CalcularEnvioViewModel modelo)
        {
            if (modelo.Peso <= 0)
            {
                ModelState.AddModelError("Peso",
                    "El peso debe ser mayor a cero.");

                return View(modelo);
            }

            if (modelo.Peso > 50)
            {
                modelo.PrecioKilo = 2.50m;
            }
            else if (modelo.Peso < 5)
            {
                modelo.PrecioKilo = 4.00m;
            }
            else if (modelo.Peso >= 10 && modelo.Peso <= 20)
            {
                modelo.PrecioKilo = 3.00m;
            }
            else
            {
                modelo.PrecioKilo = 3.50m;
            }

            decimal recargo = modelo.Internacional ? 15m : 0m;

            modelo.Total = (modelo.Peso * modelo.PrecioKilo)
                           + recargo;

            ViewBag.Resultado = true;

            return View(modelo);
        }
    }
}

