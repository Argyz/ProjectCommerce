using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorio;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace DataAccess.Repositorio
{
    public class Repo<T> : IRepositorio<T> where T : EntidadBase
    {
        private readonly DataContext context;
        public Repo(DataContext context)
        {
            this.context = context;
        }
        public void Eliminar(long entidadId)
        {
            var entidadEliminar = context.Set<T>().FirstOrDefault(x => x.Id == entidadId);
            if (entidadEliminar==null)
            {
                throw new Exception();
            }

            entidadEliminar.EstaEliminado = !entidadEliminar.EstaEliminado;
        }

        public long Insertar(T entidad)
        {
            if (entidad == null)
            {
                throw new Exception();
            }

            context.Set<T>().Add(entidad);

            return entidad.Id;
        }

        public void Modificar(T entidad)
        {
            if (entidad == null)
            {
                throw new Exception();
            }

            context.Set<T>().Attach(entidad);

            context.Entry(entidad).State = EntityState.Modified;

        }

        public T Obtener(long Id, string propiedadesNavegacion)
        {
            var resultado = propiedadesNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string,IQueryable<T>>(context.Set<T>(),(current,include)=>current);

            return resultado.FirstOrDefault(x=>x.Id==Id);
        }

        public IEnumerable<T> Obtener(Expression<Func<T, bool>> predicado, string propiedadesNavegacion = "")
        {
            var contexto = ((IObjectContextAdapter)context).ObjectContext;

            var cliente = contexto.CreateObjectSet<T>();

            contexto.Refresh(RefreshMode.ClientWins,cliente);

            var resultado = propiedadesNavegacion.Split(new[] {','},StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string,IQueryable<T>>(context.Set<T>(),(current,include)=>current.Include(include));
        }
    }
}
