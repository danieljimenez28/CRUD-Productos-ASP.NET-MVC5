//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplMVC_Crud.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FacturasDetalle
    {
        public int DetalleID { get; set; }
        public Nullable<int> FacturaID { get; set; }
        public Nullable<int> ProductoID { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> Total { get; set; }
    
        public virtual Facturas Facturas { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
