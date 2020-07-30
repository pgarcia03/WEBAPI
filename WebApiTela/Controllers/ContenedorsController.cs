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
    public class ContenedorsController : ApiController
    {
        private DBTelaEntities db = new DBTelaEntities();

        // GET: api/Contenedors
        public IHttpActionResult Gettbcontenedor()
        {
            var list = db.tbcontenedor.Select(x=>new { x.contenedor,x.idcontenedor }).OrderByDescending(x=>x.idcontenedor).Take(200).ToList();
            return Ok(list);
        }

        // GET: api/Contenedors/5
        [ResponseType(typeof(tbcontenedor))]
        public IHttpActionResult Gettbcontenedor(int id)
        {
            var contenedor = db.tbcontenedor.Where(x=>x.idcontenedor== id).Select(x => new { x.idcontenedor, x.contenedor }).ToList();
            if (contenedor == null)
            {
                return NotFound();
            }

            return Ok(contenedor);
        }

        [ResponseType(typeof(tbcontenedor))]
        public IHttpActionResult Gettbcontenedor(string  nombre)
        {
            var lista = db.tbcontenedor.Where(x=>x.contenedor.Contains(nombre)).Take(15).Select(x=>new { x.idcontenedor,x.contenedor}).ToList();

            if (lista == null)
            {
                return NotFound();
            }

            return Ok(lista);
        }

        // PUT: api/Contenedors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbcontenedor(int id, tbcontenedor tbcontenedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbcontenedor.idcontenedor)
            {
                return BadRequest();
            }

            db.Entry(tbcontenedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbcontenedorExists(id))
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

        // POST: api/Contenedors
        [ResponseType(typeof(tbcontenedor))]
        public IHttpActionResult Posttbcontenedor(tbcontenedor tbcontenedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbcontenedor.Add(tbcontenedor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbcontenedor.idcontenedor }, tbcontenedor);
        }

        // DELETE: api/Contenedors/5
        [ResponseType(typeof(tbcontenedor))]
        public IHttpActionResult Deletetbcontenedor(int id)
        {
            tbcontenedor tbcontenedor = db.tbcontenedor.Find(id);
            if (tbcontenedor == null)
            {
                return NotFound();
            }

            db.tbcontenedor.Remove(tbcontenedor);
            db.SaveChanges();

            return Ok(tbcontenedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbcontenedorExists(int id)
        {
            return db.tbcontenedor.Count(e => e.idcontenedor == id) > 0;
        }
    }
}