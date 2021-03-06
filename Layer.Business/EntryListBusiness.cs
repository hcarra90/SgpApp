﻿using Layer.DAO.Interface;
using Layer.DAO.Repositories;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public static class EntryListBusiness
    {
        #region Declaración
        static readonly IEntryListRepository repository = new EntryListRepository();
        #endregion

        #region Métodos Publicos

        public static bool EuidExist(string euid)
        {
            return repository.EuidExist(euid);
        }
        public static List<EntryList> GetEntryList(string cadena, string opcion)
        {
            return repository.GetEuid(cadena,opcion);
        }

        public static List<CropDto> GetTipoConversion(int idEmpresa, string location)
        {
            return repository.GetTipoConversion(idEmpresa, location);
        }

        public static string GetMaxEuid()
        {
            return repository.GetMaxEuid();
        }

        public static bool ValidateEuids(List<EntryList> data)
        {
            return repository.ValidateEuids(data);
        }

        public static List<DataGuiaDespachoDto> GetDataGuiaDespacho(string location)
        {
            return repository.GetDataGuiaDespacho(location);
        }

        public static void InsertMasivo(List<EntryList> objs, EntryList obj)
        {
            repository.AddLista(objs, obj);
        }

        public static void Insert(EntryList obj)
        {
            repository.Insert(obj);
        }

        public static List<string> GetEuidByJaula(string jaula, int idEmpresa)
        {
            return repository.GetEuidByJaula(jaula, idEmpresa);
        }

        public static void InsertBulk(List<EntryList> entities)
        {
            repository.InsertBulk(entities);
        }
        #endregion
    }
}
