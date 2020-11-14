using System;
using System.Collections.Generic;
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
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public bool Activo { get; set; }
        public int Existencia { get; set; }
    
        public virtual List<FacturaDetalle> FacturaDetalle { get; set; }
    }
}
