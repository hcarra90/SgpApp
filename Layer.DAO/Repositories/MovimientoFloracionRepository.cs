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
    public class MovimientoFloracionRepository : GenericRepository<DataContext, MovimientoFloracion>, IMovimientoFloracionRepository
    {
        #region -----Declaración-----
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoFloracion> repository;
        private static Repository<EntryList> repositoryE;
        private static Repository<InfoLoc> repositoryI;

        #endregion

        #region -----Constructores-----
        public MovimientoFloracionRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region -----Métodos Públicos-----
        public List<MovimientoFloracionDto> Getfloraciones(DateTime fechaInicio,DateTime fechaTermino)
        {
            repository = unitOfWork.Repository<MovimientoFloracion>();
            repositoryE = unitOfWork.Repository<EntryList>();
            repositoryI= unitOfWork.Repository<InfoLoc>();

            var items = (from ta in repository.Table
                         from il in repositoryI.Table
                         from el in repositoryE.Table
                         where ta.Euid == el.Euid && el.Location == il.LocationCuartel
                         && (ta.Fecha >= fechaInicio && ta.Fecha <= fechaTermino )
                         select new MovimientoFloracionDto {
                             Euid = ta.Euid,
                             Fecha = ta.Fecha,
                             Jaula = il.Jaula,
                             Nota = ta.Nota.Nombre,
                             Usuario = ta.Usuario,
                             Id = ta.Id
                         }).ToList();

            return items;
        }

        public void Insert(MovimientoFloracion obj)
        {
            repository = unitOfWork.Repository<MovimientoFloracion>();
            repository.Insert(obj);
        }

        public void Update(MovimientoFloracion obj)
        {
            repository = unitOfWork.Repository<MovimientoFloracion>();
            repository.Update(obj);
        }

        public MovimientoFloracion GetEuidById(int id)
        {
            repository = unitOfWork.Repository<MovimientoFloracion>();
            var item = repository.Table.Where(mp => mp.Id == id).FirstOrDefault();
            return item;
        }

        public void BorrarEuid(int id, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<MovimientoFloracion>();

            try
            {
                var entity = GetEuidById(id);
                repository.Delete(entity);

            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }
        }
        #endregion
    }
}
