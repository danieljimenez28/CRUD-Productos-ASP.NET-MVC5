using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplMVC_Crud.Models;
using WebApplMVC_Crud.Models.ViewModels;

namespace WebApplMVC_Crud.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ListClienteVM> clientList;
            using (ProductosFerreterosDBEntities _db = new ProductosFerreterosDBEntities())
            {
                clientList = (from x in _db.Clientes
                              where (x.Activo == true)
                              select new ListClienteVM
                              {
                                  ClienteID = x.ClienteID,
                                  Nombre = x.Nombre,
                                  Direccion = x.Direccion,
                                  Telefono = x.Telefono
                              }).ToList();
            }

            return View(clientList);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ClienteVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ProductosFerreterosDBEntities myDB = new ProductosFerreterosDBEntities())
                    {
                        var client = new Clientes();
                        client.Nombre = model.Nombre;
                        client.Direccion = model.Direccion;
                        client.Telefono = model.Telefono;
                        client.Activo = true;

                        myDB.Clientes.Add(client);
                        myDB.SaveChanges();
                    }
                    return Redirect("/Cliente");
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
            return View();
        }
    }
}