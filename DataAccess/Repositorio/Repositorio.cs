using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using Dominio.Entidades;
using System.Linq.Expressions;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace DataAccess.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T: EntidadBase
    {
        private DataContext _context;
        
        
        public Repositorio(DataContext context)
        {
            _context = context;
        }


        public void Eliminar(long entidadId)
        {
            
            var entidadaEliminar = _context.Set<T>()
                .FirstOrDefault(x => x.Id == entidadId);

            if (entidadaEliminar == null)
            {
                throw new Exception(message: "Oops hubo un error por que la entidad a Eliminar es nula");
            }

            entidadaEliminar.EstaEliminado = !entidadaEliminar.EstaEliminado;
        }

        public long Insertar(T entidad)
        {
            
            if (entidad == null)
            {
                throw new Exception(message: "Oops hubo un error por que la entidad a Agregar es nula");
            }

            _context.Set<T>().Add(entidad);

            return entidad.Id;
        }
        
        public void Modificar(T entidad)
        {
            if (entidad == null)
            {
                throw new Exception(message: "Oops hubo un error por que la entidad a modificar es nula");
            }

            _context.Set<T>().Attach(entidad);

            _context.Entry(entidad).State = EntityState.Modified;

        }

        public T Obtener(long Id, string propiedadesNavegacion="")
        {
            //departamentos, Departamentos.Localidades, Despartamentos.Localidades.Personas
            //esto es lo q me puede llegar por el parametro propiedadesNavegacion

            var resultado = propiedadesNavegacion.Split(new[] { ',' },StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string,IQueryable<T>>(_context.Set<T>(),(current,include) => current.Include(include));

            return resultado.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<T> Obtener(Expression<Func<T, bool>> predicado = null, string propiedadesNavegacion = "")
        {
            var context = ((IObjectContextAdapter) _context).ObjectContext;

            var resultadoCliente = context.CreateObjectSet<T>();

            context.Refresh(RefreshMode.ClientWins, resultadoCliente);

            var resultado = propiedadesNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<T>>(_context.Set<T>(), (current, include) => current.Include(include));

            if (predicado != null)
            {
                resultado = resultado.Where(predicado);
            }

            return resultado.ToList();
        }
    }
}
