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
    public partial class frmPopup : Form
    {
        public string accion { get; set; }
        public string id { get; set; }

        public frmPopup()
        {
            InitializeComponent();
        }

        PruebaDataContext bd = new PruebaDataContext();

        private void frmPopup_Load(object sender, EventArgs e)
        {
            cmbSexo.DataSource = bd.SEXO.ToList();
            cmbSexo.DisplayMember = "NOMBRE";
            cmbSexo.ValueMember = "IDSEXO";

            if (accion.Equals("Nuevo"))
            {
                this.Text = "Ingrese nuevo cliente";
            }
            else
            {
                this.Text = "Actualice cliente";
                var consulta = bd.CLIENTE.Where(p => p.IDCLIENTE.Equals(id));

                foreach (CLIENTE cli in consulta)
                {
                    txtCedula.Text = cli.DNICLIENTE.ToString();
                    txtNombre.Text = cli.NOMBRE;
                    txtPrimerApellido.Text = cli.APPATERNO;
                    txtSegundoApellido.Text = cli.APMATERNO;
                    dtpFechaNacimiento.Value = DateTime.Parse(cli.FECHANAC.ToString());
                    txtDireccion.Text = cli.DIRECCION;
                    txtTelefonoFijo.Text = cli.TELEFONOFIJO;
                    txtTelefonoCelular.Text = cli.TELEFONOCELULAR;
                    cmbSexo.SelectedValue = cli.IDSEXO;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text.Equals(""))
            {
                errorDato.SetError(txtCedula, "Ingrese una cedula");
                this.DialogResult = DialogResult.None;
                return;
            }
            else {
                errorDato.SetError(txtCedula, "");
            }

            if (txtNombre.Text.Equals(""))
            {
                errorDato.SetError(txtNombre, "Ingrese Nombre");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorDato.SetError(txtNombre, "");
            }

            if (txtPrimerApellido.Text.Equals(""))
            {
                errorDato.SetError(txtPrimerApellido, "Ingrese Primer Apellido");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorDato.SetError(txtPrimerApellido, "");
            }


            if (txtSegundoApellido.Text.Equals(""))
            {
                errorDato.SetError(txtSegundoApellido, "Ingrese Segundo Apellido");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorDato.SetError(txtSegundoApellido, "");
            }


            string dni = txtCedula.Text;
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtPrimerApellido.Text;
            string apellidoMaterno = txtSegundoApellido.Text;
            DateTime fecha = dtpFechaNacimiento.Value;
            string direccion = txtDireccion.Text;
            string telefonoFijo = txtTelefonoFijo.Text;
            string telefonoCelular = txtTelefonoCelular.Text;
            int idSexo = int.Parse(cmbSexo.SelectedValue.ToString());

            if (accion.Equals("Nuevo"))
            {
                //Si existe una cedula en la bd no deberia permitir registrar 
                int numero = (bd.CLIENTE.Where(p => p.DNICLIENTE.Equals(dni))).Count();
                if (numero > 0)
                {
                    MessageBox.Show("La cedula ya existe en la base de datos");
                    return;
                }

                //Nuevo
                CLIENTE cli = new CLIENTE() {
                    DNICLIENTE = dni,
                    NOMBRE = nombre,
                    APPATERNO = apellidoPaterno,
                    APMATERNO = apellidoMaterno,
                    FECHANAC = fecha,
                    DIRECCION = direccion,
                    TELEFONOFIJO = telefonoFijo,
                    TELEFONOCELULAR = telefonoCelular,
                    IDSEXO = idSexo,
                    BHABILITADO = true
                };
                bd.CLIENTE.InsertOnSubmit(cli);
                try
                {
                    bd.SubmitChanges();
                    MessageBox.Show("Se agrego correctamente!!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ocurrio un error verique " + ex);
                }

            }
            else {
                //Editar

                var consulta = bd.CLIENTE.Where(p => p.IDCLIENTE.Equals(id));
                foreach (CLIENTE cli in consulta)
                {
                    cli.DNICLIENTE = dni;
                    cli.NOMBRE = nombre;
                    cli.APPATERNO = apellidoPaterno;
                    cli.APMATERNO = apellidoMaterno;
                    cli.FECHANAC = fecha;
                    cli.DIRECCION = direccion;
                    cli.TELEFONOCELULAR = telefonoCelular;
                    cli.TELEFONOFIJO = telefonoFijo;
                    cli.IDSEXO = idSexo;
                }
                try
                {
                    bd.SubmitChanges();
                    MessageBox.Show("Se edito correctamente!!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ocurrio un error verique " + ex);
                }


            }
        }
    }
}
