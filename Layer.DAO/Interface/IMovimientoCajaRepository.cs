using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del MovimientoCaja
    /// </summary>
    public interface IMovimientoCajaRepository : IGenericRepository<MovimientoCaja>
    {
        #region Declaración
        MovimientoCaja GetCaja(string cajaEnvio);
        CajaEnvioDto GetNumeroCaja(string shipTo);
        List<CajaEnvioDto> GetCajasByShipTo(string shipTo);
        CajaEnvioDto GetCorrelativoEnvio(int anio);
        List<MovimientoCaja> GetEnviosByFecha(DateTime fechaEnvio);
        List<EncPackingListDto> GetCajasByshipmentCode(string shipmentCode);
        List<ListaShipmentCodeDto> GetshipmentsCode();
        List<DetailPackingListDto> GetDetailsByshipmentCode(string shipmentCode);
        List<EnvioCajaDto> GetDataByEuid(string cadena, string opcion);
        void Insert(MovimientoCaja movimiento);
        void Update(MovimientoCaja movimiento);
        void Borrar(MovimientoCaja movimiento);
        #endregion
    }
}
