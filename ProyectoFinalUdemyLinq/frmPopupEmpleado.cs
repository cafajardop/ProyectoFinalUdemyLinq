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
    public partial class frmPopupEmpleado : Form
    {

        public string accion { get; set; }
        public string id { get; set; }
        public frmPopupEmpleado()
        {
            InitializeComponent();
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void FrmPopupEmpleado_Load(object sender, EventArgs e)
        {
            cmbTipoEmpleado.DataSource = bd.TIPOEMPLEADO.ToList();
            cmbTipoEmpleado.DisplayMember = "NOMBRE";
            cmbTipoEmpleado.ValueMember = "IDTIPOEMPLEADO";
            cmbTipoModalidad.DataSource = bd.TIPOMODALIDAD.ToList();
            cmbTipoModalidad.DisplayMember = "NOMBRE";
            cmbTipoModalidad.ValueMember = "IDTIPOMODALIDAD";

            if (accion.Equals("Nuevo"))
            {
                this.Text = "Ingrese Empleado";
            }
            else
            {
                this.Text = "Actualice Empleado";
                var consulta = bd.EMPLEADO.Where(p => p.IDEMPLEADO.Equals(id));
                foreach (EMPLEADO emp in consulta)
                {
                    txtNombre.Text = emp.NOMBREEMPLEADO;
                    txtPrimerApellido.Text = emp.APPATERNO;
                    txtSegundoApellido.Text = emp.APMATERNO;
                    txtSueldo.Text = emp.SUELDO.ToString();
                    txtFecha.Value = DateTime.Parse(emp.FECHAINICIO.ToString());
                    cmbTipoModalidad.SelectedValue = emp.IDTIPOMODALIDAD;
                    cmbTipoEmpleado.SelectedValue = emp.IDTIPOEMPLEADO;
                    txtUsuario.Text = emp.USUARIO;
                }
            }
        }
    }
}
