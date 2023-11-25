using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        public CursoDAO cursoDAO = new CursoDAO();
        [HttpGet("cursos")]
        public List<Curso> obtenerCursos()
        {
            return cursoDAO.obtenerCursos();

        }
        [HttpGet("curso")]
        public Curso getCurso(string id) 
        {
            return cursoDAO.seleccionarCurso(id);
        }
        [HttpPost("curso")]
        public bool agregarCurso([FromBody] Curso curso)
        {
            return cursoDAO.agregarCurso(curso.Id, curso.Nombre, curso.Carrera, curso.Ciclo);
        }

        [HttpDelete("curso")]
        public bool eliminarCurso(string id)
        {
            return cursoDAO.eliminarCurso(id);
        }
        [HttpPut("curso")]
        public bool actualizarCurso([FromBody] Curso curso)
        {
            return cursoDAO.actualizarCurso(curso.Id, curso.Nombre, curso.Carrera, curso.Ciclo);
        }
        [HttpGet("grupos")]
        public List<ProfesorCurso> obtenerGrupos(string id)
        {
            return cursoDAO.obtenerGrupos(id);
        }
        [HttpPost("grupo")]
        public bool agregarGrupo([FromBody] ProfesorCurso grupo)
        {
            return cursoDAO.agregarGrupo(grupo.IdCurso, grupo.IdProfesor, grupo.Grupo);
        }
        [HttpDelete("grupo")]
        public bool eliminarGrupo(int id)
        {
            return cursoDAO.eliminarGrupo(id);
        }

    }
}
