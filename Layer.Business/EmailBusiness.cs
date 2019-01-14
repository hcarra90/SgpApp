using Layer.DAO;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public static class EmailBusiness
    {
        #region Declaración
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<Email> repository;
        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Función que obtiene emails usados.
        /// </summary>
        /// <param name="euid"></param>
        /// <returns>MovimientoSecado</returns>
        public static List<Email> GetEmails()
        {
            repository = unitOfWork.Repository<Email>();
            var items = repository.Table.OrderBy(e=>e.EmailUsado).ToList();
            items.Insert(0, new Email { EmailUsado = "", Id = 0 });
            return items;
        }

        public static Email GetEmail(string email)
        {
            repository = unitOfWork.Repository<Email>();
            var item = repository.Table.Where(e=>e.EmailUsado == email).FirstOrDefault();
            return item;
        }

        public static Email GrabaInformacion(Email email, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<Email>();

            try
            {
                if (email.Id == 0)
                {
                    repository.Insert(email);
                }

                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }

            return email;
        }

        #endregion
    }
}
