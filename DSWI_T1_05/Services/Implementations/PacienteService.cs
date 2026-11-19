
using DSWI_T1_05.DTOs;
using DSWI_T1_05.Models.ViewModels.Pacientes;
using DSWI_T1_05.Repositories.Interfaces;
using DSWI_T1_05.Services.Interfaces;

namespace DSWI_T1_05.Services.Implementations
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<PacienteDto>> ObtenerTodosAsync()
        {
            var pacientes = await _pacienteRepository.ObtenerTodosAsync();

            return pacientes.Select(p => new PacienteDto
            {
                PacienteId = p.PacienteId,
                Nombre = p.Nombre,
                Dni = p.Dni
            }).ToList();
        }

        public async Task<PacienteDto?> ObtenerPorIdAsync(int id)
        {
            var paciente = await _pacienteRepository.ObtenerPorIdAsync(id);

            if (paciente == null)
            {
                return null;
            }

            return new PacienteDto
            {
                PacienteId = paciente.PacienteId,
                Nombre = paciente.Nombre,
                Dni = paciente.Dni
            };
        }

        public async Task CrearAsync(PacienteDto paciente)
        {
            var entidad = new Paciente
            {
                Nombre = paciente.Nombre,
                Dni = paciente.Dni
            };

            await _pacienteRepository.CrearAsync(entidad);
        }

        public async Task EditarAsync(PacienteDto paciente)
        {
            var entidad = new Paciente
            {
                PacienteId = paciente.PacienteId,
                Nombre = paciente.Nombre,
                Dni = paciente.Dni
            };

            await _pacienteRepository.EditarAsync(entidad);
        }
    }
}
