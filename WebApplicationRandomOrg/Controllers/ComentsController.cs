using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;

namespace WebApplicationRandomOrg.Controllers
{


    [Authorize(Users = "Admin")]
    public class ComentsController : Controller
    {
        private WebAppDbContext db = new WebAppDbContext();

     
        public async Task<ActionResult> Index()
        {
            return View(await db.Comentss.ToListAsync());
        }

       
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coments coments = await db.Comentss.FindAsync(id);
            if (coments == null)
            {
                return HttpNotFound();
            }
            return View(coments);
        }

   
        
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coments coments = await db.Comentss.FindAsync(id);
            if (coments == null)
            {
                return HttpNotFound();
            }
            return View(coments);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Coments coments = await db.Comentss.FindAsync(id);
            db.Comentss.Remove(coments);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
