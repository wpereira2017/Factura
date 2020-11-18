using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Models
{
    [Table("Articulo")]
    public partial class Articulo
    {
        public Articulo()
        {
            FacturaDetalle = new List<FacturaDetalle>();
        }
    
        public int id { get; set; }

        [Required]
        [Display(Name = "C�digo de Art�culo")]
        public string Codigo { get; set; }

        [Required]
        [Display(Name = "Descripci�n")]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [Required]
        [Range(0.0, (double)decimal.MaxValue, ErrorMessage = "Valor debe estar entre {1} y {2}.")]
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Precio de venta inv�lido, 3 decimales permitidos")]
        public decimal Precio { get; set; }

        [Required]
        [Range(0.0, (double)decimal.MaxValue, ErrorMessage = "Valor debe estar entre {1} y {2}.")]
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Costo de art�culo inv�lido, 3 decimales permitidos")]
        public decimal Costo { get; set; }

        [Required]
        public bool Activo { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Las existencias deben ser mayores o iguales a 0")]
        [Required]
        public int Existencia { get; set; }
    
        public virtual List<FacturaDetalle> FacturaDetalle { get; set; }
    }
}
