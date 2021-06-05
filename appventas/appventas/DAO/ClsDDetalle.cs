using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appventas.DAO
{
    class ClsDDetalle
    {

        public void guardardetalleventa(tb_detalleVenta detalle)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_detalleVenta tb_Detalle = new tb_detalleVenta();
                tb_Detalle.iDVenta = detalle.iDVenta;
                tb_Detalle.iDProducto = detalle.iDProducto;
                tb_Detalle.cantidad = detalle.cantidad;
                tb_Detalle.precio = detalle.precio;
                tb_Detalle.total = detalle.total;

                db.tb_detalleVenta.Add(tb_Detalle);


            }
        }
    }
}
