﻿using appventas.DAO;
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
    public partial class FrmVenta : Form
    {
        public FrmVenta()
        {
            InitializeComponent();
        }

        void ultimocorrelativoventa()
        {

            var consultaultimaventa = new ClsDVenta();
            int lista = 0;

            foreach (var list in consultaultimaventa.UltimaVenta())
            {
                lista = list.iDVenta;
            }



            lista++;
            txtUltimaVenta.Text = lista.ToString();

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            //using (sistema_ventasEntities bd = new sistema_ventasEntities()) {
            //var consultacliente = bd.tb_cliente.ToList();

            ultimocorrelativoventa();

            ClsDCliente clsDCliente = new ClsDCliente();


            cbxClient.DataSource = clsDCliente.datosClientes();
            cbxClient.DisplayMember = "nombreCliente";
            cbxClient.ValueMember = "iDCliente";


            ClsDDocumento clsDDocumento = new ClsDDocumento();
            //var consultadocumento = bd.tb_documento.ToList();

            cbxTdocument.DataSource = clsDDocumento.datosDocs();
            cbxTdocument.DisplayMember = "nombreDocumento";
            cbxTdocument.ValueMember = "iDDocumento";


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmFiltroProducto buscar = new FrmFiltroProducto();
            buscar.ShowDialog();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double precio, cantidad, total;

                cantidad = Convert.ToDouble(txtCantidad.Text);
                precio = Convert.ToDouble(txtPrecio.Text);


                total = precio * cantidad;

                txtTotal.Text = total.ToString();
            }
            catch (Exception)
            {

                if (txtCantidad.Text.Equals(""))
                {
                    txtCantidad.Text = "0";
                    txtCantidad.SelectAll();
                }

            }
        }

        private void btnAgregarTotal_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtIdProducto.Text, txtNombre.Text, txtPrecio.Text, txtCantidad.Text, txtTotal.Text);

            Double suma = 0;  /*variable de acarreo*/

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                String datosaoperartotal = dataGridView1.Rows[i].Cells[4].Value.ToString();

                Double DatosConvertidos = Convert.ToDouble(datosaoperartotal);

                suma += DatosConvertidos;

                txtTotalFinal.Text = suma.ToString();

                txtIdProducto.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();
                txtCantidad.Text = "";
                txtTotal.Text = "";
            }
        }
    }
}
