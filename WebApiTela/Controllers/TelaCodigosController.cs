using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTela.Models;

namespace WebApiTela.Controllers
{
    public class TelaCodigosController : ApiController
    {

        DBTelaEntities db = new DBTelaEntities();

        public IHttpActionResult getCodigosXidcontenedor(int idcontenedor)
        {
            var lista = db.GetCodigosxidcontenedor(idcontenedor).Select(x=>new { x.idtpc,x.procod,x.idcontenedor}).ToList();

            return Ok(lista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
