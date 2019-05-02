using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Layer.Business
{
    public static class MovimientoFloracionBusiness
    {
        #region -----Declaración-----
        static readonly IMovimientoFloracionRepository repository = new MovimientoFloracionRepository();
        #endregion

        #region -----Métodos Públicos-----
        public static List<MovimientoNotaDto> GetFloraciones(DateTime fechaInicio, DateTime fechaTermino)
        {
            return repository.Getfloraciones(fechaInicio,fechaTermino);
        }

        public static void Insert(MovimientoNota obj)
        {
            repository.Insert(obj);
        }

        public static void Insert(List<string> items, MovimientoNota obj)
        {
            
            using (TransactionScope ts = new TransactionScope())
            {
                foreach (var item in items)
                {
                    var movFlora = new MovimientoNota
                    {
                        Euid = item,
                        Fecha = obj.Fecha,
                        id_nota = obj.id_nota,
                        Usuario = obj.Usuario
                    };

                    repository.Insert(movFlora);
                }
                ts.Complete();
            }
        }

        public static void Update(MovimientoNota obj) => repository.Update(obj);

        public static void BorrarEuid(int id, out TransactionalInformation transaction) => repository.BorrarEuid(id, out transaction);

        #endregion
    }
}
