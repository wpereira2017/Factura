using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Pos.Models
{
    [Table("Factura")]
    public partial class Factura
    {
        public Factura()
        {
            FacturaDetalle = new List<FacturaDetalle>();
        }
    
        public int id { get; set; }
        public string Cliente { get; set; }
        public decimal Total { get; set; }
        public DateTime Creado { get; set; }
    
        public virtual List<FacturaDetalle> FacturaDetalle { get; set; }
    }

    #region ViewModels
    public class FacturaViewModel
    {

        #region Definición del ViewModel Factura
        //Cabecera
        public string Cliente { get; set; }
        public int CabeceraArticuloId { get; set; }
        public string CabeceraArticuloNombre { get; set; }
        public int CabeceraArticuloCantidad { get; set; }
        public decimal CabeceraArticuloPrecio { get; set; }
        public decimal CabeceraImpuesto { get; set; }

        //Cuerpo o detalle de la factura
        public List<FacturaDetalleViewModel> FacturaDetalle { get; set; }

        //Pie o totales de la factura
        public decimal SubTotal()
        {
            return FacturaDetalle.Sum(x => x.Monto());
        }

        public decimal MontoImpuesto()
        {
            return FacturaDetalle.Sum(x => x.Monto()) * (CabeceraImpuesto / 100);
        }

        public decimal Total()
        {
            return FacturaDetalle.Sum(x => x.Monto()) * (1 + CabeceraImpuesto / 100);
        }

        public DateTime Creado { get; set; }
        #endregion

        #region Validaciones en el registro de nueva factura
        public bool EsArticuloValido()
        {
            return !(CabeceraArticuloId == 0 || string.IsNullOrEmpty(CabeceraArticuloNombre) || CabeceraArticuloCantidad == 0 || CabeceraArticuloPrecio == 0);
        }

        public bool ExisteEnDetalle(int ArticuloId)
        {
            //revisar que el codigo debe ser string
            return FacturaDetalle.Any(x => x.ArticuloId == ArticuloId);
        }
        #endregion

        public FacturaViewModel()
        {
            FacturaDetalle = new List<FacturaDetalleViewModel>();
        }

        public void RemoverDeDetalle()
        {
            if (FacturaDetalle.Count > 0)
            {
                var detalleARetirar = FacturaDetalle.Where(x => x.Retirar).SingleOrDefault();

                FacturaDetalle.Remove(detalleARetirar);
            }
        }

        public void AgregarADetalle()
        {
            FacturaDetalle.Add(new FacturaDetalleViewModel
            {
                ArticuloId = CabeceraArticuloId,
                ArticuloNombre = CabeceraArticuloNombre,
                PrecioUnitario = CabeceraArticuloPrecio,
                Cantidad = CabeceraArticuloCantidad,
            });

        }

        public Factura ToModel()
        {
            var comprobante = new Factura();
            comprobante.Cliente = this.Cliente;
            comprobante.Creado = DateTime.Now;
            comprobante.Total = this.Total();

            foreach (var d in FacturaDetalle)
            {
                comprobante.FacturaDetalle.Add(new FacturaDetalle
                {
                    ArticuloId = d.ArticuloId,
                    Monto = d.Monto(),
                    PrecioUnitario = d.PrecioUnitario,
                    Cantidad = d.Cantidad
                });
            }

            return comprobante;
        }
    }
    #endregion
}
