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
    public static class MovimientoDespachoBusiness
    {
        #region Declaración
        static readonly IMovimientoDespachoRepository repository = new MovimientoDespachoRepository();
        #endregion

        #region Métodos Publicos
        public static List<MovimientoDespachoDto> GetMovimientoDespacho(int idEmpresa)
        {
            return repository.GetMovimientoDespacho(idEmpresa);
        }

        public static MovimientoDespachoDto GetMovimientoDespachoById(int idProgramaExport)
        {
            return repository.GetMovimientoDespachoById(idProgramaExport);
        }

        public static int GetFolioTarja()
        {
            return repository.GetFolioTarja();
        }

        public static int GetFolioPallet()
        {
            return repository.GetFolioPallet();
        }

        public static bool GrabaTarja(List<MovimientoDespachoDto> data)
        {
            MovimientoDespacho mov = new MovimientoDespacho();
            int folioTarja = GetFolioTarja();
            
            foreach (var item in data)
            {
                mov.Fecha = item.Fecha;
                mov.IdProgramaExport = item.IdProgramaExport;
                mov.IdTarja = folioTarja;
                mov.Usuario = item.Usuario;
                Insert(mov);
            }

            return true;
        }

        public static bool GrabaPallet(List<MovimientoDespachoDto> data)
        {
            MovimientoDespacho mov = new MovimientoDespacho();
            int folioPallet = GetFolioPallet();
            int folioTarja = GetFolioTarja();

            foreach (var item in data)
            {
                mov.Fecha = item.Fecha;
                mov.IdProgramaExport = item.IdProgramaExport;
                mov.IdTarja = folioTarja;
                mov.IdPallet = folioPallet;
                mov.Usuario = item.Usuario;
                Insert(mov);
            }

            return true;
        }

        public static void Insert(MovimientoDespacho obj)
        {
            repository.Insert(obj);
        }

        public static void Update(MovimientoDespacho obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
