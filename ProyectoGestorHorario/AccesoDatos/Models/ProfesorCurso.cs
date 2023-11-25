using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class ProfesorCurso
{
    public int? Id { get; set; }

    public string IdCurso { get; set; } = null!;

    public string IdProfesor { get; set; } = null!;

    public int Grupo { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; } = null!;

    public virtual Profesor? IdProfesorNavigation { get; set; } = null!;
}
