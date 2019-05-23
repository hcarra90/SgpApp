using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones de la tabla MovimientoCajaRepository
    /// </summary>
    public class MovimientoCajaRepository : GenericRepository<DataContext, MovimientoCaja>, IMovimientoCajaRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoCaja> repository;
        private static Repository<MovimientoShipping> repositoryS;
        private static Repository<MovimientoPacking> repositoryP;
        private static Repository<InfoFieldBook> repositoryI;
        private static Repository<InfoShipping> repositoryIS;
        private static Repository<Pallet> repositoryPal;
        private static Repository<Pallet> repositoryBul;
        #endregion

        #region Constructores
        public MovimientoCajaRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Función que obtiene información del euid.
        /// </summary>
        /// <param name="euid"></param>
        /// <returns>InfoFieldBook</returns>
        public MovimientoCaja GetCaja(string cajaEnvio)
        {
            repository = unitOfWork.Repository<MovimientoCaja>();
            var cajaEncontrada = repository.Table.Where(mc => mc.cajaEnvio == cajaEnvio).FirstOrDefault();

            return cajaEncontrada;
        }

        public CajaEnvioDto GetNumeroCaja(string shipTo)
        {
            decimal caja = 1;
            string numeroCaja = "";
            CajaEnvioDto newCaja = new CajaEnvioDto();
            repository = unitOfWork.Repository<MovimientoCaja>();

            try
            {
                caja = repository.Table.Where(mc=>mc.shipTo == shipTo).ToList().Max(m => m.correlativo);
                caja++;
            }
            catch (Exception ex)
            {
                caja = 1;
            }
            newCaja.correlativo = caja;

            numeroCaja = shipTo + caja.ToString("000");
            newCaja.nuevaCaja = numeroCaja;

            return newCaja;
        }

        public List<CajaEnvioDto> GetCajasByShipTo(string shipTo)
        {
            repository = unitOfWork.Repository<MovimientoCaja>();

            var cajas = (from mc in repository.Table
                         where mc.shipTo == shipTo
                             select new CajaEnvioDto
                             {
                                 correlativo = mc.correlativo,
                                 Id = mc.Id,
                                 nuevaCaja =mc.cajaEnvio
                             }).ToList();

            return cajas;
        }

        public CajaEnvioDto GetCorrelativoEnvio(int anio)
        {
            decimal correlativoEnvio = 1;
            string shipmentCode = "";
            CajaEnvioDto newCaja = new CajaEnvioDto();
            repository = unitOfWork.Repository<MovimientoCaja>();

            try
            {
                correlativoEnvio = (decimal)repository.Table.ToList().Max(m => m.correlativoEnvio);
                correlativoEnvio++;
            }
            catch (Exception ex)
            {
                correlativoEnvio = 1;
            }
            newCaja.correlativoEnvio = correlativoEnvio;

            shipmentCode = anio.ToString() + correlativoEnvio.ToString("000");
            newCaja.shipmentCode = shipmentCode;

            return newCaja;
        }

        /// <summary>
        /// Función que obtiene información del euid.
        /// </summary>
        /// <param name="euid"></param>
        /// <returns>InfoFieldBook</returns>
        public List<MovimientoCaja> GetEnviosByFecha(DateTime fechaEnvio)
        {
            repository = unitOfWork.Repository<MovimientoCaja>();

            var data = repository.Table.Where(mp => mp.fechaEnvio == fechaEnvio).AsNoTracking().ToList();
            //data = db.MovimientoCaja.Where(mp => mp.fechaEnvio == fechaEnvio).ToList();
            return data;
        }

        //Reportes

        /// <summary>
        /// Función que obtiene Lista de ShipmentCode.
        /// </summary>
        /// <param name=""></param>
        /// <returns>ListaShipmentCodeDto</returns>
        /// 
        public List<ListaShipmentCodeDto> GetshipmentsCode()
        {
            repository = unitOfWork.Repository<MovimientoCaja>();

            var data = (from mc in repository.Table
                        where mc.shipmentCode != null
                        orderby mc.correlativo
                        group mc by mc.shipmentCode into g
                        select new ListaShipmentCodeDto
                        {
                            shipmentCode = g.Key
                        }).ToList();

            data.Insert(0, new ListaShipmentCodeDto { shipmentCode = "" });
            return data;
        }

        /// <summary>
        /// Función que obtiene información de MovimientoCaja.
        /// </summary>
        /// <param name="shipmentCode"></param>
        /// <returns>EncPackingListDto</returns>
        /// 
        public List<EncPackingListDto> GetCajasByshipmentCode(string shipmentCode)
        {
            repository = unitOfWork.Repository<MovimientoCaja>();
            repositoryIS = unitOfWork.Repository<InfoShipping>();
            repositoryI= unitOfWork.Repository<InfoFieldBook>();
            repository= unitOfWork.Repository<MovimientoCaja>();
            repositoryS = unitOfWork.Repository<MovimientoShipping>();
            repositoryPal = unitOfWork.Repository<Pallet>();
            repositoryBul = unitOfWork.Repository<Pallet>();

            var data = (from mc in repository.Table
                        join ins in repositoryIS.Table on mc.shipTo equals ins.shipTo
                        join bul in repositoryBul.Table on new { repositoryBul = mc.bulto } equals new { repositoryBul = bul.Codigo } into Pallet_join
                        from bul in Pallet_join.DefaultIfEmpty()
                        join pal in repositoryPal.Table on new { repositoryPal = mc.pallet } equals new { repositoryPal = pal.Codigo } into Pallet_1_join
                        from pal in Pallet_1_join.DefaultIfEmpty()
                        where mc.shipmentCode == shipmentCode
                        orderby mc.correlativo
                        select new EncPackingListDto
                        {
                            cajaEnvio = mc.cajaEnvio,
                            palletEnvio = mc.pallet,
                            bultoEnvio = mc.bulto,
                            pesoBulto = mc.pesoBulto.ToString(),
                            pesoPallet = mc.pesoPallet.ToString(),
                            fechaEnvio = mc.fechaEnvio,
                            pesoBruto = mc.pesoBruto.ToString(),
                            pesoNeto = mc.pesoNeto.ToString(),
                            shipTo = mc.shipTo,
                            country = ins.country,
                            state = ins.state,
                            city = ins.state,
                            address = ins.address,
                            zipCode = ins.zipcode,
                            contact = ins.contact,
                            email = ins.email,
                            phone = ins.phone,
                            client = ins.client,
                            NumeroCaja = (int)mc.correlativo,
                            MaterialPallet = pal.Material,
                            MedidaPallet = pal.Medidas,
                            MaterialBulto = bul.Material,
                            MedidaBulto = bul.Medidas,

                        }).ToList();
            foreach (var item in data)
            {
                var values = (from ms in repositoryS.Table
                            join ifb in repositoryI.Table
                                  on new { ms.euid, ms.indEuid }
                              equals new { ifb.euid, ifb.indEuid }
                            join mc in repository.Table
                                  on new { ms.cajaEnvio, shipmentCode = shipmentCode }
                              equals new { mc.cajaEnvio, mc.shipmentCode }
                            where
                              ms.cajaEnvio == item.cajaEnvio
                            group new { ifb, ms } by new
                            {
                                ifb.crop,
                                ifb.gmoEvent,
                                ifb.sag,
                                ifb.codInternacion
                            } into g
                            select new
                            {
                                Contenido = (g.Key.crop + "//" + g.Count(p => p.ms.indEuid != null) + "//" + g.Key.codInternacion),
                                //g.Key.crop,
                                //sobres = g.Count(p => p.ms.indEuid != null),
                                //g.Key.codInternacion,
                                g.Key.gmoEvent,
                                g.Key.sag
                            }).ToList();
                item.Contenido = String.Join("-", values.Select(i=>i.Contenido));
                item.Gmo = String.Join("-", values.Select(i => i.gmoEvent));
                item.Sag = String.Join("-", values.Select(i => i.sag));
            }

            return data;
        }

        /// <summary>
        /// Función que obtiene información de MovimientoCaja.
        /// </summary>
        /// <param name="shipmentCode"></param>
        /// <returns>DetailPackingListDto</returns>
        /// 
        public List<DetailPackingListDto> GetDetailsByshipmentCode(string shipmentCode)
        {
            InfoFieldBook info = new InfoFieldBook();
            repository = unitOfWork.Repository<MovimientoCaja>();
            repositoryS = unitOfWork.Repository<MovimientoShipping>();
            repositoryP = unitOfWork.Repository<MovimientoPacking>();
            repositoryI = unitOfWork.Repository<InfoFieldBook>();

            var data = (from i in (from mc in repository.Table
                                   from ms in repositoryS.Table
                                   from mp in repositoryP.Table
                                   from inf in repositoryI.Table
                                   //join ms in repositoryS.Table on mc.cajaEnvio equals ms.cajaEnvio
                        //join mp in repositoryP.Table on ms.euid equals mp.euid
                        //join inf in repositoryI.Table on new { mp.euid,mp.indEuid } equals new { inf.euid,inf.indEuid }
                        where mc.cajaEnvio == ms.cajaEnvio && ms.euid == mp.euid &&
                        mp.euid == inf.euid && (mp.indEuid == inf.indEuid || inf.indEuid == null || mp.indEuid =="" || mp.indEuid == null) &&
                        mc.shipmentCode == shipmentCode
                        orderby mc.correlativo
                        select new 
                        {
                            mc.cajaEnvio,
                            euid = mp.euid.ToString(),
                            mp.indEuid,
                            mp.fechaPacking,
                            totalWeight=mp.totalWeight.ToString(),
                            totalKernels = mp.totalKernels.ToString(),
                            totalEar = mp.totalEars.ToString(),
                            inf.country,
                            bc1 = inf.breedersCode1,
                            bc2 = inf.breedersCode2,
                            bc3 = inf.breedersCode3,
                            bc4 = inf.breedersCode4,
                            projectLead = inf.projecLead,
                            inf.cc,
                            inf.shipTo,
                            inf.crop,
                            inf.location,
                            inf.opExpName,
                            inf.client,
                            inf.gmoEvent,
                            inf.sag,
                            inf.codReception,
                            inf.codInternacion,
                            inf.obs
                        }) group i by new 
                        {
                            i.cajaEnvio,
                            i.euid,
                            i.indEuid,
                            i.fechaPacking,
                            i.totalWeight,
                            i.totalKernels,
                            i.totalEar,
                            i.country,
                            i.bc1,
                            i.bc2,
                            i.bc3,
                            i.bc4,
                            i.projectLead,
                            i.cc,
                            i.shipTo,
                            i.crop,
                            i.location,
                            i.opExpName,
                            i.client,
                            i.gmoEvent,
                            i.sag,
                            i.codReception,
                            i.codInternacion,
                            i.obs
                        } into g select new DetailPackingListDto
                        {
                            shipmentCode = shipmentCode,
                            cajaEnvio = g.Key.cajaEnvio,
                            euid = g.Key.euid,
                            indEuid = g.Key.indEuid,
                            fechaPacking = g.Key.fechaPacking,
                            totalWeight = g.Key.totalWeight,
                            totalKernels = g.Key.totalKernels,
                            totalEar = g.Key.totalEar,
                            country = g.Key.country,
                            bc1 = g.Key.bc1,
                            bc2 = g.Key.bc2,
                            bc3 = g.Key.bc3,
                            bc4 = g.Key.bc4,
                            projectLead = g.Key.projectLead,
                            cc = g.Key.cc,
                            shipTo = g.Key.shipTo,
                            crop = g.Key.crop,
                            location=g.Key.location,
                            expName= g.Key.opExpName,
                            client= g.Key.client,
                            gmoEvent= g.Key.gmoEvent,
                            sag= g.Key.sag,
                            codReception= g.Key.codReception,
                            codInternation= g.Key.codInternacion,
                            obs=g.Key.obs
                        }).ToList();

            return data;
        }

        public List<EnvioCajaDto> GetDataByEuid(string cadena, string opcion)
        {
            repository = unitOfWork.Repository<MovimientoCaja>();
            repositoryS = unitOfWork.Repository<MovimientoShipping>();
            repositoryI = unitOfWork.Repository<InfoFieldBook>();
            List<EnvioCajaDto> data = new List<EnvioCajaDto>();

            if (opcion == "Euid" || opcion == "")
            {

                data = (from mc in repository.Table
                        join ms in repositoryS.Table on mc.cajaEnvio equals ms.cajaEnvio
                        where ms.euid == cadena
                        select new EnvioCajaDto
                        {
                            cajaEnvio = mc.cajaEnvio,
                            creacion = mc.fechaCreacion,
                            envio = mc.fechaEnvio,
                            pesoBruto = mc.pesoBruto.ToString(),
                            pesoNeto = mc.pesoNeto.ToString(),
                            shipmentCode = mc.shipmentCode,
                            shipTo = mc.shipTo
                        }).ToList();
            }
            else if (opcion == "Ship To")
            {
                data = (from mc in repository.Table
                        join ms in repositoryS.Table on mc.cajaEnvio equals ms.cajaEnvio
                        join inf in repositoryI.Table on ms.euid equals inf.euid
                        where inf.shipTo == cadena
                        group mc by new
                        {
                            mc.cajaEnvio,
                            mc.fechaCreacion,
                            mc.fechaEnvio,
                            mc.pesoBruto,
                            mc.pesoNeto,
                            mc.shipmentCode,
                            mc.shipTo
                        } into gcs
                        select new EnvioCajaDto
                        {
                            cajaEnvio = gcs.Key.cajaEnvio,
                            creacion = gcs.Key.fechaCreacion,
                            envio = gcs.Key.fechaEnvio,
                            pesoBruto = gcs.Key.pesoBruto.ToString(),
                            pesoNeto = gcs.Key.pesoNeto.ToString(),
                            shipmentCode = gcs.Key.shipmentCode,
                            shipTo = gcs.Key.shipTo
                        }).ToList();
            }
            else if (opcion == "Project Lead")
            {
                data = (from mc in repository.Table
                        join ms in repositoryS.Table on mc.cajaEnvio equals ms.cajaEnvio
                        join inf in repositoryI.Table on ms.euid equals inf.euid
                        where inf.projecLead == cadena
                        group mc by new
                        {
                            mc.cajaEnvio,
                            mc.fechaCreacion,
                            mc.fechaEnvio,
                            mc.pesoBruto,
                            mc.pesoNeto,
                            mc.shipmentCode,
                            mc.shipTo
                        } into gcs
                        select new EnvioCajaDto
                        {
                            cajaEnvio = gcs.Key.cajaEnvio,
                            creacion = gcs.Key.fechaCreacion,
                            envio = gcs.Key.fechaEnvio,
                            pesoBruto = gcs.Key.pesoBruto.ToString(),
                            pesoNeto = gcs.Key.pesoNeto.ToString(),
                            shipmentCode = gcs.Key.shipmentCode,
                            shipTo = gcs.Key.shipTo
                        }).ToList();
            }
            else if (opcion == "Exp Name")
            {
                data = (from mc in repository.Table
                        join ms in repositoryS.Table on mc.cajaEnvio equals ms.cajaEnvio
                        join inf in repositoryI.Table on ms.euid equals inf.euid
                        where inf.opExpName == cadena
                        group mc by new
                        {
                            mc.cajaEnvio,
                            mc.fechaCreacion,
                            mc.fechaEnvio,
                            mc.pesoBruto,
                            mc.pesoNeto,
                            mc.shipmentCode,
                            mc.shipTo
                        } into gcs
                        select new EnvioCajaDto
                        {
                            cajaEnvio = gcs.Key.cajaEnvio,
                            creacion = gcs.Key.fechaCreacion,
                            envio = gcs.Key.fechaEnvio,
                            pesoBruto = gcs.Key.pesoBruto.ToString(),
                            pesoNeto = gcs.Key.pesoNeto.ToString(),
                            shipmentCode = gcs.Key.shipmentCode,
                            shipTo = gcs.Key.shipTo
                        }).ToList();
            }
            else if (opcion == "CC")
            {
                data = (from mc in repository.Table
                        join ms in repositoryS.Table on mc.cajaEnvio equals ms.cajaEnvio
                        join inf in repositoryI.Table on ms.euid equals inf.euid
                        where inf.cc == cadena
                        group mc by new
                        {
                            mc.cajaEnvio,
                            mc.fechaCreacion,
                            mc.fechaEnvio,
                            mc.pesoBruto,
                            mc.pesoNeto,
                            mc.shipmentCode,
                            mc.shipTo
                        } into gcs
                        select new EnvioCajaDto
                        {
                            cajaEnvio = gcs.Key.cajaEnvio,
                            creacion = gcs.Key.fechaCreacion,
                            envio = gcs.Key.fechaEnvio,
                            pesoBruto = gcs.Key.pesoBruto.ToString(),
                            pesoNeto = gcs.Key.pesoNeto.ToString(),
                            shipmentCode = gcs.Key.shipmentCode,
                            shipTo = gcs.Key.shipTo
                        }).ToList();
            }
            else if (opcion == "Año")
            {
                var anio = int.Parse(cadena);
                data = (from mc in repository.Table
                        join ms in repositoryS.Table on mc.cajaEnvio equals ms.cajaEnvio
                        join inf in repositoryI.Table on ms.euid equals inf.euid
                        where inf.year == anio
                        group mc by new
                        {
                            mc.cajaEnvio,
                            mc.fechaCreacion,
                            mc.fechaEnvio,
                            mc.pesoBruto,
                            mc.pesoNeto,
                            mc.shipmentCode,
                            mc.shipTo
                        } into gcs
                        select new EnvioCajaDto
                        {
                            cajaEnvio = gcs.Key.cajaEnvio,
                            creacion = gcs.Key.fechaCreacion,
                            envio = gcs.Key.fechaEnvio,
                            pesoBruto = gcs.Key.pesoBruto.ToString(),
                            pesoNeto = gcs.Key.pesoNeto.ToString(),
                            shipmentCode = gcs.Key.shipmentCode,
                            shipTo = gcs.Key.shipTo
                        }).ToList();
            }
            return data;
        }

        public void Insert(MovimientoCaja movimiento)
        {
            repository.Insert(movimiento);
        }

        public void Update(MovimientoCaja movimiento)
        {
            repository.Update(movimiento);
        }

        public void Borrar(MovimientoCaja movimiento)
        {
            repository.Update(movimiento);
        }
        #endregion
    }
}
