﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TravelWeb.Models;
using Microsoft.AspNet.Identity;
using TravelWeb.ViewModel;

namespace TravelWeb.Controllers
{
    public class ToursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tours
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            if(user==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var ct = db.ChiTietTours.FirstOrDefault(n => n.MaKH == user);
            var tour = db.Tours.Where(n => n.MaTour == ct.MaTour&&n.ThoiGianDi>=DateTime.Now).ToList();
            return View(tour);
        }

        // GET: Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        [HttpPost]
        public ActionResult AddTour(Tour tour)
        {
            Session["tour"] = tour;
            return RedirectToAction("Create", "Tours");
        }
        // GET: Tours/Create
        public ActionResult Create()
        {
            var tour = Session["tour"] as Tour;
            ViewBag.Tinh = tour.TinhToi;
            ViewBag.Huyen = tour.HuyenToi;
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tour tour)
        {
            if (ModelState.IsValid)
            {
                var tour1 = Session["tour"] as Tour;
                //Tìm tour
                var Tour = db.Tours.ToList();
                int i = 0;
                foreach (var item in Tour)
                {
                    i = 0;
                    if (item.PhuongTien == tour.PhuongTien &&
                        item.TinhToi == tour1.TinhToi &&
                        item.TinhDi == tour.TinhDi &&
                        item.HuyenToi == tour1.HuyenToi &&
                        item.SoNguoi == tour.SoNguoi &&
                        (item.SoNguoi - item.SoNguoiDaCo) >= tour.SoNguoiDaCo
                        )
                    {
                        i++;    
                    }
                    if(i==1)
                    {
                        //add chi tiết
                        var user = User.Identity.GetUserId();
                        if(user==null)
                        {
                            return RedirectToAction("Login", "Account");
                        }
                        int ma = item.MaTour;
                        ChiTietTour ct = new ChiTietTour();
                        ct.MaTour = ma;
                        ct.MaKH = user;
                        db.ChiTietTours.Add(ct);
                        db.SaveChanges();

                        var tour2 = db.Tours.SingleOrDefault(n => n.MaTour == ma);
                        if(tour2==null)
                        {
                            Response.StatusCode = 404;
                            return null;
                        }
                        tour2.SoNguoiDaCo += tour.SoNguoiDaCo;
                        db.SaveChanges();
                        return Redirect("Index");
                    }
                    
                }
                if (i == 0)
                {
                    //Add database
                    var tours = Session["tour"] as Tour;
                    tour.TinhToi = tours.TinhToi;
                    tour.HuyenToi = tours.HuyenToi;
                    db.Tours.Add(tour);
                    db.SaveChanges();
                    
                    //add chi tiết
                    var user = User.Identity.GetUserId();
                    int ma = tour.MaTour;
                    ChiTietTour ct = new ChiTietTour();
                    ct.MaTour = ma;
                    ct.MaKH = user;
                    db.ChiTietTours.Add(ct);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            return View(tour);
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTour,ThoiGianDi,NgayDiDuKien,TinhDi,HuyenDi,TinhToi,HuyenToi,DiaDiemToi,SoNguoi,SoNguoiDaCo,PhuongTien,GioiTinh")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
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
        public JsonResult LoadProvince()
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/assets/client/data/Provinces_Data.xml"));

            var xElements = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "province");
            var list = new List<Tinh>();
            Tinh province = null;
            foreach (var item in xElements)
            {
                province = new Tinh();
                province.ID = int.Parse(item.Attribute("id").Value);
                province.Name = item.Attribute("value").Value;
                list.Add(province);

            }
            return Json(new
            {
                data = list,
                status = true
            });
        }
        public JsonResult LoadDistrict(int provinceID)
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/assets/client/data/Provinces_Data.xml"));

            var xElement = xmlDoc.Element("Root").Elements("Item")
                .Single(x => x.Attribute("type").Value == "province" && int.Parse(x.Attribute("id").Value) == provinceID);

            var list = new List<Huyen>();
            Huyen district = null;
            foreach (var item in xElement.Elements("Item").Where(x => x.Attribute("type").Value == "district"))
            {
                district = new Huyen();
                district.ID = int.Parse(item.Attribute("id").Value);
                district.Name = item.Attribute("value").Value;
                district.ProvinceID = int.Parse(xElement.Attribute("id").Value);
                list.Add(district);

            }
            return Json(new
            {
                data = list,
                status = true
            });
        }

        public ActionResult ChiTiet(int id=0)
        {
            var model = (from a in db.ChiTietTours
                         join b in db.Users
                         on a.MaKH equals b.Id
                         where a.MaTour == id
                         select new ChiTietViewModel
                         {
                             TenKh = b.HoTen,
                             ngaysinh = b.NgaySinh,
                             gioitinh=b.GioiTinh,
                             linkfb=b.FaceBook,
                             Mota=a.MoTa,
                             TinhTrang=a.TinhTrang
                         }
                         );
            return View(model.ToList());

        }
    }
}
