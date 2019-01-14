using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class CropRepository : GenericRepository<DataContext, Crop>, ICropRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Crop> repository;
        #endregion

        #region Constructores
        public CropRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<Crop> GetCrops(int idEmpresa)
        {
            repository = unitOfWork.Repository<Crop>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new Crop { });

            return items;
        }

        public void Insert(Crop obj)
        {
            repository.Insert(obj);
        }

        public void Update(Crop obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
