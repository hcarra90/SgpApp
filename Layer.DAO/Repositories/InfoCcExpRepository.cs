using Layer.DAO.Interface;
using Layer.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones de la tabla IInfoCcExpRepository
    /// </summary>
    public class InfoCcExpRepository : GenericRepository<DataContext, CentroCostoExperimento>, IInfoCcExpRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<CentroCostoExperimento> repository;
        #endregion

        #region Constructores
        public InfoCcExpRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<CentroCostoExperimento> GetCCByLoc(int idLoc)
        {
            repository = unitOfWork.Repository<CentroCostoExperimento>();
            var items = (from ue in repository.Table
                         where ue.id_location == idLoc
                         select ue).ToList();
            return items;
        }

        public CentroCostoExperimento GetCCExpById(int id)
        {
            repository = unitOfWork.Repository<CentroCostoExperimento>();
            var item = (from ue in repository.Table
                         where ue.Id == id
                         select ue).SingleOrDefault();
            return item;
        }

        public List<CentroCostoExperimento> GetCcs()
        {
            repository = unitOfWork.Repository<CentroCostoExperimento>();
            var items = (from ue in repository.Table
                         select ue).ToList();
            return items;
        }

        public void Insert(CentroCostoExperimento obj)
        {
            repository = unitOfWork.Repository<CentroCostoExperimento>();
            repository.Insert(obj);
        }

        public void Update(CentroCostoExperimento obj)
        {
            repository = unitOfWork.Repository<CentroCostoExperimento>();
            repository.Update(obj);
        }
        #endregion
    }
}
