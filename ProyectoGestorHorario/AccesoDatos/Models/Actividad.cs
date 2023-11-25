using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Actividad
{
    public int Id { get; set; }

    public int Dia { get; set; }

    public int HoraEntrada { get; set; }

    public int HoraSalida { get; set; }

    public string IdEncargado { get; set; } = null!;

    public int Espacio { get; set; }

    public virtual Espacio EspacioNavigation { get; set; } = null!;

    public virtual Profesor IdEncargadoNavigation { get; set; } = null!;
}
