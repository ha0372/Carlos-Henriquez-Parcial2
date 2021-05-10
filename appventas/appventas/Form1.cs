using appventas.DAO;
using appventas.VISTA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ClsAcceso acce = new ClsAcceso();

            int valor = acce.acceso(txtUser.Text, txtPass.Text);

            if (valor == 1)
            {
                MessageBox.Show("Welcome");
                FrmVenta venta = new FrmVenta();
                venta.Show();

            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
