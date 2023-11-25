using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class CursoDAO
    {
        public SistemaContext contexto = new SistemaContext();

        public List<Curso> obtenerCursos()
        {
            var cursos = contexto.Cursos.ToList();
            return cursos;
        }

        public Curso seleccionarCurso(string id)
        {
            var curso = contexto.Cursos.Where(c=> c.Id == id).FirstOrDefault();
            return curso;
        }

        public bool agregarCurso(string id, string nombre, string carrera, int ciclo)
        {
            try
            {
                Curso curso = new Curso();
                curso.Id = id;
                curso.Nombre = nombre;
                curso.Carrera = carrera;
                curso.Ciclo = ciclo;
                contexto.Cursos.Add(curso);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarCurso(string id)
        {
            try
            {
                var curso = seleccionarCurso(id);
                contexto.Cursos.Remove(curso);
                contexto.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool actualizarCurso(string id, string nombre, string carrera, int ciclo)
        {
            try
            {
                var curso = seleccionarCurso(id);
                if(curso == null)
                {
                    return false;
                }
                curso.Nombre = nombre;
                curso.Carrera=carrera;
                curso.Ciclo=ciclo;
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
        public List<ProfesorCurso> obtenerGrupos(string id)
        {
           return contexto.ProfesorCursos.Where(pc => pc.IdCurso == id).ToList();
        }
        public ProfesorCurso getGrupo(int id)
        {
            var grupo = contexto.ProfesorCursos.Where(pc => pc.Id == id).FirstOrDefault();
            return grupo;
        }
        public bool agregarGrupo(string idCurso, string idProfesor, int grupo)
        {
            try
            {
                var grupos = new ProfesorCurso();
                grupos.IdCurso = idCurso;
                grupos.IdProfesor = idProfesor;
                grupos.Grupo = grupo;
                contexto.ProfesorCursos.Add(grupos);
                contexto.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarGrupo(int id)
        {
            try
            {
                var grupo = getGrupo(id);
                if(grupo == null)
                {
                    return false;
                }
                contexto.ProfesorCursos.Remove(grupo);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
