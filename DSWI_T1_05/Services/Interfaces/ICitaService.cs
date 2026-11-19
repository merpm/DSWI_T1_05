
using DSWI_T1_05.DTOs;

namespace DSWI_T1_05.Services.Interfaces
{
    public interface ICitaService
    {
        Task<IEnumerable<CitaDto>> ObtenerTodasAsync();

        Task<CitaDto?> ObtenerPorIdAsync(int id);

        Task CrearAsync(CitaDto cita);

        Task EditarAsync(CitaDto cita);
    }
}
