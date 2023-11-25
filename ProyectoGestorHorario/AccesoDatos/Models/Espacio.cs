using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Espacio
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Capacidad { get; set; }

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();
}
