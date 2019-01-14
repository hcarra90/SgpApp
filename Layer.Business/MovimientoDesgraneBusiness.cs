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
    public static class MovimientoDesgraneBusiness
    {
        #region Declaración
        //static readonly IMovimientoDesgraneRepository repository = new MovimientoDesgraneRepository();
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoDesgrane> repository;
        private static Repository<InfoFieldBook> repositoryI;
        private static Repository<Usuario> repositoryU;
        #endregion

        #region Métodos Públicos
        public static MovimientoDesgrane GetEuid(string euid, string desgranadora)
        {
            repository = unitOfWork.Repository<MovimientoDesgrane>();
            var item = repository.Table.Where(mc => mc.euid == euid && mc.sheller == desgranadora).FirstOrDefault();

            return item;
        }

        /// <summary>
        /// Función que graba información de Euid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <returns>Devuelve un objeto de tipo MovimientoDesgrane.</returns>
        public static MovimientoDesgrane GrabaInformacion(MovimientoDesgrane movimiento, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

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

        public static List<MovimientoDesgraneDto> GetEuids(string cadena,string opcion)
        {
            repository = unitOfWork.Repository<MovimientoDesgrane>();
            repositoryI = unitOfWork.Repository<InfoFieldBook>();
            List<MovimientoDesgraneDto> data = new List<MovimientoDesgraneDto>();

            if (opcion == "Euid" || opcion == "")
            {
                
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.euid equals inf.euid.ToString()
                        where mc.euid ==cadena

                        select new MovimientoDesgraneDto
                        {
                            euid=mc.euid.ToString(),
                            fecha=mc.fechaDesgrane,
                            sheller=mc.sheller,
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
                            shelling=inf.shelling,
                            instructions=inf.instructions
                        }).ToList();
            }
            else if (opcion == "Ship To")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.euid equals inf.euid
                        where inf.shipTo == cadena
                        group mc by new
                        {
                           mc.euid,
                           mc.fechaDesgrane,
                           mc.sheller,
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
                        select new MovimientoDesgraneDto
                        {
                            euid = gcs.Key.euid.ToString(),
                            fecha = gcs.Key.fechaDesgrane,
                            sheller = gcs.Key.sheller,
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
                        join inf in repositoryI.Table on mc.euid equals inf.euid
                        where inf.projecLead == cadena
                        group mc by new
                        {
                            mc.euid,
                            mc.fechaDesgrane,
                            mc.sheller,
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
                        select new MovimientoDesgraneDto
                        {
                            euid = gcs.Key.euid.ToString(),
                            fecha = gcs.Key.fechaDesgrane,
                            sheller = gcs.Key.sheller,
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
                        join inf in repositoryI.Table on mc.euid equals inf.euid
                        where inf.opExpName == cadena
                        group mc by new
                        {
                            mc.euid,
                            mc.fechaDesgrane,
                            mc.sheller,
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
                        select new MovimientoDesgraneDto
                        {
                            euid = gcs.Key.euid.ToString(),
                            fecha = gcs.Key.fechaDesgrane,
                            sheller = gcs.Key.sheller,
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
                        join inf in repositoryI.Table on mc.euid equals inf.euid
                        where inf.cc == cadena
                        group mc by new
                        {
                            mc.euid,
                            mc.fechaDesgrane,
                            mc.sheller,
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
                        select new MovimientoDesgraneDto
                        {
                            euid = gcs.Key.euid.ToString(),
                            fecha = gcs.Key.fechaDesgrane,
                            sheller = gcs.Key.sheller,
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
                        join inf in repositoryI.Table on mc.euid equals inf.euid
                        where inf.year == anio
                        group mc by new
                        {
                            mc.euid,
                            mc.fechaDesgrane,
                            mc.sheller,
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
                        select new MovimientoDesgraneDto
                        {
                            euid = gcs.Key.euid.ToString(),
                            fecha = gcs.Key.fechaDesgrane,
                            sheller = gcs.Key.sheller,
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

        public static List<MovimientoDesgrane> GetEuidsBySheller(string sheller)
        {
            repository = unitOfWork.Repository<MovimientoDesgrane>();
            var data = repository.Table.Where(mc => mc.sheller == sheller).OrderByDescending(o=>o.fechaDesgrane).ToList();

            return data;
        }

        public static List<DesgranePorDiaDto> GetEuidsByDay()
        {
            repository = unitOfWork.Repository<MovimientoDesgrane>();
            var data = (from mc in repository.Table
                            //where mc.fechaDesgrane.Date >= inicio && mc.fechaDesgrane.Date <= termino
                        group mc by System.Data.Entity.DbFunctions.TruncateTime(mc.fechaDesgrane) into g
                        select new DesgranePorDiaDto
                        {
                            Fecha=g.Key.Value,
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
            TimeSpan paramEuidHora = new TimeSpan(1, 0, 0);
            string usuario = "";
            DateTime dateT = new DateTime();

            repository = unitOfWork.Repository<MovimientoDesgrane>();
            repositoryI = unitOfWork.Repository<InfoFieldBook>();
            repositoryU = unitOfWork.Repository<Usuario>();
            #endregion

            var data = (from mc in repository.Table
                        from us in repositoryU.Table
                        from inf in repositoryI.Table
                        where mc.fechaDesgrane >= fechaInicio && mc.fechaDesgrane <= fechaTermino
                        && mc.usuario == us.nombre_usuario && mc.euid == inf.euid
                        orderby mc.fechaDesgrane, us.nombre_usuario
                        group mc by new
                        {
                            inf.euid,
                            inf.crop,
                            inf.client,
                            inf.gmoEvent,
                            inf.opExpName,
                            inf.location,
                            inf.projecLead,
                            inf.sag,
                            mc.usuario,
                            mc.fechaDesgrane,
                            us.nombre,
                            us.apellido,
                            mc.sheller
                        } into gcs
                        select new DetalleEficienciaDto
                        {
                            Client = gcs.Key.client,
                            Crop = gcs.Key.crop,
                            Euid = gcs.Key.euid,
                            ExpName = gcs.Key.opExpName,
                            FechaPacking = gcs.Key.fechaDesgrane,
                            Fecha = (DateTime)DbFunctions.TruncateTime(gcs.Key.fechaDesgrane),
                            Time = (TimeSpan)DbFunctions.CreateTime(gcs.Key.fechaDesgrane.Hour, gcs.Key.fechaDesgrane.Minute, gcs.Key.fechaDesgrane.Second),
                            GmoEvent = gcs.Key.gmoEvent,
                            Location = gcs.Key.location,
                            ProjectLead = gcs.Key.projecLead,
                            Sag = gcs.Key.sag,
                            Usuario = gcs.Key.usuario,
                            NombreCompleto = gcs.Key.nombre + " " + gcs.Key.apellido,
                            Sheller = gcs.Key.sheller
                        }).ToList();

            if (data.Count > 0)
            {
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
                            resumen.EuidHora = separador.EuidHora ?? "0";
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
                            resumen.EuidHora = separador.EuidHora ?? "0";
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
                    eficiencia.Sheller = item.Sheller;
                }
                if (eficiencia.Euid != "")
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
            resumen.EuidHora = separador.EuidHora ?? "0";
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

        #endregion
    }
}
