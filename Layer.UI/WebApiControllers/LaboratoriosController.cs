using Layer.Business;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Layer.UI.WebApiControllers
{
      [RoutePrefix("api/laboratorios")]
      public class LaboratoriosController : ApiController
      {
            [Route("GetLaboratios")]
            [HttpPost]
            public HttpResponseMessage GetLaboratorios(HttpRequestMessage request, [FromBody] LaboratorioInformation laboratorioInformation)
            {
                List<Laboratorio> laboratorios = new List<Laboratorio>();
                TransactionalInformation transaction = new TransactionalInformation();

                string estado = laboratorioInformation.Estado;
                int currentPageNumber = laboratorioInformation.CurrentPageNumber;
                int pageSize = laboratorioInformation.PageSize;
                string sortExpression = laboratorioInformation.SortExpression;
                string sortDirection = laboratorioInformation.SortDirection;
                int totalrows = 0;

                laboratorios = LaboratorioBusiness.GetLaboratorios(estado,currentPageNumber,pageSize,sortDirection,sortExpression, out transaction,out totalrows);
                if (transaction.ReturnStatus == false)
                {
                  var badResponse = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                  return badResponse;
                }

                  laboratorioInformation = new LaboratorioInformation();
                  laboratorioInformation.ReturnStatus = transaction.ReturnStatus;
                  laboratorioInformation.TotalRows = totalrows;
                  laboratorioInformation.TotalPages = Functions.Utilities.CalculaTotalPaginas(totalrows,pageSize);
                  laboratorioInformation.ReturnMessage.Add("page " + currentPageNumber + " of " + laboratorioInformation.TotalPages + " returnes at " + DateTime.Now.ToString());
                  laboratorioInformation.Laboratorios = laboratorios;

                  var response = Request.CreateResponse<LaboratorioInformation>(HttpStatusCode.OK, laboratorioInformation);
                  return response;
            }
      }
}
