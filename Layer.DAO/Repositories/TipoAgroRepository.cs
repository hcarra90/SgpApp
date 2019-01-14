using Layer.DAO.Interface;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class TipoAgroRepository : GenericRepository<DataContext, TipoAgro>, ITipoAgroRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<TipoAgro> repository;
        #endregion

        #region Constructores
        public TipoAgroRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<TipoAgro> GetDatos(int idEmpresa)
        {
            repository = unitOfWork.Repository<TipoAgro>();
            var items = (from ta in repository.Table
                         where ta.id_empresa == idEmpresa
                         select ta).ToList();
            items.Insert(0, new TipoAgro { });

            return items;
        }
        #endregion

    }
}
