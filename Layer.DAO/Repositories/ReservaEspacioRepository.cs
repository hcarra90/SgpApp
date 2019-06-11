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
    public class ReservaEspacioRepository : GenericRepository<DataContext, ReservaEspacio>, IReservaEspacioRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<ReservaEspacio> repository;
        private static Repository<TipoEnvase> repositoryTE;
        private static Repository<Pais> repositoryPA;
        private static Repository<Puerto> repositoryPU;
        #endregion

        #region Constructores
        public ReservaEspacioRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<ReservaEspacioDto> GetReservaEspacio(int idEmpresa,DateTime fecha,DateTime fechaFin)
        {
            DateTime fechaInicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime fechaTermino = fechaFin;
           
            repository = unitOfWork.Repository<ReservaEspacio>();
            repositoryTE = unitOfWork.Repository<TipoEnvase>();
            repositoryPA = unitOfWork.Repository<Pais>();
            repositoryPU = unitOfWork.Repository<Puerto>();

            var items = (from re in repository.Table
                         join pa in repositoryPA.Table on re.id_pais equals pa.Id
                         join te in repositoryTE.Table on re.id_tipo_envase equals te.Id
                         where re.id_empresa == idEmpresa
                         && (re.FechaReserva >= fechaInicio && re.FechaReserva <= fechaTermino)

                         select new ReservaEspacioDto
                         {
                             Alto = re.Alto,
                             Ancho = re.Ancho,
                             Direccion = re.Direccion,
                             FechaCarga = re.FechaCarga,
                             FechaLlegada = re.FechaLlegada,
                             FechaModificacion = re.FechaModificacion,
                             FechaReserva = re.FechaReserva,
                             Id = re.Id,
                             IdEmpresa= re.id_empresa.ToString(),
                             IdPais = re.id_pais,
                             IdPuerto = (int?)re.id_puerto,
                             IdTipoEnvase = re.id_tipo_envase,
                             KilosBrutos = re.KilosBrutos,
                             KilosNetos = re.KilosNetos,
                             Largo = re.Largo,
                             Pais = pa.Nombre,
                             ShipTo = re.ShipTo,
                             TipoEnvase = te.Nombre,
                             IdTipoReserva = re.IdTipoReserva,
                             TipoReserva = (re.IdTipoReserva == 1)?"Aéreo":"Marítimo",
                             UsuarioCarga = re.UsuarioCarga,
                             UsuarioModificacion = re.UsuarioModificacion
                         }).ToList();

            var value = items.Find(p => p.IdTipoReserva == 2);
            if (value != null)
            {
                foreach (var item in items)
                {
                    if (item.IdTipoReserva == 2)
                    {
                        var puerto = repositoryPU.Table.Where(p => p.Id == item.IdPuerto).FirstOrDefault();
                        item.Puerto = puerto.Nombre;
                    }
                }
            }
            
            return items;
        }

        public void Insert(ReservaEspacio obj)
        {
            repository.Insert(obj);
        }

        public void Update(ReservaEspacio obj)
        {
            repository.Update(obj);
        }
        #endregion
    }
}
