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
using WebApplication1.Entites;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ZakazsController : ApiController
    {
        private Man_Sor_V_AEntities5 db = new Man_Sor_V_AEntities5();

        // GET: api/Zakazs
        [ResponseType(typeof(List<ZakazModel>))]
        public IHttpActionResult GetZakaz()
        {
            return Ok(db.Zakaz.ToList().ConvertAll(x=> new ZakazModel(x)));
        }

        // GET: api/Zakazs/5
        [ResponseType(typeof(Zakaz))]
        public IHttpActionResult GetZakaz(int id)
        {
            Zakaz zakaz = db.Zakaz.Find(id);
            if (zakaz == null)
            {
                return NotFound();
            }

            return Ok(zakaz);
        }

        // PUT: api/Zakazs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZakaz(int id, Zakaz zakaz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zakaz.Id_zakaz)
            {
                return BadRequest();
            }

            db.Entry(zakaz).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZakazExists(id))
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

        // POST: api/Zakazs
        [ResponseType(typeof(Zakaz))]
        public IHttpActionResult PostZakaz(Zakaz zakaz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zakaz.Add(zakaz);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ZakazExists(zakaz.Id_zakaz))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = zakaz.Id_zakaz }, zakaz);
        }

        // DELETE: api/Zakazs/5
        [ResponseType(typeof(Zakaz))]
        public IHttpActionResult DeleteZakaz(int id)
        {
            Zakaz zakaz = db.Zakaz.Find(id);
            if (zakaz == null)
            {
                return NotFound();
            }

            db.Zakaz.Remove(zakaz);
            db.SaveChanges();

            return Ok(zakaz);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZakazExists(int id)
        {
            return db.Zakaz.Count(e => e.Id_zakaz == id) > 0;
        }
    }
}