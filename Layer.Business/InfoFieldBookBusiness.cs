using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;

namespace Layer.Business
{
    public static class InfoFieldBookBusiness
    {
        #region Declaración
        static readonly IInfoFieldBookRepository repository = new InfoFieldBookRepository();
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Función que obtiene información de Eduid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <returns>Devuelve un objeto de tipo InfoFieldBook.</returns>
        public static List<InfoFieldBook> GetEuid(string cadena, string opcion)
        {
            return repository.GetEuid(cadena,opcion);
        }

        /// <summary>
        /// Función que obtiene información del ind euid.
        /// </summary>
        /// <param name="indEuid"></param>
        /// <returns>InfoFieldBook</returns>
        public static InfoFieldBook GetIndEuid(string indEuid, string euid)
        {
            return repository.GetIndEuid(indEuid,euid);
        }

        public static string GetSecuenciaIndEuid(string euid)
        {
            return repository.GetSecuenciaIndEuid(euid);
        }
        /// <summary>
        /// Función que obtiene información de project lead.
        /// </summary>
        /// <param name=""></param>
        /// <returns>InfoFieldBook</returns>
        public static List<ProjectLeadDto> GetProjectLead()
        {
            return repository.GetProjectLead();
        }

        /// <summary>
        /// Función que obtiene información de CC.
        /// </summary>
        /// <param name=""></param>
        /// <returns>InfoFieldBook</returns>
        public static List<CCDto> GetCC()
        {
            return repository.GetCc();
        }

        /// <summary>
        /// Función que obtiene información de ExpName.
        /// </summary>
        /// <param name=""></param>
        /// <returns>InfoFieldBook</returns>
        public static List<ExpNameDto> GetExpName()
        {
            return repository.GetExpName();
        }

        /// <summary>
        /// Función que obtiene información de Anio.
        /// </summary>
        /// <param name=""></param>
        /// <returns>InfoFieldBook</returns>
        public static List<AnioDto> GetAnio()
        {
            return repository.GetAnio();
        }

        public static InfoFieldBook GetRowById(int id)
        {
            return repository.GetRowById(id);
        }

        public static bool ValidateEuids(List<SplitEuidDto> data)
        {
            return repository.ValidateEuids(data);
        }

        public static InfoFieldBook GrabaInformacion(InfoFieldBook movimiento)
        {
            try
            {
                if (movimiento.Id == 0)
                {
                    repository.Insert(movimiento);
                }
                else
                {
                    repository.Update(movimiento);
                }
            }
            catch (Exception ex)
            {
                movimiento = null;
            }

            return movimiento;
        }

        public static bool ValidateIndEuids(List<InfoFieldBook> data)
        {
            return repository.ValidateIndEuids(data);
        }

        public static void InsertBulk(List<InfoFieldBook> entities)
        {
            repository.InsertBulk(entities);
        }
        #endregion
    }
}
