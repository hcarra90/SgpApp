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
    /// <summary>
    /// Clase que implementa las operaciones de la tabla MovimientoShippingRepository
    /// </summary>
    public class MovimientoShippingRepository : GenericRepository<DataContext, MovimientoShipping>, IMovimientoShippingRepository
    {
        #region Declaración
        readonly DataContext db;
        #endregion

        #region Constructores
        public MovimientoShippingRepository()
        {
            this.db = new DataContext();
        }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Función que obtiene información del euid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MovimientoShipping</returns>
        public MovimientoShipping GetEuidById(int id)
        {
            var euidEncontrado = db.MovimientoShipping.AsNoTracking().Where(mp => mp.Id == id).FirstOrDefault();

            return euidEncontrado;
        }

        /// <summary>
        /// Función que obtiene información del euid.
        /// </summary>
        /// <param name="euid"></param>
        /// <returns>InfoFieldBook</returns>
        public MovimientoShipping GetEuid(string euid)
        {
            var euidEncontrado = db.MovimientoShipping.Where(mp => mp.euid == euid).FirstOrDefault();

            return euidEncontrado;
        }

        /// <summary>
        /// Función que obtiene información de contenido de cajas.
        /// </summary>
        /// <param name="box"></param>
        /// <returns>MovimientoShipping</returns>
        public List<MovimientoShipping> GetEuidByBox(string box)
        {
            var euidsEncontrados = db.MovimientoShipping.Where(mp => mp.cajaEnvio == box).ToList();
            euidsEncontrados = euidsEncontrados.OrderByDescending(c => c.fechaPreparacion).ToList();

            return euidsEncontrados;
        }

        /// <summary>
        /// Función que obtiene todas las cajas en las cuáles esta un euid o individual euid.
        /// </summary>
        /// <param name="euid"></param>
        /// <param name="indEuid"></param>
        /// <returns>Lista</returns>
        public List<MovimientoShipping> GetBoxesByEuid(string euid,string indEuid,string cajaEnvio)
        {
            var cajasEncontradas = db.MovimientoShipping.Where(
                    mp => (mp.euid == euid || indEuid =="") && 
                    (mp.indEuid == indEuid || euid == "") &&
                    mp.cajaEnvio != cajaEnvio
                ).ToList();

            return cajasEncontradas;
        }

        /// <summary>
        /// Función que valida si el ind euid existe ya en la misma caja.
        /// </summary>
        /// <param name="indEuid"></param>
        /// <returns>MovimientoShipping</returns>
        public MovimientoShipping GetBoxByIndEuid(string indEuid, string cajaEnvio)
        {
            var cajaEncontrada = db.MovimientoShipping.Where(
                    mp => mp.indEuid == indEuid &&
                    mp.cajaEnvio == cajaEnvio
                ).FirstOrDefault();

            return cajaEncontrada;
        }

        /// <summary>
        /// Función que obtiene información de contenido de cajas.
        /// </summary>
        /// <param name="box"></param>
        /// <returns>MovimientoShipping</returns>
        public List<ContenidoCajaDto> GetBoxContent(string box)
        {
            var data = (from mp in db.MovimientoPacking
                        join ms in db.MovimientoShipping on mp.euid equals ms.euid
                        where ms.cajaEnvio == box
                        group ms by new
                        {
                            ms.euid,
                            mp.totalWeight,
                            ms.cajaEnvio
                        } into gcs
                        select new ContenidoCajaDto
                        {
                            box = gcs.Key.cajaEnvio,
                            euid = gcs.Key.euid,
                            totalWeight = (decimal)gcs.Key.totalWeight
                        }).ToList();
            var pesoBruto = data.Sum(s => s.totalWeight);
            
            return data;
        }

        /// <summary>
        /// Función que obtiene peso neto de la caja.
        /// </summary>
        /// <param name="box"></param>
        /// <returns>decimal</returns>
        public decimal GetBoxWeight(string box)
        {
            var data = (from mp in db.MovimientoPacking
                        join ms in db.MovimientoShipping on mp.euid equals ms.euid 
                        where ms.euid == mp.euid && ms.indEuid==mp.indEuid && ms.cajaEnvio == box
                        select new ContenidoCajaDto
                        {
                            box = ms.cajaEnvio,
                            euid = mp.euid,
                            indEuid = mp.indEuid,
                            totalWeight = (decimal)mp.totalWeight
                        }).ToList();
            var listaAgrupada = data.GroupBy(x => new {
                x.euid,
                x.indEuid,
                x.totalWeight
                })
                .Select(y => new ContenidoCajaDto()
                {
                    euid = y.Key.euid,
                    indEuid = y.Key.indEuid,
                    totalWeight = y.Key.totalWeight,
                }).ToList();

            var pesoBruto = listaAgrupada.Sum(s => s.totalWeight);
            pesoBruto = Math.Round((pesoBruto / 1000), 2);
            return pesoBruto;
        }

        /// <summary>
        /// Función que obtiene todas las cajas en las cuáles esta un euid o individual euid.
        /// </summary>
        /// <param name="euid"></param>
        /// <param name="indEuid"></param>
        /// <returns>Lista</returns>
        public List<MovimientoShippingDto> GetEuids(string cadena, string opcion)
        {
            List<MovimientoShippingDto> data = new List<MovimientoShippingDto>();

            if (opcion == "Euid" || opcion == "")
            {

                data = (from mc in db.MovimientoShipping
                        from inf in db.InfoFieldBook
                        where mc.euid == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")

                        select new MovimientoShippingDto
                        {
                            euid = mc.euid.ToString(),
                            indEuid = mc.indEuid,
                            fechaPreparacion = mc.fechaPreparacion,
                            cajaEnvio = mc.cajaEnvio,
                            order = inf.order,
                            breedersCode1 = inf.breedersCode1,
                            breedersCode2 = inf.breedersCode2,
                            breedersCode3 = inf.breedersCode3,
                            breedersCode4 = inf.breedersCode4,
                            crop = inf.crop,
                            client = inf.client,
                            projecLead = inf.projecLead,
                            location = inf.location,
                            opExpName = inf.opExpName,
                            gmoEvent = inf.gmoEvent,
                            sag = inf.sag,
                            shelling = inf.shelling,
                            instructions = inf.instructions
                        }).ToList();
            }
            else if (opcion == "Ship To")
            {
                data = (from mc in db.MovimientoShipping
                        from inf in db.InfoFieldBook
                        where inf.shipTo == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPreparacion,
                            mc.cajaEnvio,
                            inf.order,
                            inf.breedersCode1,
                            inf.breedersCode2,
                            inf.breedersCode3,
                            inf.breedersCode4,
                            inf.crop,
                            inf.client,
                            inf.projecLead,
                            inf.location,
                            inf.opExpName,
                            inf.gmoEvent,
                            inf.sag,
                            inf.shelling,
                            inf.instructions
                        } into gcs
                        select new MovimientoShippingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPreparacion = gcs.Key.fechaPreparacion,
                            cajaEnvio = gcs.Key.cajaEnvio,
                            order = gcs.Key.order,
                            breedersCode1 = gcs.Key.breedersCode1,
                            breedersCode2 = gcs.Key.breedersCode2,
                            breedersCode3 = gcs.Key.breedersCode3,
                            breedersCode4 = gcs.Key.breedersCode4,
                            crop = gcs.Key.crop,
                            client = gcs.Key.client,
                            projecLead = gcs.Key.projecLead,
                            location = gcs.Key.location,
                            opExpName = gcs.Key.opExpName,
                            gmoEvent = gcs.Key.gmoEvent,
                            sag = gcs.Key.sag,
                            shelling = gcs.Key.shelling,
                            instructions = gcs.Key.instructions
                        }).ToList();
            }
            else if (opcion == "Project Lead")
            {
                data = (from mc in db.MovimientoShipping
                        from inf in db.InfoFieldBook
                        where inf.projecLead == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPreparacion,
                            mc.cajaEnvio,
                            inf.order,
                            inf.breedersCode1,
                            inf.breedersCode2,
                            inf.breedersCode3,
                            inf.breedersCode4,
                            inf.crop,
                            inf.client,
                            inf.projecLead,
                            inf.location,
                            inf.opExpName,
                            inf.gmoEvent,
                            inf.sag,
                            inf.shelling,
                            inf.instructions
                        } into gcs
                        select new MovimientoShippingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPreparacion = gcs.Key.fechaPreparacion,
                            cajaEnvio = gcs.Key.cajaEnvio,
                            order = gcs.Key.order,
                            breedersCode1 = gcs.Key.breedersCode1,
                            breedersCode2 = gcs.Key.breedersCode2,
                            breedersCode3 = gcs.Key.breedersCode3,
                            breedersCode4 = gcs.Key.breedersCode4,
                            crop = gcs.Key.crop,
                            client = gcs.Key.client,
                            projecLead = gcs.Key.projecLead,
                            location = gcs.Key.location,
                            opExpName = gcs.Key.opExpName,
                            gmoEvent = gcs.Key.gmoEvent,
                            sag = gcs.Key.sag,
                            shelling = gcs.Key.shelling,
                            instructions = gcs.Key.instructions
                        }).ToList();
            }
            else if (opcion == "Exp Name")
            {
                data = (from mc in db.MovimientoShipping
                        from inf in db.InfoFieldBook
                        where inf.opExpName == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPreparacion,
                            mc.cajaEnvio,
                            inf.order,
                            inf.breedersCode1,
                            inf.breedersCode2,
                            inf.breedersCode3,
                            inf.breedersCode4,
                            inf.crop,
                            inf.client,
                            inf.projecLead,
                            inf.location,
                            inf.opExpName,
                            inf.gmoEvent,
                            inf.sag,
                            inf.shelling,
                            inf.instructions
                        } into gcs
                        select new MovimientoShippingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPreparacion = gcs.Key.fechaPreparacion,
                            cajaEnvio = gcs.Key.cajaEnvio,
                            order = gcs.Key.order,
                            breedersCode1 = gcs.Key.breedersCode1,
                            breedersCode2 = gcs.Key.breedersCode2,
                            breedersCode3 = gcs.Key.breedersCode3,
                            breedersCode4 = gcs.Key.breedersCode4,
                            crop = gcs.Key.crop,
                            client = gcs.Key.client,
                            projecLead = gcs.Key.projecLead,
                            location = gcs.Key.location,
                            opExpName = gcs.Key.opExpName,
                            gmoEvent = gcs.Key.gmoEvent,
                            sag = gcs.Key.sag,
                            shelling = gcs.Key.shelling,
                            instructions = gcs.Key.instructions
                        }).ToList();
            }
            else if (opcion == "CC")
            {
                data = (from mc in db.MovimientoShipping
                        from inf in db.InfoFieldBook
                        where inf.cc == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPreparacion,
                            mc.cajaEnvio,
                            inf.order,
                            inf.breedersCode1,
                            inf.breedersCode2,
                            inf.breedersCode3,
                            inf.breedersCode4,
                            inf.crop,
                            inf.client,
                            inf.projecLead,
                            inf.location,
                            inf.opExpName,
                            inf.gmoEvent,
                            inf.sag,
                            inf.shelling,
                            inf.instructions
                        } into gcs
                        select new MovimientoShippingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPreparacion = gcs.Key.fechaPreparacion,
                            cajaEnvio = gcs.Key.cajaEnvio,
                            order = gcs.Key.order,
                            breedersCode1 = gcs.Key.breedersCode1,
                            breedersCode2 = gcs.Key.breedersCode2,
                            breedersCode3 = gcs.Key.breedersCode3,
                            breedersCode4 = gcs.Key.breedersCode4,
                            crop = gcs.Key.crop,
                            client = gcs.Key.client,
                            projecLead = gcs.Key.projecLead,
                            location = gcs.Key.location,
                            opExpName = gcs.Key.opExpName,
                            gmoEvent = gcs.Key.gmoEvent,
                            sag = gcs.Key.sag,
                            shelling = gcs.Key.shelling,
                            instructions = gcs.Key.instructions
                        }).ToList();
            }
            else if (opcion == "Año")
            {
                var anio = int.Parse(cadena);
                data = (from mc in db.MovimientoShipping
                        from inf in db.InfoFieldBook
                        where inf.year == anio && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPreparacion,
                            mc.cajaEnvio,
                            inf.order,
                            inf.breedersCode1,
                            inf.breedersCode2,
                            inf.breedersCode3,
                            inf.breedersCode4,
                            inf.crop,
                            inf.client,
                            inf.projecLead,
                            inf.location,
                            inf.opExpName,
                            inf.gmoEvent,
                            inf.sag,
                            inf.shelling,
                            inf.instructions
                        } into gcs
                        select new MovimientoShippingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPreparacion = gcs.Key.fechaPreparacion,
                            cajaEnvio = gcs.Key.cajaEnvio,
                            order = gcs.Key.order,
                            breedersCode1 = gcs.Key.breedersCode1,
                            breedersCode2 = gcs.Key.breedersCode2,
                            breedersCode3 = gcs.Key.breedersCode3,
                            breedersCode4 = gcs.Key.breedersCode4,
                            crop = gcs.Key.crop,
                            client = gcs.Key.client,
                            projecLead = gcs.Key.projecLead,
                            location = gcs.Key.location,
                            opExpName = gcs.Key.opExpName,
                            gmoEvent = gcs.Key.gmoEvent,
                            sag = gcs.Key.sag,
                            shelling = gcs.Key.shelling,
                            instructions = gcs.Key.instructions
                        }).ToList();
            }
            return data;
        }
        #endregion

    }
}
