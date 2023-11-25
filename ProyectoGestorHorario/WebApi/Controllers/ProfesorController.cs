using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        public ProfesorDAO profesorDAO = new ProfesorDAO();
        [HttpPost("profesor")]
        public string login([FromBody] Profesor prof)
        {
            return profesorDAO.login(prof.Correo, prof.Contrasenia);
        }
        [HttpGet("profesor")]
        public List<Profesor> getProfesores()
        {
            return profesorDAO.getProfesores();
        }
        [HttpPost("profesores")]
        public bool agregarProfesor([FromBody] Profesor prof)
        {
            return profesorDAO.agregarProfesor(prof.Id, prof.Nombre, prof.Apellidos, prof.Correo, prof.Contrasenia);
        }
        [HttpDelete("profesor")]
        public bool eliminarProfesor(string id)
        {
            return profesorDAO.eliminarProfesor(id);
        }
        [HttpPut("profesor")]
        public bool editarProfesor([FromBody] Profesor prof)
        {
            return profesorDAO.editarProfesor(prof.Id, prof.Nombre, prof.Apellidos, prof.Correo, prof.Contrasenia);
        }
        [HttpGet("prof")]
        public Profesor obtenerProfesor(string id)
        {

            return profesorDAO.obtenerProfesor(id);
        }
        [HttpGet("grupoProf")]
        public List<ProfesorCurso> obtenerCursos(string id)
        {
            return profesorDAO.obtenerGrupos(id);
        }
        [HttpPost("grupoProf")]
        public bool agregarHorario([FromBody] HorarioAsignado horario)
        {
            return profesorDAO.agregarHorario(horario.IdGrupo, horario.Dia, horario.Espacio, horario.HoraEntrada, horario.HoraSalida);
        }
        [HttpGet("horario")]
        public List<Horario> getHorarios(string id)
        {
            return profesorDAO.obtenerHorarios(id);
        }
    }
}
