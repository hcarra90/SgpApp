using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones de la tabla MovimientoSecadoRepository
    /// </summary>
    public class MovimientoSecadoRepository : GenericRepository<DataContext, MovimientoSecado>, IMovimientoSecadoRepository
    {
        #region Declaración
        readonly DataContext db;
        #endregion

        #region Constructores
        public MovimientoSecadoRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public MovimientoSecado GetEuidById(int id)
        {
            var euidEncontrado = db.MovimientoSecado.AsNoTracking().Where(mp => mp.Id == id).FirstOrDefault();

            return euidEncontrado;
        }

        public MovimientoSecado GetEuid(string euid)
        {
            var euidEncontrado = db.MovimientoSecado.AsNoTracking().Where(mp => mp.euid == euid).FirstOrDefault();

            return euidEncontrado;
        }

        public List<MovimientoSecado> GetEuidsByBox(string caja)
        {
            var data = db.MovimientoSecado.AsNoTracking().Where(ms => ms.cajaSecador == caja).ToList();

            return data;
        }

        public List<MovimientoSecado> GetEuids(string euid)
        {
            var data = db.MovimientoSecado.AsNoTracking().Where(mp => mp.euid == euid).ToList();
            
            return data;
        }

        public MovimientoSecado GetCaja(string caja)
        {
            var data = (from mc in db.MovimientoSecado
                        where mc.cajaSecador == caja
                        select mc).FirstOrDefault();
            return data;
        }
        #endregion
    }
}
