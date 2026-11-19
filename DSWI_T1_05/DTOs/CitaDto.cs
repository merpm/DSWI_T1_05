namespace DSWI_T1_05.DTOs
{
    public class CitaDto
    {
        public int CitaId { get; set; }
        public DateOnly? Fecha { get; set; }
        public TimeOnly? Hora { get; set; }
        public string? Especialidad { get; set; }
        public string? Estado { get; set; }
        public int? PacienteId { get; set; }
        public string? NombrePaciente { get; set; }
    }
}
