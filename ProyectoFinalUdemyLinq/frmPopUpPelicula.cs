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
    public partial class frmPopUpPelicula : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        public frmPopUpPelicula()
        {
            InitializeComponent();
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void frmPopUpPelicula_Load(object sender, EventArgs e)
        {
            cmbGenero.DataSource = bd.GENERO.ToList();
            cmbGenero.DisplayMember = "NOMBRE";
            cmbGenero.ValueMember = "IDGENERO";
            cmbPais.DataSource = bd.PAIS.ToList();
            cmbPais.DisplayMember = "NOMBRE";
            cmbPais.ValueMember = "IDPAIS";
            cmbTipoCensura.DataSource = bd.TIPOCENSURA.ToList();
            cmbTipoCensura.DisplayMember = "NOMBRE";
            cmbTipoCensura.ValueMember = "IDTIPOCENSURA";
            if (accion.Equals("Nuevo"))
            {
                this.Text = "Ingrese pelicula";
            }
            else
            {
                this.Text = "Actualice pelicula";
                var consulta = bd.PELICULA.Where(p => p.IDPELICULA.Equals(id));
                foreach (PELICULA pel in consulta)
                {
                    txtIdPelicula.Text = pel.IDPELICULA.ToString();
                    txtTitulo.Text = pel.TITULO;
                    txtFecha.Value = DateTime.Parse(pel.FECHAESTRENO.ToString());
                    cmbGenero.SelectedValue = pel.IDGENERO;
                    cmbPais.SelectedValue = pel.IDPAIS;
                    txtSinopsis.Text = pel.SINOPSIS;
                    txtDuracion.Text = pel.DURACION.ToString();
                    cmbTipoCensura.SelectedValue = pel.IDTIPOCENSURA;
                }
            }

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            if (titulo.Equals(""))
            {
                errorDato.SetError(txtTitulo, "Ingrese titulo");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorDato.SetError(txtTitulo, "");
            }

            DateTime fecha = txtFecha.Value;
            int idgenero = int.Parse(cmbGenero.SelectedValue.ToString());
            int idpais = int.Parse(cmbPais.SelectedValue.ToString());
            string sinopsis = txtSinopsis.Text;
            if (sinopsis.Equals(""))
            {
                errorDato.SetError(txtSinopsis, "Ingrese sinopsis");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorDato.SetError(txtTitulo, "");
            }
            if (txtDuracion.Equals(""))
            {
                errorDato.SetError(txtSinopsis, "Ingrese duracion");
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                errorDato.SetError(txtSinopsis, "");
            }

            int duracion = int.Parse(txtDuracion.Text);

            int idTipoCensura = int.Parse(cmbTipoCensura.SelectedValue.ToString());

            if (accion.Equals("Nuevo"))
            {
                PELICULA opelicula = new PELICULA()
                {
                    TITULO = titulo,
                    FECHAESTRENO = fecha.ToString(),
                    IDGENERO = idgenero,
                    IDPAIS = idpais,
                    SINOPSIS = sinopsis,
                    DURACION = duracion,
                    IDTIPOCENSURA = idTipoCensura,
                    BHABILITADO = true
                };
                bd.PELICULA.InsertOnSubmit(opelicula);
                try
                {
                    bd.SubmitChanges();
                    MessageBox.Show("Se agrego correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurro un error");
                }
            }
            else
            {
                int id = int.Parse(txtIdPelicula.Text);
                var consulta = bd.PELICULA.Where(p => p.IDPELICULA.Equals(id));
                foreach (PELICULA pel in consulta)
                {
                    pel.TITULO = titulo;
                    pel.FECHAESTRENO = fecha.ToString();
                    pel.IDGENERO = idgenero;
                    pel.IDPAIS = idpais;
                    pel.SINOPSIS = sinopsis;
                    pel.DURACION = duracion;
                    pel.IDTIPOCENSURA = idTipoCensura;
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
