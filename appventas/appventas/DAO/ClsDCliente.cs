using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appventas.DAO
{
    class ClsDCliente
    {
        public List<tb_cliente> datosClientes()

        {
            List<tb_cliente> Lista;

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                Lista = db.tb_cliente.ToList();
            }

            return Lista;
        }

        public void SaveDatosCliente(tb_cliente client)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {

                tb_cliente cliente = new tb_cliente();

                cliente.nombreCliente = client.nombreCliente;
                cliente.direccionCliente = client.direccionCliente;
                cliente.duiCliente = client.duiCliente;


                db.tb_cliente.Add(cliente);
                db.SaveChanges();

            }


        }

        public void eliminarCliente(int Id)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                int eliminar = Convert.ToInt32(Id);
                tb_cliente clienteDelete = db.tb_cliente.Where(x => x.iDCliente == eliminar).Select(x => x).FirstOrDefault();

                db.tb_cliente.Remove(clienteDelete);
                db.SaveChanges();

            }

        }

        public void actualizarCliente(tb_cliente cliente)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {

                int actualizar = Convert.ToInt32(cliente.iDCliente);
                tb_cliente tb_Cliente = db.tb_cliente.Where(x => x.iDCliente == actualizar).Select(x => x).FirstOrDefault();


                tb_Cliente.nombreCliente = cliente.nombreCliente;
                tb_Cliente.direccionCliente = cliente.direccionCliente;
                tb_Cliente.duiCliente = cliente.duiCliente;

                db.SaveChanges();
            }


        }
    }
}
