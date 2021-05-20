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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        public static FrmVenta venta = new FrmVenta();

        private void vENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVenta venta = new FrmVenta();
            venta.MdiParent = this;
            venta.Show();
            
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente cliente = new FrmCliente();
            cliente.MdiParent = this;
            cliente.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario usuario = new FrmUsuario();
            usuario.MdiParent = this;
            usuario.Show();
        }

        private void documentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDocumento documento = new FrmDocumento();
            documento.MdiParent = this;
            documento.Show();

        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto producto = new FrmProducto();
            producto.MdiParent = this;
            producto.Show();
        }
    }
}
