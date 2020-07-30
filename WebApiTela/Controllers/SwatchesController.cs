using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
    public class SwatchesController : ApiController
    {
        private DBTelaEntities db = new DBTelaEntities();

        // GET: api/Swatches
        public IQueryable<tbswatch> Gettbswatch()
        {
            return db.tbswatch;
        }

        // GET: api/Swatches/5
        [ResponseType(typeof(tbswatch))]
        public IHttpActionResult Gettbswatch(int id)
        {
            var tbswatch = db.tbswatch.Where(x=>x.idswatches==id).Select(x=> new { x.idswatches,x.idrollo,x.x1,x.x2,x.x3,x.y1,x.y2,x.y3,x.p1,x.p2,x.fecha,x.usuario }).ToList();
            if (tbswatch == null)
            {
                return NotFound();
            }

            return Ok(tbswatch);
        }

        // PUT: api/Swatches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbswatch(int id, tbswatch tbswatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbswatch.idswatches)
            {
                return BadRequest();
            }

            db.Entry(tbswatch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbswatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Swatches
        [ResponseType(typeof(tbswatch))]
        public IHttpActionResult Posttbswatch(tbswatch tbswatch)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var num = db.tbswatch.Where(x => x.idrollo == tbswatch.idrollo).Count();

                    if (num == 0)
                    {
                        var objrollo = db.tbrollos.Find(tbswatch.idrollo);

                        objrollo.estado = "MEDIDO";
                        objrollo.proceso = "Process1";

                        tbswatch.fecha = DateTime.Now;

                        db.tbswatch.Add(tbswatch);
                        db.SaveChanges();

                        transaction.Commit();
                        return Ok("Exito");//CreatedAtRoute("DefaultApi", new { id = tbswatch.idswatches }, tbswatch);
                    }
                    else
                        return BadRequest("El rollor ya fue procesado");
                   
                }
                catch
                {
                    transaction.Rollback();

                    return BadRequest("Error");
                }
            }

           
        }

        [ResponseType(typeof(tbswatch))]
        public IHttpActionResult Savetbswatch(string listaswatch)
        {

            var lista = JsonConvert.DeserializeObject<List<tbswatch>>(listaswatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbswatch.AddRange(lista);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi","exito","creado correctamente");// new IHttpActionResult(Request,HttpStatusCode.Created,); // CreatedAtRoute("DefaultApi", new { id = tbswatch.idswatches }, tbswatch);
        }

        // DELETE: api/Swatches/5
        [ResponseType(typeof(tbswatch))]
        public IHttpActionResult Deletetbswatch(int id)
        {
            tbswatch tbswatch = db.tbswatch.Find(id);
            if (tbswatch == null)
            {
                return NotFound();
            }

            db.tbswatch.Remove(tbswatch);
            db.SaveChanges();

            return Ok(tbswatch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbswatchExists(int id)
        {
            return db.tbswatch.Count(e => e.idswatches == id) > 0;
        }
    }
}