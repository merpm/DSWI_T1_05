using DSWI_T1_05.Models.ViewModels.Pacientes;

namespace DSWI_T1_05.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> ObtenerTodosAsync();
        Task<Paciente?> ObtenerPorIdAsync(int id);
    }
}
