using DataAccess.Repositorio;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UoW
{
    public class UoW : IUoW
    {
        private readonly DataContext _context;
        public UoW(DataContext dataContext)//a esto o crea el inyector de dependencia
        {
            _context = dataContext;
        }

        
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Disposed()
        {
            //Destruye el objeto context
            _context.Dispose();
        }
        
        //============================================================================================

        private IRepositorio<Provincia> provinciaRepositorio;

        public IRepositorio<Provincia> ProvinciaRepositorio => provinciaRepositorio ?? (provinciaRepositorio = new Repositorio<Provincia>(_context));


        //============================================================================================

        private IRepositorio<Localidad> localidadRepositorio;

        public IRepositorio<Localidad> LocalidadRepositorio {
            get
            {
                if (localidadRepositorio == null)
                {
                    localidadRepositorio = new Repositorio<Localidad>(_context);
                }

                return localidadRepositorio;
            }
        }

        //============================================================================================
    }
}
