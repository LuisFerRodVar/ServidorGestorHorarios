using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Profesor
{
    public string? Id { get; set; } = null!;

    public string? Nombre { get; set; } = null!;

    public string? Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();

    public virtual ICollection<ProfesorCurso> ProfesorCursos { get; set; } = new List<ProfesorCurso>();
}
