
using DSWI_T1_05.DTOs;
using DSWI_T1_05.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_05.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteService.ObtenerTodosAsync();

            return View(pacientes);
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var paciente = await _pacienteService.ObtenerPorIdAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PacienteDto paciente)
        {
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }

            await _pacienteService.CrearAsync(paciente);

            return RedirectToAction(nameof(Index));
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var paciente = await _pacienteService.ObtenerPorIdAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PacienteDto paciente)
        {
            if (id != paciente.PacienteId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(paciente);
            }

            var existe = await _pacienteService.ObtenerPorIdAsync(id);

            if (existe == null)
            {
                return NotFound();
            }

            await _pacienteService.EditarAsync(paciente);

            return RedirectToAction(nameof(Index));
        }
    }
}
