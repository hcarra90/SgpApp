using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;

namespace Layer.Business
{
    public static class LaboratorioBusiness
    {
        #region Declaración
        static readonly ILaboratorioRepository repository = new LaboratorioRepository();
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Metódo que rescata todos los laboratorios
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>List<Laboratorio></returns>
        public static List<Laboratorio> GetLaboratorios(string estado, int currentPageNumber, int pageSize, string sortDirection, string sortExpression, out TransactionalInformation transaction, out int totalRows)
        {
            transaction = new TransactionalInformation();
            List<Laboratorio> laboratorios = new List<Laboratorio>();
            totalRows = 0;
            try
            {
                laboratorios = repository.GetLaboratorios(estado, currentPageNumber, pageSize, sortDirection, sortExpression, out totalRows);
            }
            catch (System.Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }

            return laboratorios;
        }
        #endregion
    }
}
