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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
            Mostrar();
            clear();
        }

        public String identificador = null; /* Para no mostrar en el formulario */

        void clear()
        {
            txtNCliente.Clear();
            txtDireccion.Clear();
            txtDuiCliente.Clear();
        }
        void Mostrar()
        {
            dataGridView1.Rows.Clear();
            ClsDCliente clsDCliente = new ClsDCliente();
            List<tb_cliente> Lista = clsDCliente.datosClientes();

            foreach (var iteracion in Lista)
            {

                dataGridView1.Rows.Add(iteracion.iDCliente, iteracion.nombreCliente, iteracion.direccionCliente, iteracion.duiCliente);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ClsDCliente clsDCliente = new ClsDCliente();
            tb_cliente clienteTable = new tb_cliente();
            clienteTable.nombreCliente = txtNCliente.Text;
            clienteTable.direccionCliente = txtDireccion.Text;
            clienteTable.duiCliente = txtDuiCliente.Text;

            clsDCliente.SaveDatosCliente(clienteTable);

            Mostrar();
            clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsDCliente clsDCliente = new ClsDCliente();
            tb_cliente clienteTable = new tb_cliente();

            clienteTable.iDCliente = Convert.ToInt32(identificador);
            clienteTable.nombreCliente = txtNCliente.Text;
            clienteTable.direccionCliente = txtDireccion.Text;
            clienteTable.duiCliente = txtDuiCliente.Text;

            clsDCliente.actualizarCliente(clienteTable);

            Mostrar();
            clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsDCliente clsDCliente = new ClsDCliente();
            clsDCliente.eliminarCliente(Convert.ToInt32(identificador));

            Mostrar();
            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            String Id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String Direccion = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String Dui = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            identificador = Id;
            txtNCliente.Text = Nombre;
            txtDireccion.Text = Direccion;
            txtDuiCliente.Text = Dui;

        }
    }
}
