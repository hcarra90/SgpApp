using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del MovimientoSecado
    /// </summary>
    public interface IMovimientoSecadoRepository : IGenericRepository<MovimientoSecado>
    {
        List<MovimientoSecado> GetEuidsByBox(string caja);
        MovimientoSecado GetEuidById(int id);
        MovimientoSecado GetEuid(string euid);
        List<MovimientoSecado> GetEuids(string euid);
        MovimientoSecado GetCaja(string caja);
    }
}
