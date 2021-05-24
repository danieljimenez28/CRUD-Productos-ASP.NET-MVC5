using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplMVC_Crud.Models.ViewModels
{
    public class ListClienteVM
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}