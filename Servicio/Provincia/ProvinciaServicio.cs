using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using IServicio.DTOs;
using IServicio.Provincia;
using Dominio.UoW;

namespace Servicio.Provincia
{
    public class ProvinciaServicio : IProvinciaServicio
    {
        private readonly IUoW unidad;
        public ProvinciaServicio(IUoW unidad)
        {
            this.unidad = unidad;
        }
        
        public void Eliminar(long id)
        {
            unidad.ProvinciaRepositorio.Eliminar(id);
            unidad.Commit();
        }

        public void Insertar(ProvinciaDTOs dto)
        {
            var entidad = new Dominio.Entidades.Provincia()
            {

                Descripcion = dto.Descripcion,
                EstaEliminado = false,
            };

            unidad.ProvinciaRepositorio.Insertar(entidad);
            unidad.Commit();
        }

        public void Modificar(ProvinciaDTOs dto)
        {
            var entidad = new Dominio.Entidades.Provincia()
            {
                Id = dto.Id,
                Descripcion = dto.Descripcion,
            };

            unidad.ProvinciaRepositorio.Modificar(entidad);
            unidad.Commit();

        }

        public ProvinciaDTOs Obtener(long id)
        {
            var entidad = unidad.ProvinciaRepositorio.Obtener(id);

            return new ProvinciaDTOs()
            {
                Id = entidad.Id,
                EstaEliminado = entidad.EstaEliminado,
                Descripcion = entidad.Descripcion,
            };
        }

        public IEnumerable<ProvinciaDTOs> Obtener(string cadenaBuscar)
        {
            return unidad.ProvinciaRepositorio.Obtener(x => x.Descripcion.Contains(cadenaBuscar)).Select(x => new ProvinciaDTOs(){
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion
            });
        }
    }
}

