using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Pos.Models;

namespace FacturaWebLG.Controllers
{
    public class ArticuloController : Controller
    {
        //PosEntities es mi Contexto

        public ActionResult Index()
        {
            try
            {
                using (var db = new VentasEntities())
                {
                    List<Articulo> lista = db.Articulo.Where(a => a.Activo == true).ToList();
                    return View(lista);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Articulo item)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using(var db = new VentasEntities())
                {
                    db.Articulo.Add(item);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Error al crear nuevo artículo: " + ex.Message);
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            try
            {
                using (var db = new VentasEntities())
                {
                    Articulo item = db.Articulo.Find(id);
                    return View(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new VentasEntities())
                {
                    Articulo item = db.Articulo.Find(id);
                    return View(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Articulo item)
        {
            try
            {
                using (var db = new VentasEntities())
                {
                    Articulo art = db.Articulo.Find(item.Codigo);
                    art.Descripcion = item.Descripcion;
                    art.Precio = item.Precio;
                    art.Costo = item.Costo;
                    art.Existencia = item.Existencia;

                    db.Entry(art).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new VentasEntities())
                {
                    Articulo item = db.Articulo.Find(id);
                    db.Articulo.Remove(item);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
