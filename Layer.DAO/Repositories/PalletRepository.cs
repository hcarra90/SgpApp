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
    public class PalletRepository : GenericRepository<DataContext, Pallet>, IPalletRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Pallet> repository;
        #endregion

        #region Constructores
        public PalletRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<Pallet> GetPallet(int idEmpresa)
        {
            repository = unitOfWork.Repository<Pallet>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();

            items.ToList().ForEach(i => {
                i.NombreTipo = (i.Tipo == 1) ? "PALLET" : "BULTO";
            });

            return items;
        }

        public Pallet GetPalletById(int id)
        {
            repository = unitOfWork.Repository<Pallet>();
            var item = (from ta in repository.Table
                         where ta.Id == id
                         select ta).FirstOrDefault();

            return item;
        }

        public EnvaseSecuenciaDto GetSecuenciaPallet(int idEmpresa,int idTipo)
        {
            EnvaseSecuenciaDto envaseSecuencia = new EnvaseSecuenciaDto();
            int secuencia = 0;
            
            try
            {
                secuencia = repository.Table.Where(mc => mc.id_empresa == idEmpresa && mc.Tipo == idTipo).ToList().Max(m => m.Secuencia);
                secuencia++;
            }
            catch (Exception ex)
            {
                secuencia = 1;
            }
            envaseSecuencia.CodigoNum = "A" + secuencia.ToString("000");
            envaseSecuencia.Secuencia = secuencia;

            return envaseSecuencia;
        }

        public void Update(Pallet obj)
        {
            repository.Update(obj);
        }

        public void Insert(Pallet obj)
        {
            repository.Insert(obj);
        }

        public void Borrar(int id, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<Pallet>();

            try
            {
                var entity = GetPalletById(id);
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
