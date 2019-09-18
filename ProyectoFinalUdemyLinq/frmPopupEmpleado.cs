using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(""))
            {
                errorData.SetError(txtNombre, "Debio Ingresar Nombre");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorData.SetError(txtNombre, "");
            }

            if (txtPrimerApellido.Text.Equals(""))
            {
                errorData.SetError(txtNombre, "Debio Ingresar Primer Apellido");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorData.SetError(txtPrimerApellido, "");
            }

            if (txtSegundoApellido.Text.Equals(""))
            {
                errorData.SetError(txtNombre, "Debio Ingresar Segundo Apellido");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorData.SetError(txtSegundoApellido, "");
            }

            string nombre = txtNombre.Text;
            string apellidoPaterno = txtPrimerApellido.Text;
            string apellidoMaterno = txtSegundoApellido.Text;
            string sueldo = txtSueldo.Text;
            DateTime fechaInicio = txtFecha.Value;
            int idTipoModalidad = int.Parse(cmbTipoModalidad.SelectedValue.ToString());
            int idTipoEmpleado = int.Parse(cmbTipoEmpleado.SelectedValue.ToString());
            string usuario = txtUsuario.Text;

            string clave = txtContraseña.Text;
            //Cifrar la contraseña
            SHA256Managed oSHA256Managed = new SHA256Managed();
            byte[] bufferCadena = Encoding.Default.GetBytes(clave);
            byte[] bufferCadenaCifrada = oSHA256Managed.ComputeHash(bufferCadena);
            //Esta variable se guarda en BD
            string dataCifrada = BitConverter.ToString(bufferCadenaCifrada).Replace("-", "");

            if (accion.Equals("Nuevo"))
            {
                var consulta = bd.EMPLEADO.Where(p => p.USUARIO.ToUpper().Equals(usuario.ToUpper()));
                int numeroVeces = consulta.Count();
                if (numeroVeces > 0)
                {
                    MessageBox.Show("Ya existe el usuario");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (txtContraseña.Text.Equals(""))
                {
                    errorData.SetError(txtContraseña, "Debe ingresar una contraseña");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else
                {
                    errorData.SetError(txtContraseña,"");
                }

                EMPLEADO emp = new EMPLEADO
                {
                    NOMBREEMPLEADO = nombre,
                    APPATERNO = apellidoPaterno,
                    APMATERNO = apellidoMaterno,
                    SUELDO = decimal.Parse(sueldo),
                    FECHAINICIO = fechaInicio,
                    IDTIPOMODALIDAD = idTipoModalidad,
                    IDTIPOEMPLEADO = idTipoEmpleado,
                    USUARIO = usuario,
                    CONTRA = dataCifrada,
                    BHABILITADO = true
                };
                bd.EMPLEADO.InsertOnSubmit(emp);
                try
                {
                    bd.SubmitChanges();
                    MessageBox.Show("Se agrego Correctamente!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
            else
            {
                var consulta = bd.EMPLEADO.Where(p => p.IDEMPLEADO.Equals(id));
                foreach (EMPLEADO epm in consulta)
                {
                    epm.NOMBREEMPLEADO = nombre;
                    epm.APPATERNO = apellidoPaterno;
                    epm.APMATERNO = apellidoMaterno;
                    epm.SUELDO = decimal.Parse(sueldo);
                    epm.FECHAINICIO = fechaInicio;
                    epm.USUARIO = usuario;
                    epm.IDTIPOEMPLEADO = idTipoEmpleado;
                    epm.IDTIPOMODALIDAD = idTipoModalidad;
                }
                try
                {
                    bd.SubmitChanges();
                    MessageBox.Show("Se edito correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error");
                }

            }
        }
    }
}
