using appventas.DAO;
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
    public partial class FrmFiltroProducto : Form
    {
        public FrmFiltroProducto()
        {
            InitializeComponent();
            cargardatos();
        }
        void cargardatos()
        {
            var clsDProducto = new ClsDProducto();  /*inerencia de dato var*/
            dtgProductos.Rows.Clear();

            foreach (var listarDatos in clsDProducto.cargarProductosFiltro(txtFiltroProducto.Text))
            {
                dtgProductos.Rows.Add(listarDatos.idProducto, listarDatos.nombreProducto, listarDatos.precioProducto);
            }
        }

        private void txtFiltroProducto_TextChanged(object sender, EventArgs e)
        {
            cargardatos();
        }

        void envio()
        {
            String Id = dtgProductos.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dtgProductos.CurrentRow.Cells[1].Value.ToString();
            String Precio = dtgProductos.CurrentRow.Cells[2].Value.ToString();

            //FrmVenta ventas = new FrmVenta();
            //ventas.txtIdProducto.Text = Id;
            //ventas.txtNombre.Text = Nombre;
            //ventas.txtPrecio.Text = Precio;
            //ventas.Show();

            FrmMenu.venta.txtIdProducto.Text = Id;
            FrmMenu.venta.txtNombre.Text = Nombre;
            FrmMenu.venta.txtPrecio.Text = Precio;
            FrmMenu.venta.txtCantidad.Focus();
            this.Close();
        }
        private void dtgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            envio();
            
        }

        private void dtgProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                envio();
            }
        }
    }
}
