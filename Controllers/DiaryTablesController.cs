using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiaryWebHW.Models;

namespace DiaryWebHW.Controllers
{
    public class DiaryTablesController : Controller
    {
        private DiarySurveyEntities db = new DiarySurveyEntities();

        // GET: DiaryTables
        public ActionResult Index()
        {
            return View(db.DiaryTables.ToList());
        }

        // GET: DiaryTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryTable diaryTable = db.DiaryTables.Find(id);
            if (diaryTable == null)
            {
                return HttpNotFound();
            }
            return View(diaryTable);
        }

        // GET: DiaryTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiaryTables/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,Title,Content,Time")] DiaryTable diaryTable)
        {
            if (ModelState.IsValid)
            {
                db.DiaryTables.Add(diaryTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diaryTable);
        }

        // GET: DiaryTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryTable diaryTable = db.DiaryTables.Find(id);
            if (diaryTable == null)
            {
                return HttpNotFound();
            }
            return View(diaryTable);
        }

        // POST: DiaryTables/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Title,Content,Time")] DiaryTable diaryTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diaryTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diaryTable);
        }

        // GET: DiaryTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryTable diaryTable = db.DiaryTables.Find(id);
            if (diaryTable == null)
            {
                return HttpNotFound();
            }
            return View(diaryTable);
        }

        // POST: DiaryTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiaryTable diaryTable = db.DiaryTables.Find(id);
            db.DiaryTables.Remove(diaryTable);
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
