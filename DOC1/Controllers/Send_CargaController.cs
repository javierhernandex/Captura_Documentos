using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOC1;

namespace DOC1.Controllers
{
    public class Send_CargaController : Controller
    {
        private hermes db = new hermes();

        // GET: Send_Carga
        public ActionResult Index()
        {



            return View();
        }

        // GET: Send_Carga/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Send_Carga send_Carga = db.Send_Carga.Find(id);
            if (send_Carga == null)
            {
                return HttpNotFound();
            }
            return View(send_Carga);
        }

        // GET: Send_Carga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Send_Carga/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VE_ID,VE_TANQ,VE_PROD,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_HFI,VE_VEHI,VE_TREG,VE_FOLR,VE_NPIP,VE_NDOC,VE_ENVIO,VE_IDC,VE_PRDO,VE_MONTO,VE_RFC,VE_NUMCSGN,VE_PC,VE_PAD,VE_PERTRA,VE_NOMPROV,VE_PERPROV,VE_TP,VE_PI,VE_CLVPRO,VE_CLVSUBPRO,VE_COCGAS,VE_GASETN,VE_CETNGAS,VE_OTROS,VE_MARCA")] Send_Carga send_Carga)
        {
            if (ModelState.IsValid)
            {
                db.Send_Carga.Add(send_Carga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(send_Carga);
        }

        // GET: Send_Carga/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Send_Carga send_Carga = db.Send_Carga.Find(id);
            if (send_Carga == null)
            {
                return HttpNotFound();
            }
            return View(send_Carga);
        }

        // POST: Send_Carga/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VE_ID,VE_TANQ,VE_PROD,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_HFI,VE_VEHI,VE_TREG,VE_FOLR,VE_NPIP,VE_NDOC,VE_ENVIO,VE_IDC,VE_PRDO,VE_MONTO,VE_RFC,VE_NUMCSGN,VE_PC,VE_PAD,VE_PERTRA,VE_NOMPROV,VE_PERPROV,VE_TP,VE_PI,VE_CLVPRO,VE_CLVSUBPRO,VE_COCGAS,VE_GASETN,VE_CETNGAS,VE_OTROS,VE_MARCA")] Send_Carga send_Carga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(send_Carga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(send_Carga);
        }

        // GET: Send_Carga/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Send_Carga send_Carga = db.Send_Carga.Find(id);
            if (send_Carga == null)
            {
                return HttpNotFound();
            }
            return View(send_Carga);
        }

        // POST: Send_Carga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Send_Carga send_Carga = db.Send_Carga.Find(id);
            db.Send_Carga.Remove(send_Carga);
            db.SaveChanges();
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
