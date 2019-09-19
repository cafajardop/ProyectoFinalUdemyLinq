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
    public partial class FrmPopupSala : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        public FrmPopupSala()
        {
            InitializeComponent();
        }

        PruebaDataContext bd = new PruebaDataContext();
        private void FrmPopupSala_Load(object sender, EventArgs e)
        {
            cmbNombre.DataSource = bd.CINE.ToList();
            cmbNombre.DisplayMember = "NOMBRE";
            cmbNombre.ValueMember = "IDCINE";
            if (accion.Equals("Editar"))
            {
                var consulta = bd.SALA.Where(p => p.IDSALA.Equals(id));
                foreach (SALA osala in consulta)
                {
                    cmbNombre.SelectedValue = osala.IDCINE;
                    txtNombreSala.Text = osala.NOMBRE.ToString();
                    txtNumeroSillas.Value = decimal.Parse(osala.NUMBUTACAS.ToString());
                    txtNumeroFilas.Value = decimal.Parse(osala.NUMEROFILAS.ToString());
                    txtNumeroColumnas.Value = decimal.Parse(osala.NUMEROCOLUMNAS.ToString());
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            int idcine = int.Parse(cmbNombre.SelectedValue.ToString());
            string nombre = txtNombreSala.Text;
            if (nombre.Equals(""))
            {
                errorDatos.SetError(txtNombreSala, "Nombre Obligario");
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                errorDatos.SetError(txtNombreSala, "");
            }
            int numeroButacas = int.Parse(txtNumeroSillas.Value.ToString());
            if (numeroButacas <= 0)
            {
                errorDatos.SetError(txtNumeroSillas, "El numero de sillas tiene que ser mayor a cero");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorDatos.SetError(txtNumeroSillas, "");
            }
            int numeroFilas = int.Parse(txtNumeroFilas.Value.ToString());
            if (numeroFilas <= 0)
            {
                errorDatos.SetError(txtNumeroFilas, "El numero de filas tiene que ser mayor a cero");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorDatos.SetError(txtNumeroFilas, "");
            }
            int numeroColumnas = int.Parse(txtNumeroColumnas.Value.ToString());
            if (numeroColumnas <= 0)
            {
                errorDatos.SetError(txtNumeroColumnas, "El numero de columnas tiene que ser mayor a cero");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorDatos.SetError(txtNumeroColumnas, "");
            }
            if (accion.Equals("Nuevo"))
            {
                SALA osala = new SALA()
                {
                    IDCINE = idcine,
                    NOMBRE = nombre,
                    NUMBUTACAS = numeroButacas,
                    NUMEROFILAS = numeroFilas,
                    NUMEROCOLUMNAS = numeroColumnas,
                    BHABILITADO = true
                };
                bd.SALA.InsertOnSubmit(osala);
                try
                {
                    bd.SubmitChanges();
                    MessageBox.Show("Se agrego correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
            else
            {
                var consulta = bd.SALA.Where(p => p.IDSALA.Equals(id));
                foreach (SALA osala in consulta)
                {
                    osala.IDCINE = idcine;
                    osala.NOMBRE = nombre;
                    osala.NUMBUTACAS = numeroButacas;
                    osala.NUMEROFILAS = numeroFilas;
                    osala.NUMEROCOLUMNAS = numeroColumnas;
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
