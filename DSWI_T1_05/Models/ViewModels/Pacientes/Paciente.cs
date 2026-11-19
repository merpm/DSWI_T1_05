using DSWI_T1_05.Models.ViewModels.Citas;
using System;
using System.Collections.Generic;

namespace DSWI_T1_05.Models.ViewModels.Pacientes;

public partial class Paciente
{
    public int PacienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Dni { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
