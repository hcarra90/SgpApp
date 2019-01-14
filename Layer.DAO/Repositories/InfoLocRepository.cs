using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones de la tabla InfoLocRepository
    /// </summary>
    public class InfoLocRepository : GenericRepository<DataContext, InfoLoc>, IInfoLocRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<InfoLoc> repository;
        private static Repository<InfoFarm> repositoryIfa;
        #endregion

        #region Constructores
        public InfoLocRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos
        public List<InfoLoc> GetLocByCuartel(string cuartel)
        {
            repository = unitOfWork.Repository<InfoLoc>();
            var items = (from ue in repository.Table
                        where ue.LocationCuartel == cuartel
                        select ue).ToList();
            return items;
        }

        public InfoLoc GetLocById(int id)
        {
            repository = unitOfWork.Repository<InfoLoc>();
            var item = (from ue in repository.Table
                        where ue.Id == id
                        select ue).SingleOrDefault();
            return item;
        }

        public List<InfoLocDto> GetLocs()
        {
            repository = unitOfWork.Repository<InfoLoc>();
            repositoryIfa = unitOfWork.Repository<InfoFarm>();

            var items = (from ue in repository.Table
                         from ifa in repositoryIfa.Table
                         where ue.id_farm == ifa.Id
                         select new InfoLocDto
                         {
                             CaudalGoterosLtsSeg = ue.CaudalGoterosLtsSeg,
                             CodigoPoligono = ue.CodigoPoligono,
                             CodSemillero = ue.CodSemillero,
                             DireccionGd = ue.DireccionGd,
                             DistEntreHileraM = ue.DistEntreHileraM,
                             DistGoterosM = ue.DistGoterosM,
                             DistSobreHileraM = ue.DistSobreHileraM,
                             FechaCarga = ue.FechaCarga,
                             FechaEstCosecha = ue.FechaEstCosecha,
                             FechaModificacion = ue.FechaModificacion,
                             FechaPlantacion = ue.FechaPlantacion,
                             FechaSiembra = ue.FechaSiembra,
                             FechaTransplante = ue.FechaTransplante,
                             Gmo = ue.Gmo,
                             Id = ue.Id,
                             id_crop = ue.id_crop,
                             id_estado = ue.id_estado,
                             id_farm = ue.id_farm,
                             id_tipo_agro = ue.id_tipo_agro,
                             Jaula = ue.Jaula,
                             Latitud = ue.Latitud,
                             LineaRiego = ue.LineaRiego,
                             LocationCuartel = ue.LocationCuartel,
                             Longitud = ue.Longitud,
                             Owner = ue.Owner,
                             SuperficieHa = ue.SuperficieHa,
                             TotLineaRiegoM = ue.TotLineaRiegoM,
                             Year = ue.Year,
                             InfoFarm = new InfoFarmDto
                             {
                                 CodFarm = ifa.CodFarm,
                                 CodigoPoligono = ifa.CodigoPoligono,
                                 Country = ifa.Country,
                                 DireccionGd = ifa.DireccionGd,
                                 Farm = ifa.Farm,
                                 FechaCarga = ifa.FechaCarga,
                                 FechaModificacion = ifa.FechaModificacion,
                                 Id = ifa.Id,
                                 id_ciudad = ifa.id_ciudad,
                                 id_comuna = ifa.id_comuna,
                                 id_empresa = ifa.id_empresa,
                                 id_estado = ifa.id_estado,
                                 id_provincia = ifa.id_provincia,
                                 id_region =ifa.id_region,
                                 id_tipo_contrato = (int)ifa.id_tipo_contrato,
                                 InicioContrato = ifa.InicioContrato,
                                 Latitud = ifa.Latitud,
                                 Longitud = ifa.Longitud,
                                 Owner = ifa.Owner,
                                 SubFarm = ifa.SubFarm,
                                 TerminoContrato = ifa.TerminoContrato
                             }
                         }).ToList();
            items.Insert(0, new InfoLocDto { });
            return items;
        }

        public void Insert(InfoLoc obj)
        {
            repository = unitOfWork.Repository<InfoLoc>();
            repository.Insert(obj);
        }

        public void Update(InfoLoc obj)
        {
            repository = unitOfWork.Repository<InfoLoc>();
            repository.Update(obj);
        }
        #endregion
    }
}
