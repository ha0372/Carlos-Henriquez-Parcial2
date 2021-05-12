using appventas.DAO;
using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas.VISTA
{
    public partial class FrmDocumento : Form
    {
        public String identificador = null; /* Para no mostrar id*/

        public FrmDocumento()
        {
            InitializeComponent();
            Mostrar();
            clear();
        }
        void clear()
        {
            txtNameDocs.Clear();
        }
        void Mostrar()
        {
            dataGridView1.Rows.Clear();
            ClsDDocumento clsDocs = new ClsDDocumento();
            List<tb_documento> Lista = clsDocs.datosDocs();

            foreach (var iteracion in Lista)
            {
                dataGridView1.Rows.Add(iteracion.iDDocumento ,iteracion.nombreDocumento);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ClsDDocumento clsDocs = new ClsDDocumento();
            tb_documento docsTable = new tb_documento();
            docsTable.nombreDocumento = txtNameDocs.Text;
            
            clsDocs.saveDocs(docsTable);

            Mostrar();
            clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsDDocumento clsDocs = new ClsDDocumento();
            tb_documento docsTable = new tb_documento();

            docsTable.iDDocumento = Convert.ToInt32(identificador);
            docsTable.nombreDocumento = txtNameDocs.Text;

            clsDocs.actualizarDocs(docsTable);

            Mostrar();
            clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsDDocumento clsDocs = new ClsDDocumento();
            clsDocs.eliminarDocs(Convert.ToInt32(identificador));

            Mostrar();
            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String Id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String DocsName = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            identificador = Id;
            txtNameDocs.Text = DocsName;
        }
    }
}
