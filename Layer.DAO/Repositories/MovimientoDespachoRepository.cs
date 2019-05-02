using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class MovimientoDespachoRepository : GenericRepository<DataContext, MovimientoDespacho>, IMovimientoDespachoRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoDespacho> repository;
        private static Repository<ProgramaExport> repositoryPe;
        #endregion

        #region Constructores
        public MovimientoDespachoRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        public List<MovimientoDespachoDto> GetMovimientoDespacho(int idEmpresa)
        {
            repository = unitOfWork.Repository<MovimientoDespacho>();
            repositoryPe= unitOfWork.Repository<ProgramaExport>();

            var items = (from ta in repository.Table
                         from md in repositoryPe.Table
                         where ta.IdProgramaExport == md.IdPallet &&
                         md.id_empresa == idEmpresa
                         select new MovimientoDespachoDto {
                             CajaPallet = md.CajaPallet,
                             Calibre = md.Calibre,
                             Color = md.Color,
                             Embalaje = md.Embalaje,
                             Envase = md.Envase,
                             Especie = md.Especie,
                             Fecha = ta.Fecha,
                             Id=ta.Id,
                             IdPallet = ta.IdPallet,
                             IdProgramaExport = md.IdPallet,
                             IdTarja = ta.IdTarja,
                             PesoEmbalaje = md.PesoEmbalaje,
                             Usuario = ta.Usuario,
                             Variedad = md.Variedad
                         }).ToList();

            return items;
        }

        public MovimientoDespachoDto GetMovimientoDespachoById(int idProgramaExport)
        {
            repository = unitOfWork.Repository<MovimientoDespacho>();
            repositoryPe = unitOfWork.Repository<ProgramaExport>();

            var item = ( from md in repositoryPe.Table
                         where md.IdPallet == idProgramaExport
                         select new MovimientoDespachoDto
                         {
                             CajaPallet = md.CajaPallet,
                             Calibre = md.Calibre,
                             Color = md.Color,
                             Embalaje = md.Embalaje,
                             Envase = md.Envase,
                             Especie = md.Especie,
                             IdProgramaExport = md.IdPallet,
                             PesoEmbalaje = md.PesoEmbalaje,
                             Variedad = md.Variedad
                         }).FirstOrDefault();

            return item;
        }

        public int GetFolioTarja()
        {
            repository = unitOfWork.Repository<MovimientoDespacho>();
            repositoryPe = unitOfWork.Repository<ProgramaExport>();
            int? tarja = 0;

            try
            {
                tarja = repository.Table.ToList().Max(m => m.IdTarja);
                if (tarja == null)
                {
                    tarja = 1000;
                }
                else
                {
                    tarja++;
                }
            }
            catch (Exception ex)
            {
                tarja = 1000;
            }

            return (int)tarja;
        }

        public int GetFolioPallet()
        {
            repository = unitOfWork.Repository<MovimientoDespacho>();
            
            int? pallet = 0;

            try
            {
                pallet = repository.Table.ToList().Max(m => m.IdPallet);
                if (pallet == null)
                {
                    pallet = 1000;
                }
                else
                {
                    pallet++;
                }
            }
            catch (Exception ex)
            {
                pallet = 1000;
            }

            return (int)pallet;
        }

        public void Insert(MovimientoDespacho obj)
        {
            repository = unitOfWork.Repository<MovimientoDespacho>();
            repository.Insert(obj);
        }

        public void Update(MovimientoDespacho obj)
        {
            throw new NotImplementedException();
        }
    }
}
