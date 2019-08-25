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
    public partial class frmPopupCine : Form
    {
        public string accion { get; set; }
        public string id { get; set; }

        public frmPopupCine()
        {
            InitializeComponent();
        }

        PruebaDataContext bd = new PruebaDataContext();
        private void frmPopupCine_Load(object sender, EventArgs e)
        {
            cboTipoCine.DataSource = bd.TIPOCINE.ToList();
            cboTipoCine.DisplayMember = "NOMBRE";
            cboTipoCine.ValueMember = "IDTIPOCINE";
            if (accion.Equals("Editar"))
            {
                var consulta = bd.CINE.Where(p => p.IDCINE.Equals(id));
                foreach (CINE ocine in consulta)
                {
                    txtid.Text = ocine.IDCINE.ToString();
                    txtNombre.Text = ocine.NOMBRE;
                    txtDireccion.Text = ocine.DIRECCION;
                    txtFechaApertura.Value = DateTime.Parse(ocine.FECHAAPERTURA.ToString());

                }

            }
            else
            {
                this.Text = "Agregar Cine";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(""))
            {
                ErrorDatos.SetError(txtNombre, "Ingrese Nombre");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                ErrorDatos.SetError(txtNombre, "");
            }

            if (txtDireccion.Text.Equals(""))
            {
                ErrorDatos.SetError(txtDireccion, "Ingrese Dirección");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                ErrorDatos.SetError(txtDireccion, "");
            }
            string id = txtid.Text;
            string nombre = txtNombre.Text;
            int idTipoCine = int.Parse(cboTipoCine.SelectedValue.ToString());
            string direccion = txtDireccion.Text;
            DateTime fechaApertura = txtFechaApertura.Value;
            if (accion.Equals("Nuevo"))
            {
                int nveces = (bd.CINE.Where(p => p.NOMBRE.Equals(txtNombre.Text))).Count();
                if (nveces > 0)
                {
                    MessageBox.Show("Ya existe el cine");
                    return;

                }
                CINE ocine = new CINE()
                {
                    NOMBRE = nombre,
                    IDTIPOCINE = idTipoCine,
                    DIRECCION = direccion,
                    FECHAAPERTURA = fechaApertura,
                    BHABILITADO = 1
                };
                bd.CINE.InsertOnSubmit(ocine);
                try
                {
                    bd.SubmitChanges();
                    MessageBox.Show("Se agrego correctamente!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
            else
            {
                var consulta = bd.CINE.Where(p => p.IDCINE.Equals(id));
                foreach (CINE ocine in consulta)
                {
                    ocine.NOMBRE = nombre;
                    ocine.IDTIPOCINE = idTipoCine;
                    ocine.DIRECCION = direccion;
                    ocine.FECHAAPERTURA = fechaApertura;
                }
                try
                {
                    bd.SubmitChanges();
                    MessageBox.Show("Se edito correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
        }
    }
}
