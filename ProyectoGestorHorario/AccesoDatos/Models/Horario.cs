using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class Horario
    {
        public string idCurso { get; set; }
        public int espacio { get; set; }
        public int grupo { get; set; }
        public int dia { get; set; }
        public int horaEntrada { get; set; }
        public int horaSalida { get; set; }


    }
}
