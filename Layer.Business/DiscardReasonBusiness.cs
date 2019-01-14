using Layer.DAO;
using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public static class DiscardReasonBusiness
    {
        #region Declaración
        static readonly IDiscardReasonRepository repository = new DiscardReasonRepository();
        #endregion

        #region Métodos Públicos
        public static List<DiscardReason> GetAllData()
        {
            return repository.GetAllData();
        }
        #endregion
    }
}
