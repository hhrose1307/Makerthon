using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelWeb.Models;

namespace TravelWeb.Controllers
{
    public class NhaNghisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NhaNghis
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            return View(db.NhaNghis.Where(x=>x.MaKH==user).ToList());
        }

        // GET: NhaNghis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaNghis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenNhaNghi,DiaChi,SDT,GiaPhong,Anh1,Anh2,Anh3,Anh4,Anh5,MaKH")] NhaNghi nhaNghi)
        {
            if (ModelState.IsValid)
            {
                nhaNghi.MaKH = User.Identity.GetUserId();
                db.NhaNghis.Add(nhaNghi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaNghi);
        }

        // GET: NhaNghis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaNghi nhaNghi = db.NhaNghis.Find(id);
            if (nhaNghi == null)
            {
                return HttpNotFound();
            }
            return View(nhaNghi);
        }

        // POST: NhaNghis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenNhaNghi,DiaChi,SDT,GiaPhong,Anh1,Anh2,Anh3,Anh4,Anh5,MaKH")] NhaNghi nhaNghi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaNghi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaNghi);
        }

        // GET: NhaNghis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaNghi nhaNghi = db.NhaNghis.Find(id);
            if (nhaNghi == null)
            {
                return HttpNotFound();
            }
            return View(nhaNghi);
        }

        // POST: NhaNghis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhaNghi nhaNghi = db.NhaNghis.Find(id);
            db.NhaNghis.Remove(nhaNghi);
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
