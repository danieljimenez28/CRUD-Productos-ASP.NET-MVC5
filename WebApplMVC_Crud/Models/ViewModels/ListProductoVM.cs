using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplMVC_Crud.Models.ViewModels
{
    public class ListProductoVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int InventarioMinimo { get; set; }
        public bool Activo { get; set; }
    }
}