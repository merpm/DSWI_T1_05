
using DSWI_T1_05.Models.ViewModels.Citas;

namespace DSWI_T1_05.Repositories.Interfaces
{
    public interface ICitaRepository
    {
        Task<IEnumerable<Cita>> ObtenerTodasAsync();

        Task<Cita?> ObtenerPorIdAsync(int id);

        Task CrearAsync(Cita cita);

        Task EditarAsync(Cita cita);
    }
}
