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
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
            Mostrar();
            clear();
        }
        public String identificador = null; /* Para no mostrar en el formulario */

        void clear()
        {
            txtProducto.Clear();
            txtPrecio.Clear();
            txtEstado.Clear();
        }
        void Mostrar()
        {
            dataGridView1.Rows.Clear();
            ClsDProducto clsproducto = new ClsDProducto();
            List<tb_producto> Lista = clsproducto.datoProduct();

            foreach (var iteracion in Lista)
            {

                dataGridView1.Rows.Add(iteracion.idProducto, iteracion.nombreProducto, iteracion.precioProducto, iteracion.estadoProducto);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ClsDProducto clsproducto = new ClsDProducto();
            tb_producto productTable = new tb_producto();
            productTable.nombreProducto = txtProducto.Text;
            productTable.precioProducto = txtPrecio.Text;
            productTable.estadoProducto = txtEstado.Text;

            clsproducto.saveProduct(productTable);

            Mostrar();
            clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsDProducto clsproducto = new ClsDProducto();
            clsproducto.eliminarProduct(Convert.ToInt32(identificador));

            Mostrar();
            clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsDProducto clsproducto = new ClsDProducto();
            tb_producto productTable = new tb_producto();

            productTable.idProducto = Convert.ToInt32(identificador);
            productTable.nombreProducto = txtProducto.Text;
            productTable.precioProducto = txtPrecio.Text;
            productTable.estadoProducto = txtEstado.Text;

            clsproducto.actualizarProduct(productTable);

            Mostrar();
            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String Id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String Precio = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String Estado = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            identificador = Id;
            txtProducto.Text = Nombre;
            txtPrecio.Text = Precio;
            txtEstado.Text = Estado;
        }
    }
}
