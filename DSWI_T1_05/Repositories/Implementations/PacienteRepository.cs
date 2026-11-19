
using DSWI_T1_05.Data;
using DSWI_T1_05.Models.ViewModels.Pacientes;
using DSWI_T1_05.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_05.Repositories.Implementations
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ClinicaBDContext _context;

        public PacienteRepository(ClinicaBDContext context)
        {
            _context = context;
        }

        // Listar todos los pacientes
        public async Task<IEnumerable<Paciente>> ObtenerTodosAsync()
        {
            return await _context.Pacientes.FromSqlRaw("EXEC dbo.usp_Pacientes_Listar").AsNoTracking().ToListAsync();
        }

        // Obtener paciente por ID
        public async Task<Paciente?> ObtenerPorIdAsync(int id)
        {
            return await _context.Pacientes.FromSqlInterpolated($"EXEC dbo.usp_Pacientes_ObtenerPorId @PacienteID = {id}").AsNoTracking().FirstOrDefaultAsync();
        }

        // Registrar paciente
        public async Task CrearAsync(Paciente paciente)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC dbo.usp_Pacientes_Crear @Nombre={paciente.Nombre}, @DNI={paciente.Dni}");
        }

        // Editar paciente
        public async Task EditarAsync(Paciente paciente)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC dbo.usp_Pacientes_Editar @PacienteID={paciente.PacienteId}, @Nombre={paciente.Nombre}, @DNI={paciente.Dni}");
        }
    }
}
