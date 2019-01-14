using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones de la tabla MovimientoCosechaRepository
    /// </summary>
    public interface IMovimientoCosechaRepository: IGenericRepository<MovimientoCosecha>
    {
        List<MovimientoCosecha> GetEuidsByBin(string bin);
        MovimientoCosecha GetEuidById(int id);
        List<MovimientoCosecha> GetEuids(string cadena, string opcion);
        MovimientoCosecha GetBin(string bin);
    }
}
