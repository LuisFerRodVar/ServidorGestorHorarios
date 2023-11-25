using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class HorarioAsignado
{
    public int? Id { get; set; }
    public int IdGrupo { get; set; }

    public int Dia { get; set; }

    public int Espacio { get; set; }

    public int HoraEntrada { get; set; }

    public int HoraSalida { get; set; }

    public virtual Espacio? EspacioNavigation { get; set; } = null!;

    public virtual ProfesorCurso? IdGrupoNavigation { get; set; } = null!;
}
