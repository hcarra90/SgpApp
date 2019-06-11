using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Clase que implementa las operaciones de la tabla DatosGuiaRepository
/// </summary>
namespace Layer.DAO.Repositories
{
    public class DatosGuiaRepository : GenericRepository<DataContext, DatosGuia>, IDatosGuiaRepository
    {
        #region -----Declaración-----
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<DatosGuia> repository;
        #endregion

        #region -----Constructores-----
        public DatosGuiaRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region -----Métodos Públicos-----

        public List<DatosGuia> GetData(int idGuia = 0)
        {
            repository = unitOfWork.Repository<DatosGuia>();
            var data = (from ue in repository.Table
                        select ue).ToList();
            if (idGuia > 0)
            {
                data = data.Where(d => d.Id == idGuia).ToList();
            }
            return data;
        }

        public void Insert(DatosGuia obj)
        {
            repository = unitOfWork.Repository<DatosGuia>();
            repository.Insert(obj);
        }

        public void InsertBulk(List<DatosGuia> entities)
        {
            repository = unitOfWork.Repository<DatosGuia>();
            repository.InsertBulk(entities);
        }
        #endregion
    }
}
