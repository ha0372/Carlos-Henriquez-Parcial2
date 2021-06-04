using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appventas.DAO
{
    class ClsDVenta
    {
        public List<tb_venta> UltimaVenta()
        {
            List<tb_venta> consultarventa = new List<tb_venta>();

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                consultarventa = db.tb_venta.ToList();
            }
            return consultarventa;
        }

        public void save(tb_venta ventas)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_venta venta = new tb_venta();

                venta.iDDocumento = ventas.iDDocumento;
                venta.iDCliente = ventas.iDCliente;
                venta.iDUsuario = ventas.iDUsuario;
                venta.totalVenta = ventas.totalVenta;
                venta.fecha = ventas.fecha;

                db.tb_venta.Add(venta);

                db.SaveChanges();
            }
        }

    }


}
