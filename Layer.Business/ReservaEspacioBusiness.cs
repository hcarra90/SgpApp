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
    public static class ReservaEspacioBusiness
    {
        #region Declaración
        static readonly IReservaEspacioRepository repository = new ReservaEspacioRepository();
        #endregion

        #region Métodos Publicos
        public static List<ReservaEspacioDto> GetReservaEspacio(int idEmpresa, DateTime fecha, DateTime fechaFin)
        {
            var data = repository.GetReservaEspacio(idEmpresa, fecha,fechaFin);
            return data;
        }

        public static void Insert(ReservaEspacio obj)
        {
            repository.Insert(obj);
        }

        public static void Update(ReservaEspacio obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
