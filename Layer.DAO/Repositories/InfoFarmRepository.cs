using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones de la tabla InfoFarmRepository
    /// </summary>
    public class InfoFarmRepository : GenericRepository<DataContext, InfoFarm>, IInfoFarmRepository
    {
        #region -----Declaración-----
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<InfoFarm> repository;
        #endregion

        #region -----Constructores-----
        public InfoFarmRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region -----Métodos Públicos-----
        public InfoFarm GetFarmById(int id)
        {
            repository= unitOfWork.Repository<InfoFarm>();
            var item = (from ue in repository.Table
                        where ue.Id == id
                        select ue).SingleOrDefault();
            return item;
        }

        public List<FarmDto> GetFarmsByEmpresa(int idEmpresa)
        {
            repository = unitOfWork.Repository<InfoFarm>();
            var farms = (from InfoFarm in db.InfoFarm
                         where
                          InfoFarm.id_empresa == 1
                         group InfoFarm by new
                         {
                             InfoFarm.Country,
                             InfoFarm.Farm,
                             InfoFarm.CodFarm,
                             InfoFarm.DireccionGd
                         } into g
                         orderby
                           g.Key.Farm
                         select new FarmDto
                         {
                             Country = g.Key.Country,
                             Farm = g.Key.Farm,
                             CodFarm = g.Key.CodFarm,
                             DireccionGd = g.Key.DireccionGd,
                             FullName = g.Key.CodFarm + "-" + g.Key.Farm
                         }).ToList();

            return farms;
        }

        public List<FarmDto> GetSubFarmsByFarm(string codFarm)
        {
            repository = unitOfWork.Repository<InfoFarm>();
            var farms = (from InfoFarm in db.InfoFarm
                         where
                          InfoFarm.id_empresa == 1
                          && InfoFarm.CodFarm == codFarm
                         group InfoFarm by new
                         {
                             InfoFarm.Id,
                             InfoFarm.SubFarm,
                             InfoFarm.DireccionGd
                         } into g
                         orderby
                           g.Key.SubFarm
                         select new FarmDto
                         {
                             Id = g.Key.Id,
                             FullName = g.Key.SubFarm,
                             DireccionGd = g.Key.DireccionGd
                         }).ToList();

            return farms;
        }

        public List<InfoFarm> GetFarmBySubFarm(string codFarm, string subFarm)
        {
            repository = unitOfWork.Repository<InfoFarm>();
            var items = (from ue in repository.Table
                         where ue.CodFarm==codFarm && ue.SubFarm == subFarm
                        select ue).ToList();
            return items;
        }

        public List<InfoFarm> GetFarms()
        {
            repository = unitOfWork.Repository<InfoFarm>();
            var items = (from ue in repository.Table
                         select ue).ToList();
            return items;
        }

        public void Insert(InfoFarm obj)
        {
            repository = unitOfWork.Repository<InfoFarm>();
            repository.Insert(obj);
        }

        public void Update(InfoFarm obj)
        {
            repository = unitOfWork.Repository<InfoFarm>();
            repository.Update(obj);
        }
        #endregion
    }
}
