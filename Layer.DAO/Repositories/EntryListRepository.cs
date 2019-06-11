using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    public class EntryListRepository : GenericRepository<DataContext, EntryList>, IEntryListRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<EntryList> repository;
        private static Repository<InfoLoc> repositoryL;
        private static Repository<Crop> repositoryC;
        #endregion

        #region Constructores
        public EntryListRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        public bool EuidExist(string euid)
        {
            repository = unitOfWork.Repository<EntryList>();
            var exist = (from el in repository.Table
                         where el.Euid == euid
                         select el).FirstOrDefault();
            
            var e = (exist == null)?false:true;
            return e;
        }

        public string GetMaxEuid()
        {
            repository = unitOfWork.Repository<EntryList>();
            var euid = (from EntryList in
                     (from EntryList in repository.Table
                      where SqlFunctions.IsNumeric(EntryList.Euid)==1 && EntryList.Euid.Length > 5
                      select new
                      {
                          EntryList.Euid,
                          Dummy = "x"
                      })
                       group EntryList by new { EntryList.Dummy } into g
                       select new
                       {
                           MaxEuid = g.Max(p => p.Euid)
                       }).SingleOrDefault();
            var nuevoEuid = long.Parse(euid.MaxEuid);

            return nuevoEuid.ToString();
        }

        public List<EntryList> GetEuid(string cadena, string opcion)
        {
            repository = unitOfWork.Repository<EntryList>();

            List<EntryList> euidsEncontrados = new List<EntryList>();

            if (opcion == "Euid" || opcion == "")
            {

                euidsEncontrados = (from ue in repository.Table
                                    where ue.Euid == cadena
                                    select ue).ToList();
            }
            else if (opcion == "Ship To")
            {
                euidsEncontrados = new List<EntryList>();
            }
            else if (opcion == "Project Lead")
            {
                euidsEncontrados = (from ue in repository.Table
                                    where ue.ProjectLead == cadena
                                    select ue).ToList();
            }
            else if (opcion == "Exp Name")
            {
                euidsEncontrados = (from ue in repository.Table
                                    where ue.ExpName == cadena
                                    select ue).ToList();
            }
            else if (opcion == "CC")
            {
                euidsEncontrados = (from ue in repository.Table
                                    where ue.Cc == cadena
                                    select ue).ToList();
            }
            else if (opcion == "Año")
            {
                var anio = int.Parse(cadena);
                euidsEncontrados = (from ue in repository.Table
                                    where ue.Year == anio
                                    select ue).ToList();
            }
            return euidsEncontrados;
        }

        public List<CropDto> GetTipoConversion(int idEmpresa,string location)
        {
            List<CropDto> data = new List<CropDto>();
            repository = unitOfWork.Repository<EntryList>();
            repositoryC = unitOfWork.Repository<Crop>();

            data = (from e in repository.Table
                    join c in repositoryC.Table on new { Des = e.Crop } equals new { Des = c.Descripcion }
                    where
                      e.Location == location
                    group new { e, c } by new
                    {
                        e.Crop,
                        c.TipoConversion,
                        c.EtapaConversion,
                        c.PesoConversion
                    } into g
                    select new CropDto
                    {
                        Descripcion = g.Key.Crop,
                        TipoConversion = g.Key.TipoConversion,
                        EtapaConversion = g.Key.EtapaConversion,
                        PesoConversion = g.Key.PesoConversion
                    }).ToList();
            data.Insert(0, new CropDto { });
            return data;
        }

        public List<DataGuiaDespachoDto> GetDataGuiaDespacho(string location)
        {
            List<DataGuiaDespachoDto> data = new List<DataGuiaDespachoDto>();
            repository = unitOfWork.Repository<EntryList>();

            data = (from e in repository.Table
                    where
                      e.Location == location
                    group e by new
                    {
                        e.GmoEvent,
                        e.Location,
                        e.Crop,
                        e.Sag,
                        e.ExpName,
                        e.Cc,
                        e.CodInternacion,
                        e.GranosHilera
                    } into g
                    select new DataGuiaDespachoDto
                    {
                        Location = g.Key.Location,
                        Event = g.Key.GmoEvent,
                        Experiment = g.Key.ExpName,
                        CentroCosto =  g.Key.Cc,
                        CodInternacion = g.Key.CodInternacion,
                        NumeroEuid = g.Count(p => p.Euid != null),
                        GranosHilera = g.Key.GranosHilera,
                        Peso = g.Count(p => p.Euid != null),
                        Crop = g.Key.Crop,
                        Sag = g.Key.Sag
                    }).ToList()
                    .Select(c=> new DataGuiaDespachoDto {
                        Location = c.Location,
                        Event = c.Event,
                        Experiment = c.Experiment,
                        CentroCosto =c.CentroCosto,
                        CodInternacion = c.CodInternacion,
                        NumeroEuid = c.NumeroEuid,
                        Peso = (c.NumeroEuid * int.Parse(c.GranosHilera))/1000,
                        Crop = c.Crop,
                        Sag = c.Sag
                    }).ToList();

            return data;
        }

        public bool ValidateEuids(List<EntryList> data)
        {
            repository = unitOfWork.Repository<EntryList>();
            var euidsG = (from e in repository.Table
                         select new
                         {
                             euid = e.Euid
                         }).ToList();

            var euidsC = (from ec in data
                          select new
                          {
                              euid = ec.Euid
                          }).ToList();

            var result = euidsG.Where(p => euidsC.Any(p2 => p2.euid == p.euid)).ToList();

            return result.Count > 0;
        }

        public List<string> GetEuidByJaula(string jaula,int idEmpresa)
        {
            repository = unitOfWork.Repository<EntryList>();
            repositoryL = unitOfWork.Repository<InfoLoc>();

            var euids= (from el in repository.Table
                        from il in repositoryL.Table
                        where el.Location == il.LocationCuartel
                        && il.Jaula == jaula
                        select el.Euid).ToList();

            return euids;
        }

        public void Insert(EntryList obj)
        {
            repository = unitOfWork.Repository<EntryList>();
            repository.Insert(obj);
        }

        public void InsertBulk(List<EntryList> entities)
        {
            repository = unitOfWork.Repository<EntryList>();
            repository.InsertBulk(entities);
        }

    }
}
