using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones de la tabla MovimientoPackingRepository
    /// </summary>
    public class MovimientoPackingRepository : GenericRepository<DataContext, MovimientoPacking>, IMovimientoPackingRepository
    {
        #region Declaración
        readonly DataContext db;
        #endregion

        #region Constructores
        public MovimientoPackingRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Función que obtiene información del euid.
        /// </summary>
        /// <param name="euid"></param>
        /// <returns>InfoFieldBook</returns>
        public MovimientoPacking GetEuid(string indEuid,string euid)
        {
            var euidEncontrado = db.MovimientoPacking.AsNoTracking().Where(mp => mp.indEuid == indEuid && mp.euid== euid).AsNoTracking().FirstOrDefault();

            return euidEncontrado;
        }

        /// <summary>
        /// Función que obtiene información del euid.
        /// </summary>
        /// <param name="euid"></param>
        /// <returns>InfoFieldBook</returns>
        public List<MovimientoPacking> GetEuids(string euid)
        {
            var data = db.MovimientoPacking.AsNoTracking().Where(mp => mp.euid == euid).ToList();
            data.ForEach(f => f.fechaPacking = f.fechaPacking.Date);

            return data;
        }

        
        #endregion
    }
}
