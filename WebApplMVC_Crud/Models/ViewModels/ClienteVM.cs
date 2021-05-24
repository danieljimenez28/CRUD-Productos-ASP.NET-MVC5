using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplMVC_Crud.Models.ViewModels
{
    public class ClienteVM
    {
        [Key]
        public int ClienteID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(999)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        public bool Activo { get; set; }
    }
}