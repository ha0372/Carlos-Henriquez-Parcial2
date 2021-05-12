using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appventas.DAO
{
    class ClsDDocumento
    {
        public List<tb_documento> datosDocs()

        {
            List<tb_documento> Lista;

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                Lista = db.tb_documento.ToList();
            }

            return Lista;
        }

        public void saveDocs(tb_documento document)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_documento dDocument = new tb_documento();
                dDocument.nombreDocumento = document.nombreDocumento;

                db.tb_documento.Add(dDocument);
                db.SaveChanges();
            }
        }

        public void eliminarDocs(int Id)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                int eliminar = Convert.ToInt32(Id);
                tb_documento deletDocument = db.tb_documento.Where(x => x.iDDocumento == eliminar).Select(x => x).FirstOrDefault();

                db.tb_documento.Remove(deletDocument);
                db.SaveChanges();
            }
        }

        public void actualizarDocs(tb_documento docs)
        {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {

                int actualizar = Convert.ToInt32(docs.iDDocumento);
                tb_documento datUser = db.tb_documento.Where(x => x.iDDocumento == actualizar).Select(x => x).FirstOrDefault();

                datUser.nombreDocumento = docs.nombreDocumento;

                db.SaveChanges();
            }


        }
    }
}
