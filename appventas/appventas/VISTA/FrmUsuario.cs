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
    public partial class FrmUsuario : Form
    {
        public String identificador = null; /* Para no mostrar id*/

        public FrmUsuario()
        {
            InitializeComponent();
            Mostrar();
            clear();
        }

        void clear()
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }
        void Mostrar()
        {
            dataGridView1.Rows.Clear();
            ClsDUsuario clsDUsuario = new ClsDUsuario();
            List<tb_usuario> Lista = clsDUsuario.datosUser();

            foreach (var iteracion in Lista)
            {
                dataGridView1.Rows.Add(iteracion.iDUsuario, iteracion.email, iteracion.contrasena);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ClsDUsuario clsDUsuario = new ClsDUsuario();
            tb_usuario userTable = new tb_usuario();
            userTable.email = txtEmail.Text;
            userTable.contrasena = txtPassword.Text;

            clsDUsuario.saveUsuario(userTable);

            Mostrar();
            clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsDUsuario clsDUsuario = new ClsDUsuario();
            clsDUsuario.eliminarUser(Convert.ToInt32(identificador));

            Mostrar();
            clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsDUsuario clsDUsuario = new ClsDUsuario();
            tb_usuario userTable = new tb_usuario();

            userTable.iDUsuario = Convert.ToInt32(identificador);
            userTable.email = txtEmail.Text;
            userTable.contrasena = txtPassword.Text;

            clsDUsuario.actualizarUser(userTable);

            Mostrar();
            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String Id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String Email = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String Contrasena = dataGridView1.CurrentRow.Cells[2].Value.ToString();          

            identificador = Id;
            txtEmail.Text = Email;
            txtPassword.Text = Contrasena;
        }
    }
}
