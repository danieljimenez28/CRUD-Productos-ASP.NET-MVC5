using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplMVC_Crud.Models.ViewModels
{
    public class ProductoVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Nombre Requerido")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(999)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripcion Requerido")]
        public string Descripcion { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "PrecioCompra Requerido")]
        public decimal PrecioCompra { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "PrecioVenta Requerido")]

        public decimal PrecioVenta { get; set; }
        [Required]
        [Display(Name = "InventarioMinimo Requerido")]
        public int InventarioMinimo { get; set; }
        public bool Activo { get; set; }
    }
}