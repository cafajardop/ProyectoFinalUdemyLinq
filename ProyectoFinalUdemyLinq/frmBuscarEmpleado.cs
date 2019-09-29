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
    public partial class frmBuscarEmpleado : Form
    {
        public string id { get; set; }
        public string nombreCompleto { get; set; }

        public frmBuscarEmpleado()
        {
            InitializeComponent();
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void frmBuscarEmpleado_Load(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = bd.EMPLEADO.Where(p => p.BHABILITADO.Equals(true))
                .Select(
                x => new
                {
                    x.IDEMPLEADO,
                    x.NOMBREEMPLEADO,
                    x.APPATERNO,
                    x.APMATERNO,
                    x.FECHAINICIO
                }
                ).ToList();
        }

        private void filter(object sender, EventArgs e)
        {
            string apellido = txtApellido.Text;
            dgvEmpleado.DataSource = bd.EMPLEADO.Where(p => p.BHABILITADO.Equals(true)
            && (p.APPATERNO.Contains(apellido)))
                .Select(
                x => new
                {
                    x.IDEMPLEADO,
                    x.NOMBREEMPLEADO,
                    x.APPATERNO,
                    x.APMATERNO,
                    x.FECHAINICIO
                }
                ).ToList();
        }

        private void ObtenerDatos(object sender, EventArgs e)
        {
            //Obtener el id
            id = dgvEmpleado.CurrentRow.Cells[0].Value.ToString();
            nombreCompleto = dgvEmpleado.CurrentRow.Cells[1].Value.ToString() +
                " " + dgvEmpleado.CurrentRow.Cells[2].Value.ToString() +
                " " + dgvEmpleado.CurrentRow.Cells[3 ].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
