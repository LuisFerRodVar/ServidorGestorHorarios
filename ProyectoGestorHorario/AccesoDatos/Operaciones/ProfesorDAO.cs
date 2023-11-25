using AccesoDatos.Context;
using AccesoDatos.Models;

namespace AccesoDatos.Operaciones
{
    public class ProfesorDAO
    {
        public SistemaContext contexto = new SistemaContext();

        public string login(string correo, string contrasenia)
        {

            var autenticacion = contexto.Profesors.Where(p => p.Correo == correo && p.Contrasenia == contrasenia).FirstOrDefault();
            if(autenticacion == null)
            {
                return null;
            }
            return autenticacion.Id;
        }
        public List<Profesor> getProfesores()
        {
            return contexto.Profesors.ToList();
        }
        public bool agregarProfesor(string id, string nombre, string apellido, string correo, string contrasenia)
        {
            try
            {
                Profesor prof = new Profesor();
                prof.Id = id;
                prof.Correo = correo;
                prof.Nombre = nombre;
                prof.Apellidos = apellido;
                prof.Contrasenia = contrasenia;
                contexto.Profesors.Add(prof);
                contexto.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }
        public Profesor obtenerProfesor(string id)
        {
            var prof = contexto.Profesors.Where(p => p.Id == id).FirstOrDefault();
            return prof;
        }
        public bool eliminarProfesor(string id)
        {
            try
            {
                var prof = obtenerProfesor(id);
                if(prof == null)
                {
                    return false;
                }
                contexto.Remove(prof);
                contexto.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarHorario(int idGrupo)
        {
            try
            {
                var horario = contexto.HorarioAsignados.Where(ha => ha.IdGrupo == idGrupo).ToList();
                if(horario == null)
                {
                    return false;
                }
                contexto.Remove(horario);
                contexto.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarGrupo(int id)
        {
            try
            {
                var grupo = contexto.ProfesorCursos.Where(pc => pc.Id == id).ToList();
                if(grupo == null)
                {
                    return false;
                }
                contexto.Remove(grupo);
                contexto.SaveChanges(); 
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool editarProfesor(string id, string nombre, string apellidos, string correo, string contrasenia)
        {
            var prof = obtenerProfesor(id);
            if(prof == null)
            {
                return false;

            }
            else
            {
                prof.Nombre = nombre;
                prof.Apellidos = apellidos;
                prof.Correo = correo;
                prof.Contrasenia = contrasenia;
                contexto.SaveChanges();
                return true;
            }
        }
        public List<ProfesorCurso> obtenerGrupos(string id)
        {
            var grupos = contexto.ProfesorCursos.Where(pc => pc.IdProfesor == id).ToList();
            return grupos;
        }
        public bool agregarHorario(int idGrupo, int dia, int idEspacio, int horaEntrada, int horaSalida)
        {
            try
            {
                var horario = new HorarioAsignado();
                horario.IdGrupo = idGrupo;
                horario.Dia = dia;
                horario.Espacio = idEspacio;
                horario.HoraEntrada = horaEntrada;
                horario.HoraSalida = horaSalida;

                contexto.HorarioAsignados.Add(horario);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
                

        }
        public List<Horario> obtenerHorarios(string idProfesor)
        {
            var query = from pc in contexto.ProfesorCursos
                        join ha in contexto.HorarioAsignados on pc.Id equals ha.IdGrupo
                        where pc.IdProfesor == idProfesor
                        select new Horario
                        {
                            idCurso = pc.IdCurso,
                            espacio = ha.Espacio,
                            dia = ha.Dia,
                            horaEntrada = ha.HoraEntrada,
                            horaSalida = ha.HoraSalida,
                            grupo = pc.Grupo
                        };
            return query.ToList();
        }
    }
}
