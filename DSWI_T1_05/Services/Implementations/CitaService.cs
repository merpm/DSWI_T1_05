
using DSWI_T1_05.DTOs;
using DSWI_T1_05.Models.ViewModels.Citas;
using DSWI_T1_05.Repositories.Interfaces;
using DSWI_T1_05.Services.Interfaces;

namespace DSWI_T1_05.Services.Implementations
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;

        public CitaService(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        public async Task<IEnumerable<CitaDto>> ObtenerTodasAsync()
        {
            var citas = await _citaRepository.ObtenerTodasAsync();

            return citas.Select(c => new CitaDto
            {
                CitaId = c.CitaId,
                Fecha = c.Fecha,
                Hora = c.Hora,
                Especialidad = c.Especialidad,
                Estado = c.Estado,
                PacienteId = c.PacienteId,
                NombrePaciente = c.Paciente?.Nombre
            }).ToList();
        }

        public async Task<CitaDto?> ObtenerPorIdAsync(int id)
        {
            var cita = await _citaRepository.ObtenerPorIdAsync(id);

            if (cita == null)
            {
                return null;
            }

            return new CitaDto
            {
                CitaId = cita.CitaId,
                Fecha = cita.Fecha,
                Hora = cita.Hora,
                Especialidad = cita.Especialidad,
                Estado = cita.Estado,
                PacienteId = cita.PacienteId,
                NombrePaciente = cita.Paciente?.Nombre
            };
        }

        public async Task CrearAsync(CitaDto cita)
        {
            var entidad = new Cita
            {
                Fecha = cita.Fecha,
                Hora = cita.Hora,
                Especialidad = cita.Especialidad,
                Estado = cita.Estado,
                PacienteId = cita.PacienteId
            };

            await _citaRepository.CrearAsync(entidad);
        }

        public async Task EditarAsync(CitaDto cita)
        {
            var entidad = new Cita
            {
                CitaId = cita.CitaId,
                Fecha = cita.Fecha,
                Hora = cita.Hora,
                Especialidad = cita.Especialidad,
                Estado = cita.Estado,
                PacienteId = cita.PacienteId
            };

            await _citaRepository.EditarAsync(entidad);
        }
    }
}
