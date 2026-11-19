
using DSWI_T1_05.DTOs;
using DSWI_T1_05.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_05.Controllers
{
    public class CitasController : Controller
    {
        private readonly ICitaService _citaService;
        private readonly IPacienteService _pacienteService;

        public CitasController(
            ICitaService citaService,
            IPacienteService pacienteService)
        {
            _citaService = citaService;
            _pacienteService = pacienteService;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var citas = await _citaService.ObtenerTodasAsync();

            return View(citas);
        }

        // GET: Citas/Create
        public async Task<IActionResult> Create()
        {
            await CargarPacientesAsync();

            return View();
        }

        // POST: Citas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CitaDto cita)
        {
            if (!ModelState.IsValid)
            {
                await CargarPacientesAsync();
                return View(cita);
            }

            await _citaService.CrearAsync(cita);

            return RedirectToAction(nameof(Index));
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cita = await _citaService.ObtenerPorIdAsync(id);

            if (cita == null)
            {
                return NotFound();
            }

            await CargarPacientesAsync();

            return View(cita);
        }

        // POST: Citas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CitaDto cita)
        {
            if (id != cita.CitaId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                await CargarPacientesAsync();
                return View(cita);
            }

            var existente = await _citaService.ObtenerPorIdAsync(id);

            if (existente == null)
            {
                return NotFound();
            }

            await _citaService.EditarAsync(cita);

            return RedirectToAction(nameof(Index));
        }

        // Cargar pacientes para el desplegable
        private async Task CargarPacientesAsync()
        {
            ViewBag.Pacientes = await _pacienteService.ObtenerTodosAsync();
        }
    }
}
