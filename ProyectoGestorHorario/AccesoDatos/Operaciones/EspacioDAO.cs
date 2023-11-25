using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class EspacioDAO
    {
        public SistemaContext contexto = new SistemaContext();

        public Espacio seleccionarEspacio(int id)
        {
            var espacio = contexto.Espacios.Where(e => e.Id == id).FirstOrDefault();
            return espacio;
        }
        public bool agregarEspacio(int id, string descripcion, int capacidad)
        {
            try
            {
                var espacio = new Espacio();
                espacio.Id = id;
                espacio.Descripcion = descripcion;
                espacio.Capacidad = capacidad;
                contexto.Espacios.Add(espacio);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarEspacio(int id)
        {
            try
            {
                var espacio = seleccionarEspacio(id);
                if(espacio == null)
                {
                    return false;
                }
                contexto.Espacios.Remove(espacio);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool actualizarEspacio(int id, string descripcion, int capacidad)
        {
            try
            {
                var espacio = seleccionarEspacio(id);
                if(espacio == null)
                {
                    return false;
                }
                espacio.Descripcion = descripcion;
                espacio.Capacidad = capacidad;
                contexto.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }
        public List<Espacio> obtenerEspacios()
        {
            return contexto.Espacios.ToList();
        }
        public List<Horario> obtenerHorarios(int id)
        {
            var query = from pc in contexto.ProfesorCursos
                        join ha in contexto.HorarioAsignados on pc.Id equals ha.IdGrupo
                        where ha.Espacio == id
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
