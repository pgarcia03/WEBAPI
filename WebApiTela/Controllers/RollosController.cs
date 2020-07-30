using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTela.Models;

namespace WebApiTela.Controllers
{
    public class RollosController : ApiController
    {
        DBTelaEntities db = new DBTelaEntities();

        //llamar  http://test/example2?id1=1&id2=2&id3=3
        public IHttpActionResult GetrollosXidContenedortpc(int idcontenedor,int idtpc)
        {
            var lista = db.GetRollosxidcontenedortpc(idcontenedor,idtpc).Select(x=>new { x.idrollo,x.rolloName,x.sec,x.estado,x.idcontenedor,x.proceso,x.idtpc,x.ancho }).ToList();

            return Ok(lista);

        }

        public IHttpActionResult GetrollosXidContenedor(int idcontenedor)
        {
            var lista = db.GetRollosxidcontenedor(idcontenedor).Select(x => new { x.idrollo, x.rolloName, x.sec, x.estado, x.idcontenedor, x.proceso, x.idtpc, x.ancho }).ToList();

            return Ok(lista);

        }

       
        [Route("api/rollos/ancho")]
        public IHttpActionResult GetrollosXidContenedortpc_Ancho(int idcontenedor, int idtpc)
        {
            var lista = db.GetRollosxidcontenedortpc_Ancho(idcontenedor, idtpc).Select(x => new { x.idrollo, x.rolloName, x.sec, x.estado, x.idcontenedor, x.proceso, x.idtpc, x.ancho }).ToList();

            return Ok(lista);

        }

        [Route("api/rollos/ancho")]
        public IHttpActionResult GetrollosXidContenedortpc_Ancho(int idcontenedor)
        {
            var lista = db.GetRollosxidcontenedor_Ancho(idcontenedor).Select(x => new { x.idrollo, x.rolloName, x.sec, x.estado, x.idcontenedor, x.proceso, x.idtpc, x.ancho }).ToList();

            return Ok(lista);

        }

        // PUT: api/Rollos
        [ResponseType(typeof(tbrollos))]
        public IHttpActionResult PutRollos(int id, tbrollos tbrollos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbrollos.idrollo)
            {
                return BadRequest();
            }

            var objrollo = db.tbrollos.Find(id);

            objrollo.ancho = tbrollos.ancho;

            //db.Entry(tbrollos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbrollosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        private bool tbrollosExists(int id)
        {
            return db.tbrollos.Count(e => e.idrollo == id) > 0;
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
