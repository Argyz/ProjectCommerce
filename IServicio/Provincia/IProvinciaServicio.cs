using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServicio.DTOs;

namespace IServicio.Provincia
{
    public interface IProvinciaServicio
    {
        void Insertar(ProvinciaDTOs dto);
        void Eliminar(long id);
        void Modificar(ProvinciaDTOs dto);
        IEnumerable<ProvinciaDTOs> Obtener(string cadenaBuscar);
        ProvinciaDTOs Obtener(long id);

    }
}
