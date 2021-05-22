using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplMVC_Crud.Models;
using WebApplMVC_Crud.Models.ViewModels;

namespace WebApplMVC_Crud.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListProductoVM> list;
            using (ProductosFerreterosDBEntities myDB = new ProductosFerreterosDBEntities())
            {
                list = (from a in myDB.Productos
                        select new ListProductoVM
                        {
                            Id = a.Id,
                            Nombre = a.Nombre,
                            Descripcion = a.Descripcion,
                            PrecioCompra = a.PrecioCompra ?? 0,
                            PrecioVenta = a.PrecioVenta ?? 0,
                            InventarioMinimo = a.InventarioMinimo ?? 0,
                            Activo = a.Activo ?? false
                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ProductoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ProductosFerreterosDBEntities myDB = new ProductosFerreterosDBEntities())
                    {
                        var prod = new Productos();
                        prod.Nombre = model.Nombre;
                        prod.Descripcion = model.Descripcion;
                        prod.PrecioCompra = model.PrecioCompra;
                        prod.PrecioVenta = model.PrecioVenta;
                        prod.InventarioMinimo = model.InventarioMinimo;
                        prod.Activo = true;

                        myDB.Productos.Add(prod);
                        myDB.SaveChanges();
                    }
                    return Redirect("/Producto");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            ProductoVM model = new ProductoVM();
            using (ProductosFerreterosDBEntities myDB = new ProductosFerreterosDBEntities())
            {
                model = (from a in myDB.Productos
                         where(a.Id == id)
                        select new ProductoVM
                        {
                            Id = a.Id,
                            Nombre = a.Nombre,
                            Descripcion = a.Descripcion,
                            PrecioCompra = a.PrecioCompra ?? 0,
                            PrecioVenta = a.PrecioVenta ?? 0,
                            InventarioMinimo = a.InventarioMinimo ?? 0,
                            Activo = a.Activo ?? false
                        }).FirstOrDefault();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ProductoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ProductosFerreterosDBEntities myDB = new ProductosFerreterosDBEntities())
                    {
                        var prod = myDB.Productos.FirstOrDefault(x => x.Id == model.Id);
                        prod.Nombre = model.Nombre;
                        prod.Descripcion = model.Descripcion;
                        prod.PrecioCompra = model.PrecioCompra;
                        prod.PrecioVenta = model.PrecioVenta;
                        prod.InventarioMinimo = model.InventarioMinimo;
                        //prod.Activo = true;

                        myDB.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                        myDB.SaveChanges();
                    }
                    return Redirect("/Producto");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Eliminar(int id)
        {
            ProductoVM model = new ProductoVM();
            using (ProductosFerreterosDBEntities myDB = new ProductosFerreterosDBEntities())
            {
                var pro = myDB.Productos.Find(id);

                myDB.Productos.Remove(pro);
                myDB.SaveChanges();
            }

            return Redirect("/Producto");
        }
    }
}