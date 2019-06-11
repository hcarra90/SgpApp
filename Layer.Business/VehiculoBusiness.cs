using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using System.Collections.Generic;

namespace Layer.Business
{
    public static class VehiculoBusiness
    {
        #region Declaración
        static readonly IVehiculoRepository repository = new VehiculoRepository();
        #endregion

        #region Métodos Publicos
        public static List<Vehiculo> GetVehiculos(int idEmpresa)
        {
            return repository.GetVehiculos(idEmpresa);
        }

        public static void Insert(Vehiculo obj)
        {
            repository.Insert(obj);
        }

        public static void Update(Vehiculo obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
