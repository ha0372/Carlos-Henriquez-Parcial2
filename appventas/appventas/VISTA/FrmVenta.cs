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
    public partial class FrmVenta : Form
    {
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            //using (sistema_ventasEntities bd = new sistema_ventasEntities()) {
            //    var consultacliente = bd.tb_cliente.ToList();

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
    }
}

