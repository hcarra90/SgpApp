using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public static class PuertoBusiness
    {
        #region -----Declaración-----
        static readonly IPuertoRepository repository = new PuertoRepository();
        #endregion

        #region -----Métodos Publicos-----
        public static List<Puerto> GetPuerto(int idEmpresa)
        {
            return repository.GetPuerto(idEmpresa);
        }

        public static List<Puerto> GetPuertoByPais(int idEmpresa,int idPais)
        {
            var data = repository.GetPuerto(idEmpresa);
            data = data.Where(p => p.id_pais == idPais).ToList();
            data.Insert(0, new Puerto {Id=0,Nombre="" });

            return data;
        }

        public static List<PuertoDto> GetPuertoByShipTo(string shipTo)
        {
            var data = repository.GetPuertoByShipTo(shipTo);

            return data;
        }

        public static void Insert(Puerto obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Puerto obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
