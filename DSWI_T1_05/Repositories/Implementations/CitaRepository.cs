using DSWI_T1_05.Data;
using DSWI_T1_05.Models.ViewModels.Citas;
using DSWI_T1_05.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_05.Repositories.Implementations
{
    public class CitaRepository : ICitaRepository
    {
        private readonly ClinicaBDContext _context;

        public CitaRepository(ClinicaBDContext context)
        {
            _context = context;
        }

        // Listar todas las citas
        public async Task<IEnumerable<Cita>> ObtenerTodasAsync()
        {
            return await _context.Citas
                .FromSqlRaw("EXEC dbo.usp_Citas_Listar")
                .AsNoTracking()
                .ToListAsync();
        }

        // Obtener una cita por ID
        public async Task<Cita?> ObtenerPorIdAsync(int id)
        {
            return await _context.Citas
                .FromSqlInterpolated(
                    $"EXEC dbo.usp_Citas_ObtenerPorId @CitaID = {id}"
                )
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task CrearAsync(Cita cita)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC dbo.usp_Citas_Crear @Fecha={cita.Fecha}, @Hora={cita.Hora}, @Especialidad={cita.Especialidad}, @Estado={cita.Estado}, @PacienteID={cita.PacienteId}"
            );
        }

        public async Task EditarAsync(Cita cita)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC dbo.usp_Citas_Editar @CitaID={cita.CitaId}, @Fecha={cita.Fecha}, @Hora={cita.Hora}, @Especialidad={cita.Especialidad}, @Estado={cita.Estado}, @PacienteID={cita.PacienteId}"
            );
        }
    }
}
