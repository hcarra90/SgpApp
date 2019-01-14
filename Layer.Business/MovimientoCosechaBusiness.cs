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
    public static class MovimientoCosechaBusiness
    {
        #region Declaración
        //static readonly IMovimientoCosechaRepository repository = new MovimientoCosechaRepository();
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<MovimientoCosecha> repository;
        private static Repository<InfoFieldBook> repositoryI;
        private static Repository<Usuario> repositoryU;

        #endregion


        #region Métodos Públicos
        /// <summary>
        /// Función que obtiene información del euid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MovimientoCosecha</returns>
        public static MovimientoCosecha GetEuidById(int id)
        {
            repository = unitOfWork.Repository<MovimientoCosecha>();
            var item = repository.Table.Where(mp => mp.Id == id).FirstOrDefault();
            return item;
        }

        /// <summary>
        /// Función que obtiene data de euids por Bin.
        /// </summary>
        /// <param name="bin">ShipTo</param>
        /// <returns>Devuelve un objeto de tipo String.</returns>
        public static List<MovimientoCosecha> GetEuidsByBin(string bin)
        {
            repository = unitOfWork.Repository<MovimientoCosecha>();
            var data= repository.Table.Where(mc => mc.Bin == bin).OrderByDescending(o=>o.fechaCosecha).ToList();
            return data;
        }

        /// <summary>
        /// Función que graba información de Euid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <returns>Devuelve un objeto de tipo MovimientoCosecha.</returns>
        public static MovimientoCosecha GrabaInformacion(MovimientoCosecha movimiento, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<MovimientoCosecha>();

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

        /// <summary>
        /// Función que elimina información de Eduid.
        /// </summary>
        /// <param name="euid">Euid</param>
        /// <returns></returns>
        public static void BorrarEuid(int id, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            repository = unitOfWork.Repository<MovimientoCosecha>();

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

        public static List<MovimientoCosechaDto> GetEuids(string cadena, string opcion)
        {
            repository = unitOfWork.Repository<MovimientoCosecha>();
            repositoryI = unitOfWork.Repository<InfoFieldBook>();
            List<MovimientoCosechaDto> data = new List<MovimientoCosechaDto>();

            if (opcion == "Euid" || opcion=="")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.euid equals inf.euid.ToString()
                        where inf.euid == cadena
                        select new MovimientoCosechaDto
                        {
                            Bin = mc.Bin,
                            FechaCosecha = mc.fechaCosecha,
                            Euid = mc.euid,
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
                            sag = inf.sag
                        }).ToList();
            }
            else if (opcion == "Ship To")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.euid equals inf.euid.ToString()
                        where inf.shipTo == cadena
                        select new MovimientoCosechaDto
                        {
                            Bin = mc.Bin,
                            FechaCosecha = mc.fechaCosecha,
                            Euid = mc.euid,
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
                            sag = inf.sag
                        }).ToList();
            }
            else if (opcion == "Project Lead")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.euid equals inf.euid.ToString()
                        where inf.projecLead == cadena
                        select new MovimientoCosechaDto
                        {
                            Bin = mc.Bin,
                            FechaCosecha = mc.fechaCosecha,
                            Euid = mc.euid,
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
                            sag = inf.sag
                        }).ToList();
            }
            else if (opcion == "Exp Name")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.euid equals inf.euid.ToString()
                        where inf.opExpName == cadena
                        select new MovimientoCosechaDto
                        {
                            Bin = mc.Bin,
                            FechaCosecha = mc.fechaCosecha,
                            Euid = mc.euid,
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
                            sag = inf.sag
                        }).ToList();
            }
            else if (opcion == "CC")
            {
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.euid equals inf.euid.ToString()
                        where inf.cc == cadena
                        select new MovimientoCosechaDto
                        {
                            Bin = mc.Bin,
                            FechaCosecha = mc.fechaCosecha,
                            Euid = mc.euid,
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
                            sag = inf.sag
                        }).ToList();
            }
            else if (opcion == "Año")
            {
                var anio = int.Parse(cadena);
                data = (from mc in repository.Table
                        join inf in repositoryI.Table on mc.euid equals inf.euid.ToString()
                        where inf.year == anio
                        select new MovimientoCosechaDto {
                            Bin=mc.Bin,
                            FechaCosecha=mc.fechaCosecha,
                            Euid=mc.euid,
                            order=inf.order,
                            breedersCode1=inf.breedersCode1,
                            breedersCode2 = inf.breedersCode2,
                            breedersCode3 = inf.breedersCode3,
                            breedersCode4 = inf.breedersCode4,
                            crop=inf.crop,
                            client=inf.client,
                            projecLead=inf.projecLead,
                            location=inf.location,
                            opExpName=inf.opExpName,
                            gmoEvent=inf.gmoEvent,
                            sag=inf.sag
                        }).ToList();
            }
            return data;
        }

        public static MovimientoCosecha GetBin(string bin)
        {
            repository = unitOfWork.Repository<MovimientoCosecha>();
            var item= repository.Table.Where(z => z.Bin == bin).FirstOrDefault();
            return item;
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

            repository = unitOfWork.Repository<MovimientoCosecha>();
            repositoryI = unitOfWork.Repository<InfoFieldBook>();
            repositoryU = unitOfWork.Repository<Usuario>();
            #endregion

            var data = (from mc in repository.Table
                        from us in repositoryU.Table
                        from inf in repositoryI.Table
                        where mc.fechaCosecha >= fechaInicio && mc.fechaCosecha <= fechaTermino
                        && mc.usuario == us.nombre_usuario && mc.euid == inf.euid 
                        orderby mc.fechaCosecha, us.nombre_usuario
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
                            mc.fechaCosecha,
                            us.nombre,
                            us.apellido
                        } into gcs
                        select new DetalleEficienciaDto
                        {
                            Client = gcs.Key.client,
                            Crop = gcs.Key.crop,
                            Euid = gcs.Key.euid,
                            ExpName = gcs.Key.opExpName,
                            FechaPacking = gcs.Key.fechaCosecha,
                            Fecha = (DateTime)DbFunctions.TruncateTime(gcs.Key.fechaCosecha),
                            Time = (TimeSpan)DbFunctions.CreateTime(gcs.Key.fechaCosecha.Hour, gcs.Key.fechaCosecha.Minute, gcs.Key.fechaCosecha.Second),
                            GmoEvent = gcs.Key.gmoEvent,
                            Location = gcs.Key.location,
                            ProjectLead = gcs.Key.projecLead,
                            Sag = gcs.Key.sag,
                            Usuario = gcs.Key.usuario,
                            NombreCompleto = gcs.Key.nombre + " " + gcs.Key.apellido
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
            }

            return eficienciaTotal;
        }
        #endregion
    }
}
