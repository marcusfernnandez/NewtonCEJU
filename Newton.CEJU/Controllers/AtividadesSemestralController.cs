﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newton.CJU.DAL;
using Newton.CJU.Models;

namespace Newton.CJU.Controllers
{
    public class AtividadesSemestralController : Controller
    {
        private CJUContext db = new CJUContext();

        // GET: AtividadesSemestral
        public ActionResult Index()
        {
            var atividadesSemestrais = db.AtividadesSemestrais.Include(a => a.AreaConhecimento);
            return View(atividadesSemestrais.ToList());
        }

        // GET: AtividadesSemestral/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadeSemestral atividadeSemestral = db.AtividadesSemestrais.Find(id);
            if (atividadeSemestral == null)
            {
                return HttpNotFound();
            }
            return View(atividadeSemestral);
        }

        // GET: AtividadesSemestral/Create
        public ActionResult Create()
        {
            ViewBag.AreaConhecimentoId = new SelectList(db.AreasConhecimento, "Id", "Nome");
            return View();
        }

        // POST: AtividadesSemestral/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,AreaConhecimentoId,Ano,Semestre,Ativo")] AtividadeSemestral atividadeSemestral)
        {
            if (ModelState.IsValid)
            {
                db.AtividadesSemestrais.Add(atividadeSemestral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaConhecimentoId = new SelectList(db.AreasConhecimento, "Id", "Nome", atividadeSemestral.AreaConhecimentoId);
            return View(atividadeSemestral);
        }

        // GET: AtividadesSemestral/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadeSemestral atividadeSemestral = db.AtividadesSemestrais.Find(id);
            if (atividadeSemestral == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaConhecimentoId = new SelectList(db.AreasConhecimento, "Id", "Nome", atividadeSemestral.AreaConhecimentoId);
            return View(atividadeSemestral);
        }

        // POST: AtividadesSemestral/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,AreaConhecimentoId,Ano,Semestre,Ativo")] AtividadeSemestral atividadeSemestral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividadeSemestral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaConhecimentoId = new SelectList(db.AreasConhecimento, "Id", "Nome", atividadeSemestral.AreaConhecimentoId);
            return View(atividadeSemestral);
        }

        // GET: AtividadesSemestral/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadeSemestral atividadeSemestral = db.AtividadesSemestrais.Find(id);
            if (atividadeSemestral == null)
            {
                return HttpNotFound();
            }
            return View(atividadeSemestral);
        }

        // POST: AtividadesSemestral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AtividadeSemestral atividadeSemestral = db.AtividadesSemestrais.Find(id);
            db.AtividadesSemestrais.Remove(atividadeSemestral);
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