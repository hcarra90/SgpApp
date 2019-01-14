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
    public class MovimientoRoggingRepository : GenericRepository<DataContext, MovimientoRogging>, IMovimientoRoggingRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoRogging> repository;
        private static Repository<EntryList> repositoryI;
        #endregion

        #region Constructores
        public MovimientoRoggingRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos

        public MovimientoRogging GetEuidById(int id)
        {
            repository = unitOfWork.Repository<MovimientoRogging>();
            var item = repository.Table.Where(mp => mp.Id == id).FirstOrDefault();
            return item;
        }

        public List<MovimientoRogging> GetMovimientoRogging(string reason)
        {
            repository = unitOfWork.Repository<MovimientoRogging>();
            return repository.Table.Where(m => m.Reason == reason).ToList();
        }

        public MovimientoRogging GrabaInformacion(MovimientoRogging movimiento, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<MovimientoRogging>();

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
                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }

            return movimiento;
        }

        public void BorrarEuid(int id, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<MovimientoRogging>();

            try
            {
                var entity = GetEuidById(id);
                repository.Delete(entity);

            }
            catch (Exception ex)
            {
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }
        }

        public List<MovimientoRoggingDto> GetEuids(string cadena, string opcion)
        {
            repository = unitOfWork.Repository<MovimientoRogging>();
            repositoryI = unitOfWork.Repository<EntryList>();
            List<MovimientoRoggingDto> data = new List<MovimientoRoggingDto>();

            if (opcion == "Euid" || opcion == "")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.Euid equals inf.Euid
                        where inf.Euid == cadena
                        select new MovimientoRoggingDto
                        {
                            Reason = mc.Reason,
                            FechaRogging = mc.FechaRogging,
                            Euid = mc.Euid,
                            Id = mc.Euid,
                            Bi1 = inf.Bi1,
                            Bi2 = inf.Bi2,
                            Bi3 = inf.Bi3,
                            Bi4 = inf.Bi4,
                            Crop = inf.Crop,
                            Client = inf.Client,
                            ProjectLead = inf.ProjectLead,
                            Location = inf.Location,
                            ExpName = inf.ExpName,
                            GmoEvent = inf.GmoEvent,
                            Sag = inf.Sag,
                            Cc=inf.Cc,
                            CodInternacion=inf.CodInternacion,
                            CodPermanencia = inf.CodPermanencia,
                            Country = inf.Country,
                            Ent = inf.Ent,
                            EntName = inf.EntName,
                            EntRole = inf.EntRole,
                            GranosHilera=inf.GranosHilera,
                            LotId = inf.LotId,
                            Obs = inf.Obs,
                            Owner = inf.Owner,
                            Plt = inf.Plt,
                            ProjectCode = inf.ProjectCode,
                            ResImportacion = inf.ResImportacion,
                            Rng = inf.Rng,
                            Year = inf.Year
                        }).ToList();
            }
            else if (opcion == "Ship To")
            {
                return null;
                //data = (from mc in repository.Table
                //        join inf in repositoryI.Table on mc.Euid equals inf.Euid
                //        where inf.ShipTo == cadena
                //        select new MovimientoRoggingDto
                //        {
                //            Reason = mc.Reason,
                //            FechaRogging = mc.FechaRogging,
                //            Euid = mc.Euid,
                //            Id = mc.Euid
                //            //Bi1 = inf.breedersCode1,
                //            //breedersCode2 = inf.breedersCode2,
                //            //breedersCode3 = inf.breedersCode3,
                //            //breedersCode4 = inf.breedersCode4,
                //            //crop = inf.crop,
                //            //client = inf.client,
                //            //projecLead = inf.projecLead,
                //            //location = inf.location,
                //            //opExpName = inf.opExpName,
                //            //gmoEvent = inf.gmoEvent,
                //            //sag = inf.sag
                //        }).ToList();
            }
            else if (opcion == "Project Lead")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.Euid equals inf.Euid
                        where inf.ProjectLead == cadena
                        select new MovimientoRoggingDto
                        {
                            Reason = mc.Reason,
                            FechaRogging = mc.FechaRogging,
                            Euid = mc.Euid,
                            Id = mc.Euid,
                            Bi1 = inf.Bi1,
                            Bi2 = inf.Bi2,
                            Bi3 = inf.Bi3,
                            Bi4 = inf.Bi4,
                            Crop = inf.Crop,
                            Client = inf.Client,
                            ProjectLead = inf.ProjectLead,
                            Location = inf.Location,
                            ExpName = inf.ExpName,
                            GmoEvent = inf.GmoEvent,
                            Sag = inf.Sag,
                            Cc = inf.Cc,
                            CodInternacion = inf.CodInternacion,
                            CodPermanencia = inf.CodPermanencia,
                            Country = inf.Country,
                            Ent = inf.Ent,
                            EntName = inf.EntName,
                            EntRole = inf.EntRole,
                            GranosHilera = inf.GranosHilera,
                            LotId = inf.LotId,
                            Obs = inf.Obs,
                            Owner = inf.Owner,
                            Plt = inf.Plt,
                            ProjectCode = inf.ProjectCode,
                            ResImportacion = inf.ResImportacion,
                            Rng = inf.Rng,
                            Year = inf.Year
                        }).ToList();
            }
            else if (opcion == "Exp Name")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.Euid equals inf.Euid
                        where inf.ExpName == cadena
                        select new MovimientoRoggingDto
                        {
                            Reason = mc.Reason,
                            FechaRogging = mc.FechaRogging,
                            Euid = mc.Euid,
                            Id = mc.Euid,
                            Bi1 = inf.Bi1,
                            Bi2 = inf.Bi2,
                            Bi3 = inf.Bi3,
                            Bi4 = inf.Bi4,
                            Crop = inf.Crop,
                            Client = inf.Client,
                            ProjectLead = inf.ProjectLead,
                            Location = inf.Location,
                            ExpName = inf.ExpName,
                            GmoEvent = inf.GmoEvent,
                            Sag = inf.Sag,
                            Cc = inf.Cc,
                            CodInternacion = inf.CodInternacion,
                            CodPermanencia = inf.CodPermanencia,
                            Country = inf.Country,
                            Ent = inf.Ent,
                            EntName = inf.EntName,
                            EntRole = inf.EntRole,
                            GranosHilera = inf.GranosHilera,
                            LotId = inf.LotId,
                            Obs = inf.Obs,
                            Owner = inf.Owner,
                            Plt = inf.Plt,
                            ProjectCode = inf.ProjectCode,
                            ResImportacion = inf.ResImportacion,
                            Rng = inf.Rng,
                            Year = inf.Year
                        }).ToList();
            }
            else if (opcion == "CC")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.Euid equals inf.Euid
                        where inf.Cc == cadena
                        select new MovimientoRoggingDto
                        {
                            Reason = mc.Reason,
                            FechaRogging = mc.FechaRogging,
                            Euid = mc.Euid,
                            Id = mc.Euid,
                            Bi1 = inf.Bi1,
                            Bi2 = inf.Bi2,
                            Bi3 = inf.Bi3,
                            Bi4 = inf.Bi4,
                            Crop = inf.Crop,
                            Client = inf.Client,
                            ProjectLead = inf.ProjectLead,
                            Location = inf.Location,
                            ExpName = inf.ExpName,
                            GmoEvent = inf.GmoEvent,
                            Sag = inf.Sag,
                            Cc = inf.Cc,
                            CodInternacion = inf.CodInternacion,
                            CodPermanencia = inf.CodPermanencia,
                            Country = inf.Country,
                            Ent = inf.Ent,
                            EntName = inf.EntName,
                            EntRole = inf.EntRole,
                            GranosHilera = inf.GranosHilera,
                            LotId = inf.LotId,
                            Obs = inf.Obs,
                            Owner = inf.Owner,
                            Plt = inf.Plt,
                            ProjectCode = inf.ProjectCode,
                            ResImportacion = inf.ResImportacion,
                            Rng = inf.Rng,
                            Year = inf.Year
                        }).ToList();
            }
            else if (opcion == "Año")
            {
                var anio = int.Parse(cadena);
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.Euid equals inf.Euid
                        where inf.Year == anio
                        select new MovimientoRoggingDto
                        {
                            Reason = mc.Reason,
                            FechaRogging = mc.FechaRogging,
                            Euid = mc.Euid,
                            Id = mc.Euid,
                            Bi1 = inf.Bi1,
                            Bi2 = inf.Bi2,
                            Bi3 = inf.Bi3,
                            Bi4 = inf.Bi4,
                            Crop = inf.Crop,
                            Client = inf.Client,
                            ProjectLead = inf.ProjectLead,
                            Location = inf.Location,
                            ExpName = inf.ExpName,
                            GmoEvent = inf.GmoEvent,
                            Sag = inf.Sag,
                            Cc = inf.Cc,
                            CodInternacion = inf.CodInternacion,
                            CodPermanencia = inf.CodPermanencia,
                            Country = inf.Country,
                            Ent = inf.Ent,
                            EntName = inf.EntName,
                            EntRole = inf.EntRole,
                            GranosHilera = inf.GranosHilera,
                            LotId = inf.LotId,
                            Obs = inf.Obs,
                            Owner = inf.Owner,
                            Plt = inf.Plt,
                            ProjectCode = inf.ProjectCode,
                            ResImportacion = inf.ResImportacion,
                            Rng = inf.Rng,
                            Year = inf.Year
                        }).ToList();
            }
            return data;
        }
        #endregion

    }
}
