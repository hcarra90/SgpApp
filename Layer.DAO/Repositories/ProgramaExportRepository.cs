using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class ProgramaExportRepository:GenericRepository<DataContext, ProgramaExport>, IProgramaExportRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<ProgramaExport> repository;
        #endregion

        #region Constructores
        public ProgramaExportRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<ProgramaExport> GetProgramaExport(int idEmpresa)
        {
            repository = unitOfWork.Repository<ProgramaExport>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();

            foreach (var item in items)
            {
                item.Opcion = item.IdPallet.ToString()+item.Especie+item.Variedad+item.Color+item.Envase+item.Embalaje+item.PesoEmbalaje+item.Calibre+item.CajaPallet;
            }

            items.Insert(0, new ProgramaExport { });

            return items;
        }

        public ProgramaExport GetProgramaExportById(int idEmpresa, int id)
        {
            repository = unitOfWork.Repository<ProgramaExport>();
            var item = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa 
                         && ta.IdPallet == id
                         select ta).FirstOrDefault();

            

            

            return item;
        }

        public void Update(ProgramaExport obj)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProgramaExport obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
