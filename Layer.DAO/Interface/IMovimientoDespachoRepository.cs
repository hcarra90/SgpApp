using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.DAO.Interface
{
    public interface IMovimientoDespachoRepository : IGenericRepository<MovimientoDespacho>
    {
        #region Declaración
        List<MovimientoDespachoDto> GetMovimientoDespacho(int idEmpresa);
        MovimientoDespachoDto GetMovimientoDespachoById(int idProgramaExport);
        int GetFolioTarja();
        int GetFolioPallet();
        void Update(MovimientoDespacho obj);
        void Insert(MovimientoDespacho obj);
        #endregion
    }
}
