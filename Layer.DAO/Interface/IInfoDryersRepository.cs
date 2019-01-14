using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Interface
{
    /// <summary>
    /// Interfaz con las operaciones del InfoDryers
    /// </summary>
    public interface IInfoDryersRepository : IGenericRepository<InfoDryers>
    {
        List<InfoDryers> GetInfoDryers();
        Parametro GetParametros();
        InfoDryers GetSheller(string sheller);
        InfoDryers GetBin(string bin);
        InfoDryers GetDryerBox(string box);
    }
}
