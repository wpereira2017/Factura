using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Pos.Models;

namespace Pos.Controllers
{
    public class FacturaController : Controller
    {
        //Listado de Facturas
        public ActionResult Index()
        {
            try
            {
                using (var dbContext = new VentasEntities())
                {
                    List<Factura> lista = dbContext.Factura.ToList();
                    return View(lista);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Crear nueva factura
        public ActionResult Create()
        {
            return View(new FacturaViewModel());
        }

        [HttpPost]
        public ActionResult Create(FacturaViewModel model, string action)
        {
            if (action == "generar")
            {
                if (!string.IsNullOrEmpty(model.Cliente))
                {
                    if (RegistrarFactura(model.ToModel()))
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("cliente", "Debe agregar un cliente para la factura");
                }
            }
            else if (action == "agregar_articulo")
            {
                // Si no ha pasado validación, muestro el mensaje personalizado de error
                if (!model.EsArticuloValido())
                {
                    ModelState.AddModelError("articulo_agregar", "Solo puede agregar un artículo válido al detalle");
                }
                else if (model.ExisteEnDetalle(model.CabeceraArticuloId))
                {
                    ModelState.AddModelError("articulo_agregar", "El artículo elegido ya existe en el detalle");
                }
                else
                {
                    model.AgregarArticuloDetalle();
                }
            }
            else if (action == "retirar_articulo")
            {
                model.RemoverArticuloDetalle();
            }
            else
            {
                throw new Exception("Acción no definida ..");
            }

            return View(model);
        }

        public JsonResult BuscarArticulo(string codigo)
        {
            return Json(Buscar(codigo));
        }

        // 
        // Lógica de Negocio, por el momento queda acá
        //

        public bool RegistrarFactura(Factura factura)
        {
            try
            {
                using (var dbContext = new VentasEntities())
                {
                    dbContext.Entry(factura).State = EntityState.Added;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear factura: " + ex.Message);
                return false;
            }

            return true;
        }

        public Articulo Buscar(string codigo)
        {
            using (var dbContext = new VentasEntities())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                dbContext.Configuration.ProxyCreationEnabled = false;

                var articulo = dbContext.Articulo.Where(x => x.Codigo == codigo).FirstOrDefault();
                return articulo;
            }
        }
    }
}