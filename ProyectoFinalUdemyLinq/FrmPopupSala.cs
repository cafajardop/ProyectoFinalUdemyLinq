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
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            int idcine = int.Parse(cmbNombre.SelectedValue.ToString());
            int numeroButacas = int.Parse(txtNumeroSillas.Value.ToString());
            int numeroFilas = int.Parse(txtNumeroFilas.Value.ToString());
            int numeroColumnas = int.Parse(txtNumeroColumnas.Value.ToString());
            if (accion.Equals("Nuevo"))
            {
                SALA osala = new SALA()
                {
                    IDCINE = idcine,
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


            }
        }
    }
}
