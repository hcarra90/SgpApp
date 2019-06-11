using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class PuertoRepository : GenericRepository<DataContext, Puerto>, IPuertoRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Puerto> repository;
        private static Repository<Pais> repositoryP;
        private static Repository<InfoShipping> repositoryI;
        #endregion

        #region Constructores
        public PuertoRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<Puerto> GetPuerto(int idEmpresa)
        {
            repository = unitOfWork.Repository<Puerto>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new Puerto {Id=0,Nombre="" });

            return items;
        }

        public List<PuertoDto> GetPuertoByShipTo(string shipTo)
        {
            repository = unitOfWork.Repository<Puerto>();
            repositoryP = unitOfWork.Repository<Pais>();
            repositoryI = unitOfWork.Repository<InfoShipping>();

            var items = (from pais in repositoryP.Table
                         join puerto in repository.Table on pais.Id equals puerto.Id
                         join infoS in repositoryI.Table on new { Nombre_pais = pais.Nombre } equals new { Nombre_pais = infoS.country }
                         where
                           infoS.shipTo == shipTo
                         select new PuertoDto
                         {
                             Id=(int)puerto.Id,
                             Codigo = puerto.Codigo,
                             Nombre = puerto.Nombre
                         }).ToList();

            items.Insert(0, new PuertoDto { Id = 0, Nombre = "" });

            return items;
        }

        public void Insert(Puerto obj)
        {
            repository.Insert(obj);
        }

        public void Update(Puerto obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
