using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Models
{

    [Table("FacturaDetalle")]
    public partial class FacturaDetalle
    {
        public int id { get; set; }
        public int FacturaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Monto { get; set; }
        public decimal Impuesto { get; set; }
        
        public virtual Articulo Articulo { get; set; }
        public virtual Factura Factura { get; set; }
    }


    #region ViewModels
    public partial class FacturaDetalleViewModel
    {
        public int ArticuloId { get; set; }
        public string ArticuloNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Impuesto { get; set; }
        public bool Retirar { get; set; }
        public decimal Monto()
        {
            return Cantidad * PrecioUnitario;
        }
        public decimal ImpuestoPorDetalle()
        {
            return Cantidad * PrecioUnitario * Impuesto/100;
        }
        public decimal TotalPorDetalle()
        {
            return (Cantidad * PrecioUnitario * (1 + Impuesto / 100));
        }
    }
    #endregion
}
