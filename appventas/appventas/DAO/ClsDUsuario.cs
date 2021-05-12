using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appventas.DAO
{
    class ClsDUsuario
    {
        public List<tb_usuario> datosUser()

        {
            List<tb_usuario> Lista;

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                Lista = db.tb_usuario.ToList();
            }

            return Lista;
        }

        public void saveUsuario(tb_usuario usuario)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_usuario datosUsuario = new tb_usuario();

                datosUsuario.email = usuario.email;
                datosUsuario.contrasena = usuario.contrasena;

                db.tb_usuario.Add(datosUsuario);
                db.SaveChanges();
            }
        }

        public void eliminarUser(int Id)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                int eliminar = Convert.ToInt32(Id);
                tb_usuario userDelete = db.tb_usuario.Where(x => x.iDUsuario == eliminar).Select(x => x).FirstOrDefault();

                db.tb_usuario.Remove(userDelete);
                db.SaveChanges();
            }
        }

        public void actualizarUser(tb_usuario user)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {

                int actualizar = Convert.ToInt32(user.iDUsuario);
                tb_usuario datUser = db.tb_usuario.Where(x => x.iDUsuario == actualizar).Select(x => x).FirstOrDefault();


                datUser.email = user.email;
                datUser.contrasena = user.contrasena;

                db.SaveChanges();
            }


        }
    }
}
