using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IVehiculoRepository : IGenericRepository<Vehiculo>
    {
        #region Declaración
        List<Vehiculo> GetVehiculos(int idEmpresa);
        void Update(Vehiculo obj);
        void Insert(Vehiculo obj);
        #endregion
    }
}
