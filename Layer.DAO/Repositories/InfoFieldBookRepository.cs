using Layer.DAO.Interface;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DAO.Repositories
{
    /// <summary>
    /// Clase que implementa las operaciones de la tabla InfoFieldBookRepository
    /// </summary>
    public class InfoFieldBookRepository : GenericRepository<DataContext, InfoFieldBook>, IInfoFieldBookRepository
    {
        #region Declaración
        readonly DataContext db;
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private static Repository<InfoFieldBook> repository;
        private static Repository<MovimientoShipping> repositoryS;
        #endregion

        #region Constructores
        public InfoFieldBookRepository()
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
        public List<InfoFieldBook> GetEuid(string cadena,string opcion)
        {
            List<InfoFieldBook> euidsEncontrados = new List<InfoFieldBook>();

            if (opcion == "Euid" || opcion =="")
            {

                euidsEncontrados = (from ue in db.InfoFieldBook
                                    where ue.euid == cadena
                                    select ue).ToList();
            }
            else if (opcion == "Ship To")
            {
                euidsEncontrados = (from ue in db.InfoFieldBook
                                    where ue.shipTo == cadena
                                    select ue).ToList();
            }
            else if (opcion == "Project Lead")
            {
                euidsEncontrados = (from ue in db.InfoFieldBook
                                    where ue.projecLead == cadena
                                    select ue).ToList();
            }
            else if (opcion == "Exp Name")
            {
                euidsEncontrados = (from ue in db.InfoFieldBook
                                    where ue.opExpName == cadena
                                    select ue).ToList();
            }
            else if (opcion == "CC")
            {
                euidsEncontrados = (from ue in db.InfoFieldBook
                                    where ue.cc == cadena
                                    select ue).ToList();
            }
            else if (opcion == "Año")
            {
                var anio = int.Parse(cadena);
                euidsEncontrados = (from ue in db.InfoFieldBook
                                    where ue.year == anio
                                    select ue).ToList();
            }
            return euidsEncontrados;
        }

        /// <summary>
        /// Función que obtiene información del ind euid.
        /// </summary>
        /// <param name="indEuid"></param>
        /// <returns>InfoFieldBook</returns>
        public InfoFieldBook GetIndEuid(string indEuid,string euid)
        {
            var euidEncontrado = (from ue in db.InfoFieldBook
                                    where (ue.indEuid == indEuid || indEuid =="") && (ue.euid == euid || euid == "")
                                    select ue).FirstOrDefault();

            return euidEncontrado;
        }

        public string GetSecuenciaIndEuid(string euid)
        {
            string secuencia = "";

            var euidEncontrado = (from InfoFieldBook in db.InfoFieldBook
                                   where
                                     InfoFieldBook.euid == euid
                                   orderby
                                     InfoFieldBook.indEuid.Substring((int)InfoFieldBook.indEuid.ToUpper().IndexOf("_".ToUpper()) + 1 + 1 - 1, (int)InfoFieldBook.indEuid.Length) descending
                                   select new
                                   {
                                       Secuencia = InfoFieldBook.indEuid.Substring((int)InfoFieldBook.indEuid.ToUpper().IndexOf("_".ToUpper()) + 1 + 1 - 1, (int)InfoFieldBook.indEuid.Length)
                                   }).ToList();

            try
            {
                if (euidEncontrado.Count > 0)
                {
                    var sec = euidEncontrado.ToList()[euidEncontrado.Count - 1].Secuencia;
                    if (sec != null && sec != "")
                    {
                        secuencia = (int.Parse(euidEncontrado.ToList()[euidEncontrado.Count - 1].Secuencia) + 1).ToString();
                    }
                    else
                    {
                        secuencia = "1";
                    } 
                }
                else
                {
                    secuencia = "1";
                }
                
            }
            catch (Exception ex)
            {
                secuencia="XX";
            }

            return secuencia;
        }

        /// <summary>
        /// Función que obtiene información de project lead.
        /// </summary>
        /// <param name=""></param>
        /// <returns>InfoFieldBook</returns>
        public List<ProjectLeadDto> GetProjectLead()
        {
            var allData=(from pl in db.InfoFieldBook
                    where pl.projecLead != null
                    orderby pl.projecLead
                    group pl by pl.projecLead into g
                    select new ProjectLeadDto
                    {
                        projectLead = g.Key
                    }).ToList();

            allData.Insert(0, new ProjectLeadDto { projectLead = "" });

            return allData;
        }

        /// <summary>
        /// Función que obtiene información de Años.
        /// </summary>
        /// <param name=""></param>
        /// <returns>InfoFieldBook</returns>
        public List<AnioDto> GetAnio()
        {
            var obj = new AnioDto { anio = "" };
            var allData = (from pl in db.InfoFieldBook
                           where pl.year != null
                           orderby pl.year
                           group pl by pl.year into g
                           select new AnioDto
                           {
                               anio = g.Key.ToString()??""
                           }).ToList();

            allData = allData.OrderBy(d => d.anio).ToList();
            
            if (allData[0].anio != "")
            {
                allData.Insert(0, obj);
            }

            return allData;
        }

        /// <summary>
        /// Función que obtiene información de CC.
        /// </summary>
        /// <param name=""></param>
        /// <returns>InfoFieldBook</returns>
        public List<CCDto> GetCc()
        {
            var obj= new CCDto { cc = "" };
            var allData = (from pl in db.InfoFieldBook
                           where pl.cc != null
                           orderby pl.cc
                           group pl by pl.cc into g
                           select new CCDto
                           {
                               cc = g.Key.ToString()??""
                           }).ToList();
            allData = allData.OrderBy(d => d.cc).ToList();
            var x = allData.Find(o => o.cc.Contains(""));
            if (x==null)
            {
                allData.Insert(0, obj);
            }

            return allData;
        }

        /// <summary>
        /// Función que obtiene información de CC.
        /// </summary>
        /// <param name=""></param>
        /// <returns>InfoFieldBook</returns>
        public List<ExpNameDto> GetExpName()
        {
            var obj = new ExpNameDto { expName = "" };
            var allData = (from pl in db.InfoFieldBook
                           where pl.opExpName != null
                           orderby pl.opExpName
                           group pl by pl.opExpName into g
                           select new ExpNameDto
                           {
                               expName = g.Key.ToString()
                           }).ToList();

            allData = allData.OrderBy(d => d.expName).ToList();
            var x = allData.Find(o => o.expName.Contains(""));
            if (x == null)
            {
                allData.Insert(0, new ExpNameDto { expName = "" });
            }

            return allData;
        }

        public InfoFieldBook GetRowById(int id)
        {
            repository = unitOfWork.Repository<InfoFieldBook>();
            var euidEncontrado = (from ue in repository.Table
                                  where ue.Id == id
                                  select ue).FirstOrDefault();

            return euidEncontrado;
        }

        public bool ValidateEuids(List<SplitEuidDto> data)
        {
            repository = unitOfWork.Repository<InfoFieldBook>();
            var euidsG = (from e in repository.Table
                          select new
                          {
                              Euid = e.euid
                          }).ToList();

            var euidsC = (from ec in data
                          select new
                          {
                              euid = ec.Euid
                          }).ToList();

            var result = euidsG.Where(p => euidsC.Any(p2 => p2.euid == p.Euid)).ToList();

            return result.Count > 0;
        }
        #endregion

        public void Insert(InfoFieldBook movimiento)
        {
            repository = unitOfWork.Repository<InfoFieldBook>();
            repository.Insert(movimiento);
        }

        public void Update(InfoFieldBook movimiento)
        {
            repository = unitOfWork.Repository<InfoFieldBook>();
            repository.Update(movimiento);
            
        }

        public bool ValidateIndEuids(List<InfoFieldBook> data)
        {
            repository = unitOfWork.Repository<InfoFieldBook>();
            var euidsG = (from e in repository.Table
                          select new
                          {
                              indEuid = e.indEuid
                          }).ToList();

            var euidsC = (from ec in data
                          select new
                          {
                              indEuid = ec.indEuid
                          }).ToList();

            var result = euidsG.Where(p => euidsC.Any(p2 => p2.indEuid == p.indEuid)).ToList();

            return result.Count > 0;
        }

        public bool GetValidateEuidPacking(string indEuid, string euid)
        {
            bool encontrado = false;
            repositoryS = unitOfWork.Repository<MovimientoShipping>();
            MovimientoShipping ms = new MovimientoShipping();

            if (indEuid == "")
            {
                ms = (from ue in repositoryS.Table
                                      where ue.euid == euid
                                      select ue).FirstOrDefault();
            }
            else if (indEuid != "" && euid != "")
            {
                ms = (from ue in repositoryS.Table
                      where ue.indEuid == indEuid
                      select ue).FirstOrDefault();
            }
            encontrado = (ms != null);
            

            return encontrado;
        }


        public void InsertBulk(List<InfoFieldBook> entities)
        {
            repository = unitOfWork.Repository<InfoFieldBook>();
            repository.InsertBulk(entities);
        }
    }
}
