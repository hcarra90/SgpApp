using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del MovimientoDesgrane
    /// </summary>
    public interface IMovimientoDesgraneRepository : IGenericRepository<MovimientoDesgrane>
    {
        MovimientoDesgrane GetEuid(string euid, string desgranadora);
        List<MovimientoDesgrane> GetEuids(string euid);
    }
}
