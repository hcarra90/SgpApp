using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Layer.DAO.Repositories
{
    public class ParametroRepository : GenericRepository<DataContext, Parametro>, IParametroRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Parametro> repository;
        #endregion

        #region Constructores
        public ParametroRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos

        public Parametro GetParametroById(int id)
        {
            repository = unitOfWork.Repository<Parametro>();
            var item = repository.Table.Where(mc => mc.Id == id).FirstOrDefault();
            return item;
        }

        public List<Parametro> GetParametroByTipo(string tipo)
        {
            repository = unitOfWork.Repository<Parametro>();
            var items = repository.Table.Where(mc => mc.Tipo == tipo).ToList();
            return items;
        }

        public List<Parametro> GetParametros()
        {
            repository = unitOfWork.Repository<Parametro>();
            var items = repository.Table.ToList();
            return items;
        }

        public void Insert(Parametro obj)
        {
            repository.Insert(obj);
        }

        public void Update(Parametro obj)
        {
            repository.Update(obj);
        }

        #endregion

    }
}
