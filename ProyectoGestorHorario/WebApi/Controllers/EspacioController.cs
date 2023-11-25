using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class EspacioController : ControllerBase
    {
        public EspacioDAO espacioDAO = new EspacioDAO();
        [HttpGet("espacios")]
        public List<Espacio> getEspacios()
        {
            return espacioDAO.obtenerEspacios();
        }
        [HttpGet("espacio")]
        public Espacio obtenerEspacio(int id)
        {
            return espacioDAO.seleccionarEspacio(id);
        }
        [HttpPost("espacio")]
        public bool agregarEspacio([FromBody] Espacio espacio)
        {
            return espacioDAO.agregarEspacio(espacio.Id, espacio.Descripcion, espacio.Capacidad);
        }
        [HttpDelete("espacio")]
        public bool eliminarEspacio(int id)
        {
            return espacioDAO.eliminarEspacio(id);
        }
        [HttpPut("espacio")]
        public bool actualizarEspacio([FromBody] Espacio espacio)
        {
            return espacioDAO.actualizarEspacio(espacio.Id,espacio.Descripcion,espacio.Capacidad);
        }
        [HttpGet("horarioEspacio")]
        public List<Horario> obtenerHorarios(int id)
        {
            return espacioDAO.obtenerHorarios(id);
        }
    }
}
