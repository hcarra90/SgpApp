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
    /// Clase que implementa las operaciones de la tabla MovimientoDesgraneRepository
    /// </summary>
    public class MovimientoDesgraneRepository : GenericRepository<DataContext, MovimientoDesgrane>, IMovimientoDesgraneRepository
    {
        #region Declaración
        readonly DataContext db;
        #endregion

        #region Constructores
        public MovimientoDesgraneRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public MovimientoDesgrane GetEuid(string euid, string desgranadora)
        {
            var euidEncontrado = db.MovimientoDesgrane.AsNoTracking().Where(mp => mp.euid == euid && mp.sheller == desgranadora).FirstOrDefault();

            return euidEncontrado;
        }

        public List<MovimientoDesgrane> GetEuids(string euid)
        {
            var data = (from mc in db.MovimientoDesgrane
                        where mc.euid == euid
                        select mc).ToList();
            data.ForEach(m => m.fechaDesgrane = m.fechaDesgrane.Date);
            return data;
        }
        #endregion
    }
}
