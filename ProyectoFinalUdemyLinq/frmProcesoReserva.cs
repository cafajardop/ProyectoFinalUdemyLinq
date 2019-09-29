using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalUdemyLinq
{
    public partial class frmProcesoReserva : Form
    {
        public frmProcesoReserva()
        {
            InitializeComponent();
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado ofrmBuscarEmpleado = new frmBuscarEmpleado();
            ofrmBuscarEmpleado.ShowDialog();
            if (ofrmBuscarEmpleado.DialogResult.Equals(DialogResult.OK))
            {
                txtCodigoEmpleado.Text = ofrmBuscarEmpleado.id;
                txtNombreEmpleado.Text = ofrmBuscarEmpleado.nombreCompleto;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente ofrmBuscarCliente = new frmBuscarCliente();
            ofrmBuscarCliente.ShowDialog();
            if (ofrmBuscarCliente.DialogResult.Equals(DialogResult.OK))
            {
                txtDNICliente.Text = ofrmBuscarCliente.id;
                txtNombreCliente.Text = ofrmBuscarCliente.nombreCompleto;
            }
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void frmProcesoReserva_Load(object sender, EventArgs e)
        {
            cboCine.DataSource = bd.CINE.ToList();
            cboCine.DisplayMember = "NOMBRE";
            cboCine.ValueMember = "IDCINE";
        }
    }
}
