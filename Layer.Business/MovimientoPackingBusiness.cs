using Layer.DAO;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace Layer.Business
{
    public static class MovimientoPackingBusiness
    {
        #region Declaración
        //static readonly IMovimientoPackingRepository repository = new MovimientoPackingRepository();
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoPacking> repository;
        private static Repository<InfoFieldBook> repositoryI;
        private static Repository<EntryList> repositoryE;
        private static Repository<MovimientoRogging> repositoryR;
        private static Repository<Usuario> repositoryU;
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Función que obtiene información de Eduid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <returns>Devuelve un objeto de tipo MovimientoPacking.</returns>
        public static MovimientoPacking GetEuid(string indEuid, string euid)
        {
            repository = unitOfWork.Repository<MovimientoPacking>();
            var item = repository.Table.Where(mc => mc.euid == euid && mc.indEuid == indEuid).FirstOrDefault();

            return item;
        }

        /// <summary>
        /// Función que graba información de Eduid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <returns>Devuelve un objeto de tipo MovimientoPacking.</returns>
        public static MovimientoPacking GrabaInformacion(MovimientoPacking movimientoPacking, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            try
            {
                if (movimientoPacking.Id == 0)
                {
                    repository.Insert(movimientoPacking);
                }
                else
                {
                    repository.Update(movimientoPacking);
                }
            }
            catch (Exception ex)
            {
                transaction.ReturnStatus=false;
                transaction.ReturnMessage = "Error: " + ex.Message;
            }
            
            return movimientoPacking;
        }

        public static List<MovimientoPackingDto> GetEuids(string cadena, string opcion)
        {
            repository = unitOfWork.Repository<MovimientoPacking>();
            repositoryI = unitOfWork.Repository<InfoFieldBook>();
            List<MovimientoPackingDto> data = new List<MovimientoPackingDto>();

            if (opcion == "Euid" || opcion == "")
            {

                data = (from mc in repository.Table
                        from inf in repositoryI.Table
                        where mc.euid == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        select new MovimientoPackingDto
                        {
                            euid = mc.euid.ToString(),
                            indEuid = mc.indEuid,
                            fechaPacking = mc.fechaPacking,
                            totalWeight = mc.totalWeight.ToString(),
                            totalKernels = mc.totalKernels.ToString(),
                            totalEars = mc.totalEars.ToString(),
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
                data = (from mc in repository.Table
                        from inf in repositoryI.Table
                        where inf.shipTo == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPacking,
                            mc.totalWeight,
                            mc.totalKernels,
                            mc.totalEars,
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
                        select new MovimientoPackingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPacking = gcs.Key.fechaPacking,
                            totalWeight = gcs.Key.totalWeight.ToString(),
                            totalKernels = gcs.Key.totalKernels.ToString(),
                            totalEars = gcs.Key.totalEars.ToString(),
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
                data = (from mc in repository.Table
                        from inf in repositoryI.Table
                        where inf.projecLead == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPacking,
                            mc.totalWeight,
                            mc.totalKernels,
                            mc.totalEars,
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
                        select new MovimientoPackingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPacking = gcs.Key.fechaPacking,
                            totalWeight = gcs.Key.totalWeight.ToString(),
                            totalKernels = gcs.Key.totalKernels.ToString(),
                            totalEars = gcs.Key.totalEars.ToString(),
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
                data = (from mc in repository.Table
                        from inf in repositoryI.Table
                        where inf.opExpName == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPacking,
                            mc.totalWeight,
                            mc.totalKernels,
                            mc.totalEars,
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
                        select new MovimientoPackingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPacking = gcs.Key.fechaPacking,
                            totalWeight = gcs.Key.totalWeight.ToString(),
                            totalKernels = gcs.Key.totalKernels.ToString(),
                            totalEars = gcs.Key.totalEars.ToString(),
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
                data = (from mc in repository.Table
                        from inf in repositoryI.Table
                        where inf.cc == cadena && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPacking,
                            mc.totalWeight,
                            mc.totalKernels,
                            mc.totalEars,
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
                        select new MovimientoPackingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPacking = gcs.Key.fechaPacking,
                            totalWeight = gcs.Key.totalWeight.ToString(),
                            totalKernels = gcs.Key.totalKernels.ToString(),
                            totalEars = gcs.Key.totalEars.ToString(),
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
                data = (from mc in repository.Table
                        from inf in repositoryI.Table 
                        where inf.year == anio && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        group mc by new
                        {
                            mc.euid,
                            mc.indEuid,
                            mc.fechaPacking,
                            mc.totalWeight,
                            mc.totalKernels,
                            mc.totalEars,
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
                        select new MovimientoPackingDto
                        {
                            euid = gcs.Key.euid,
                            indEuid = gcs.Key.indEuid,
                            fechaPacking = gcs.Key.fechaPacking,
                            totalWeight = gcs.Key.totalWeight.ToString(),
                            totalKernels = gcs.Key.totalKernels.ToString(),
                            totalEars = gcs.Key.totalEars.ToString(),
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

        public static List<PackingPorDiaDto> GetEuidsByDay()
        {
            repository = unitOfWork.Repository<MovimientoPacking>();
            var data = (from mc in repository.Table
                            //where mc.fechaDesgrane.Date >= inicio && mc.fechaDesgrane.Date <= termino
                        group mc by System.Data.Entity.DbFunctions.TruncateTime(mc.fechaPacking) into g
                        select new PackingPorDiaDto
                        {
                            Fecha = g.Key.Value,
                            NumeroEuid = g.Count().ToString()
                        }).ToList();

            return data;
        }

        public static EficienciaPorDiaDto GetEfficiencyPerDay(DateTime fechaInicio, DateTime fechaTermino)
        {
            #region Declaración
            EficienciaPorDiaDto eficienciaTotal = new EficienciaPorDiaDto();
            List<DetalleEficienciaDto> lista = new List<DetalleEficienciaDto>();
            DetalleEficienciaDto eficiencia = new DetalleEficienciaDto();
            DetalleEficienciaDto separador = new DetalleEficienciaDto();

            ResumenEficienciaDto resumen = new ResumenEficienciaDto();
            List<ResumenEficienciaDto> listaResumen = new List<ResumenEficienciaDto>();

            bool primerUsuario = true;
            bool primeraFila = true;
            int sTotalE = 0;
            int sTotalI = 0;
            int totalE = 0;
            int totalI = 0;
            TimeSpan horaI = new TimeSpan();
            TimeSpan horaF = new TimeSpan();
            TimeSpan totalHora = new TimeSpan();
            TimeSpan paramEuidHora = new TimeSpan(1,0,0);
            string usuario = "";
            DateTime dateT = new DateTime();

            repository = unitOfWork.Repository<MovimientoPacking>();
            repositoryI = unitOfWork.Repository<InfoFieldBook>();
            repositoryU = unitOfWork.Repository<Usuario>(); 
            #endregion

            var data = (from mc in repository.Table
                        from us in repositoryU.Table
                        from inf in repositoryI.Table
                        where mc.fechaPacking >= fechaInicio && mc.fechaPacking <= fechaTermino
                        && mc.usuario == us.nombre_usuario && mc.euid == inf.euid && (mc.indEuid == inf.indEuid || mc.indEuid == "")
                        //orderby DbFunctions.TruncateTime(mc.fechaPacking)
                        //orderby mc.usuario
                        select new DetalleEficienciaDto
                        {
                            Client = inf.client,
                            Crop = inf.crop,
                            Euid = mc.euid,
                            ExpName = inf.opExpName,
                            FechaPacking = mc.fechaPacking,
                            Fecha = (DateTime)DbFunctions.TruncateTime(mc.fechaPacking),
                            Time = (TimeSpan)DbFunctions.CreateTime(mc.fechaPacking.Hour, mc.fechaPacking.Minute, mc.fechaPacking.Second),
                            GmoEvent = inf.gmoEvent,
                            IndEuid = mc.indEuid,
                            Location = inf.location,
                            ProjectLead = inf.projecLead,
                            Sag = inf.sag,
                            Usuario = mc.usuario,
                            NombreCompleto = ""
                        }).ToList();

            data = data.OrderBy(o => o.Fecha).ThenBy(o => o.FechaPacking).ThenBy(o => o.Usuario).ToList();

            foreach (var item in data)
            {
                if (dateT != item.Fecha)
                {
                    eficiencia.Fecha = item.Fecha;
                    eficiencia.FechaPacking = item.FechaPacking;
                    eficiencia.Usuario = item.Usuario;
                    if (primeraFila)
                    {
                        horaI = item.Time;
                    }

                    if (!primerUsuario)
                    {
                        //Detalle
                        horaF = lista[lista.Count - 1].Time;
                        separador = new DetalleEficienciaDto();
                        separador.Usuario = "Sub Total";
                        separador.Euid = sTotalE.ToString("N0", CultureInfo.CurrentCulture);
                        separador.IndEuid = sTotalI.ToString("N0", CultureInfo.CurrentCulture);
                        separador.Time = horaF.Subtract(horaI);
                        totalHora = totalHora.Add(separador.Time);
                        if (separador.Time.TotalMinutes > 0)
                        {
                            var euidHora = 3600 / ((separador.Time.TotalMinutes / sTotalE) * 60);
                            separador.EuidHora = euidHora.ToString("N0", CultureInfo.CurrentCulture);

                        }
                        sTotalE = 0;
                        sTotalI = 0;
                        horaI = item.Time;

                        lista.Add(separador);

                        //Resumen
                        resumen = new ResumenEficienciaDto();
                        resumen.Usuario = item.Usuario;
                        resumen.Fecha = dateT;
                        resumen.Hora = separador.Time;
                        resumen.NumeroEuid = separador.Euid;
                        resumen.NumeroIndEuid = separador.IndEuid;
                        resumen.EuidHora = separador.EuidHora??"0";
                        listaResumen.Add(resumen);
                    
                    }
                    primerUsuario = false;
                    dateT = item.Fecha;
                }

                if (usuario != item.Usuario)
                {
                    if (!primeraFila)
                    {
                        //Detalle
                        horaF = lista[lista.Count - 1].Time;
                        separador = new DetalleEficienciaDto();
                        separador.Usuario = "Sub Total";
                        separador.Euid = sTotalE.ToString("N0", CultureInfo.CurrentCulture);
                        separador.IndEuid = sTotalI.ToString("N0", CultureInfo.CurrentCulture);
                        separador.Time = horaF.Subtract(horaI);
                        totalHora = totalHora.Add(separador.Time);
                        if (separador.Time.TotalMinutes > 0)
                        {
                            var euidHora = 3600 / ((separador.Time.TotalMinutes / sTotalE) * 60);
                            separador.EuidHora = euidHora.ToString("N0", CultureInfo.CurrentCulture);
                        }
                        sTotalE = 0;
                        sTotalI = 0;
                        horaI = item.Time;
                        
                        lista.Add(separador);

                        //Resumen
                        resumen = new ResumenEficienciaDto();
                        resumen.Usuario = usuario;
                        resumen.Fecha = item.Fecha;
                        resumen.Hora = separador.Time;
                        resumen.NumeroEuid = separador.Euid;
                        resumen.NumeroIndEuid = separador.IndEuid;
                        resumen.EuidHora = separador.EuidHora??"0";
                        listaResumen.Add(resumen);
                    }

                    eficiencia.Usuario = item.Usuario;
                    usuario = item.Usuario;
                }

                eficiencia.Euid = item.Euid;
                eficiencia.IndEuid = item.IndEuid;
                eficiencia.Crop = item.Crop;
                eficiencia.Client = item.Client;
                eficiencia.ProjectLead = item.ProjectLead;
                eficiencia.Location = item.Location;
                eficiencia.ExpName = item.ExpName;
                eficiencia.GmoEvent = item.GmoEvent;
                eficiencia.Sag = item.Sag;
                eficiencia.Time = item.Time;

                if (eficiencia.Euid !="")
                {
                    sTotalE++;
                    totalE++;
                }
                if (eficiencia.IndEuid != "")
                {
                    sTotalI++;
                    totalI++;
                }
                
                lista.Add(eficiencia);
                eficiencia = new DetalleEficienciaDto();
                primeraFila = false;
            }

            //Detalle
            separador = new DetalleEficienciaDto();
            horaF = lista[lista.Count - 1].Time;
            separador.Usuario = "Sub Total";
            separador.Euid = sTotalE.ToString("N0", CultureInfo.CurrentCulture);
            separador.IndEuid = sTotalI.ToString("N0", CultureInfo.CurrentCulture);
            separador.Time = horaF.Subtract(horaI);
            if (separador.Time.TotalMinutes > 0)
            {
                var euidHora = 3600 / ((separador.Time.TotalMinutes / sTotalE) * 60);
                separador.EuidHora = euidHora.ToString("N0", CultureInfo.CurrentCulture);
            }
            totalHora = totalHora.Add(separador.Time);
            sTotalE = 0;
            sTotalI = 0;
            lista.Add(separador);

            //Resumen
            resumen = new ResumenEficienciaDto();
            resumen.Usuario = usuario;
            resumen.Fecha = dateT;
            resumen.Hora = separador.Time;
            resumen.NumeroEuid = separador.Euid;
            resumen.NumeroIndEuid = separador.IndEuid;
            resumen.EuidHora = separador.EuidHora??"0";
            listaResumen.Add(resumen);

            //Total

            separador = new DetalleEficienciaDto();
            separador.Usuario = "Total";
            separador.Euid = totalE.ToString("N0", CultureInfo.CurrentCulture);
            separador.IndEuid = totalI.ToString("N0", CultureInfo.CurrentCulture);
            separador.Time = totalHora;
            if (separador.Time.TotalMinutes > 0)
            {
                var euidHora = 3600 / ((separador.Time.TotalMinutes / totalE) * 60);
                separador.EuidHora = euidHora.ToString("N0", CultureInfo.CurrentCulture);
            }
            lista.Add(separador);

            
            //Detalle y Resumen
            eficienciaTotal.Detalle = lista;
            eficienciaTotal.Resumen = listaResumen;

            return eficienciaTotal;
        }

        public static List<ResumenGraficoPackingDto> GetDataGraficoPacking(string projectLead, int anio)
        {
            repository = unitOfWork.Repository<MovimientoPacking>();
            repositoryI = unitOfWork.Repository<InfoFieldBook>();
            repositoryR = unitOfWork.Repository<MovimientoRogging>();
            repositoryE = unitOfWork.Repository<EntryList>();

            var ResumenExperimento = (from el in repositoryE.Table
                                  join mr in repositoryR.Table on el.Euid equals mr.Euid into mr_join
                                  from mr in mr_join.DefaultIfEmpty()
                                  join ifb in repositoryI.Table on el.Euid equals ifb.euid
                                  where
                                    el.ProjectLead == projectLead &&
                                    el.Year == anio
                                  group new { el, mr, ifb } by new
                                  {
                                      el.ExpName
                                  } into g
                                  orderby
                                    g.Key.ExpName
                                  select new ResumenGraficoPackingDto
                                  {
                                      Experimento=g.Key.ExpName,
                                      CountEuid = g.Count(p => p.el.Euid != null),
                                      EuidRog = g.Count(p => p.mr.Euid != null),
                                      CountIndEuid = g.Count(p => p.ifb.indEuid != null)
                                  }).ToList();

            if (ResumenExperimento.Count > 0)
            {
                ResumenExperimento[0].TotalEuid = ResumenExperimento.Sum(p => p.CountEuid);
                ResumenExperimento[0].TotalIndEuid = ResumenExperimento.Sum(p => p.CountIndEuid);
            }

            foreach (var item in ResumenExperimento)
            {
                var DetallePacking = (from mp in repository.Table
                                      join ifb in repositoryI.Table on mp.euid equals ifb.euid
                                      where
                                        ifb.opExpName == item.Experimento &&
                                        ifb.projecLead == projectLead &&
                                        ifb.year == anio
                                      select new
                                      {
                                          id_movimiento_packing = mp.Id,
                                          euid = mp.euid,
                                          ind_euid = mp.indEuid,
                                          fecha_packing = mp.fechaPacking,
                                          total_weight = mp.totalWeight,
                                          total_kernels = mp.totalKernels,
                                          total_ears = mp.totalEars,
                                          usuario = mp.usuario
                                      }).ToList();
                item.PackIndEuid = DetallePacking.Count();

                var po = (item.CountIndEuid ==0)?0:(item.PackIndEuid / item.CountIndEuid);
                item.PorcentajeProcesado = po;
            }

            return ResumenExperimento;
        }
        #endregion
    }
}
