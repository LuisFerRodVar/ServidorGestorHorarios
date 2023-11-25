using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Curso
{
    public string Id { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Carrera { get; set; } = null!;

    public int Ciclo { get; set; }

    public virtual ICollection<ProfesorCurso> ProfesorCursos { get; set; } = new List<ProfesorCurso>();
}
