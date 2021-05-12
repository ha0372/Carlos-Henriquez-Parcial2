﻿using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appventas.DAO
{
    class ClsDProducto
    {
        public List<tb_producto> datoProduct()

        {
            List<tb_producto> Lista;

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                Lista = db.tb_producto.ToList();
            }

            return Lista;
        }

        public void saveProduct(tb_producto product)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {

                tb_producto IngresarP = new tb_producto();

                IngresarP.nombreProducto = product.nombreProducto;
                IngresarP.precioProducto = product.precioProducto;
                IngresarP.estadoProducto = product.estadoProducto;


                db.tb_producto.Add(product);
                db.SaveChanges();

            }


        }

        public void eliminarProduct(int Id)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                int eliminar = Convert.ToInt32(Id);
                tb_producto productDelete = db.tb_producto.Where(x => x.idProducto == eliminar).Select(x => x).FirstOrDefault();

                db.tb_producto.Remove(productDelete);
                db.SaveChanges();

            }

        }

        public void actualizarProduct(tb_producto product)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {

                int actualizar = Convert.ToInt32(product.idProducto);
                tb_producto tb_Producto = db.tb_producto.Where(x => x.idProducto == actualizar).Select(x => x).FirstOrDefault();


                tb_Producto.nombreProducto = product.nombreProducto;
                tb_Producto.precioProducto = product.precioProducto;
                tb_Producto.estadoProducto = product.estadoProducto;

                db.SaveChanges();
            }


        }
    }
}
