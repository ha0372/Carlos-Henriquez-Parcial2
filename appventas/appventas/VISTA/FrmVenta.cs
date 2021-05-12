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
            using (sistema_ventasEntities bd = new sistema_ventasEntities()) {

                var consultacliente = bd.tb_cliente.ToList();

                cbxClient.DataSource = consultacliente;
                cbxClient.DisplayMember = "nombreCliente";
                cbxClient.ValueMember = "iDCliente";

                var consultadocumento = bd.tb_documento.ToList();
                cbxTdocument.DataSource = consultadocumento;
                cbxTdocument.DisplayMember = "nombreDocumento";
                cbxTdocument.ValueMember = "iDDocumento";


            }
        }
    }
}
