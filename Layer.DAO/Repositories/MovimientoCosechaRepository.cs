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
    public class MovimientoCosechaRepository : GenericRepository<DataContext, MovimientoCosecha>, IMovimientoCosechaRepository
    {
        #region Declaración
        readonly DataContext db;
        #endregion

        #region Constructores
        public MovimientoCosechaRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos

        public List<MovimientoCosecha> GetEuidsByBin(string bin)
        {
            var data = (from mc in db.MovimientoCosecha
                        where mc.Bin == bin
                        select mc).ToList();
            //data.ForEach(m=>m.fechaCosecha = m.fechaCosecha.Date);
            return data;
        }

        public MovimientoCosecha GetBin(string bin)
        {
            var data = (from mc in db.MovimientoCosecha
                        where mc.Bin == bin
                        select mc).FirstOrDefault();
            return data;

        }
        public MovimientoCosecha GetEuidById(int id)
        {
            var euidEncontrado = db.MovimientoCosecha.AsNoTracking().Where(mp => mp.Id == id).FirstOrDefault();

            return euidEncontrado;
        }

        public List<MovimientoCosecha> GetEuids(string cadena,string opcion)
        {
            List<MovimientoCosecha> data = new List<MovimientoCosecha>();

            if (opcion == "Euid" || opcion=="")
            {
                data = (from mc in db.MovimientoCosecha
                        where mc.euid == cadena
                        select mc).ToList();
            }
            else if (opcion == "Ship To")
            {
                data = (from mc in db.MovimientoCosecha
                        join inf in db.InfoFieldBook on mc.euid equals inf.euid.ToString()
                        where mc.euid == cadena
                        select mc).ToList();
            }
            
            return data;
        }
        #endregion
    }
}
