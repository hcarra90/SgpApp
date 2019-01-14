using Layer.Business;
using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Layer.API.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return UsuarioBusiness.GetUsuarios();
        }
    }
}
