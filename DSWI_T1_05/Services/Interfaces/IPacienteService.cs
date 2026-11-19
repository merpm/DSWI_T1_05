using DSWI_T1_05.DTOs;

namespace DSWI_T1_05.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> ObtenerTodosAsync();
        Task<PacienteDto?> ObtenerPorIdAsync(int id);
    }
}
