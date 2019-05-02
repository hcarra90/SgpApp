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
    public class MovimientoFloracionRepository : GenericRepository<DataContext, MovimientoNota>, IMovimientoFloracionRepository
    {
        #region -----Declaración-----
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoNota> repository;
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
        public List<MovimientoNotaDto> Getfloraciones(DateTime fechaInicio,DateTime fechaTermino)
        {
            repository = unitOfWork.Repository<MovimientoNota>();
            repositoryE = unitOfWork.Repository<EntryList>();
            repositoryI= unitOfWork.Repository<InfoLoc>();

            var items = (from ta in repository.Table
                         from il in repositoryI.Table
                         from el in repositoryE.Table
                         where ta.Euid == el.Euid && el.Location == il.LocationCuartel
                         && (ta.Fecha >= fechaInicio && ta.Fecha <= fechaTermino )
                         select new MovimientoNotaDto {
                             Euid = ta.Euid,
                             Fecha = ta.Fecha,
                             Jaula = il.Jaula,
                             Nota = ta.Nota.Nombre,
                             Usuario = ta.Usuario,
                             Id = ta.Id
                         }).ToList();

            return items;
        }

        public void Insert(MovimientoNota obj)
        {
            repository = unitOfWork.Repository<MovimientoNota>();
            repository.Insert(obj);
        }

        public void Update(MovimientoNota obj)
        {
            repository = unitOfWork.Repository<MovimientoNota>();
            repository.Update(obj);
        }

        public MovimientoNota GetEuidById(int id)
        {
            repository = unitOfWork.Repository<MovimientoNota>();
            var item = repository.Table.Where(mp => mp.Id == id).FirstOrDefault();
            return item;
        }

        public void BorrarEuid(int id, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<MovimientoNota>();

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
