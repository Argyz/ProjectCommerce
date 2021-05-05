using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IRepositorio<T> where T : EntidadBase
    {
        //persistencia de datos
        long Insertar(T entidad);

        void Eliminar(long entidadId);

        void Modificar(T entidad);

        //Lectura de datos

        T Obtener(long Id, string propiedadesNavegacion="");

        IEnumerable<T> Obtener(Expression<Func<T,bool>> predicado, string propiedadesNavegacion="");


    }
}
