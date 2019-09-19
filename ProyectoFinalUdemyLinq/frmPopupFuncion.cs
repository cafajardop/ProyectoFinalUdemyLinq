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
    public partial class frmPopupFuncion : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        public frmPopupFuncion()
        {
            InitializeComponent();
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void FrmPopupFuncion_Load(object sender, EventArgs e)
        {
            cmbPelicula.DataSource = bd.PELICULA;
            cmbPelicula.DisplayMember = "TITULO";
            cmbPelicula.ValueMember = "IDPELICULA";

            cmbCine.DataSource = bd.CINE;
            cmbCine.DisplayMember = "NOMBRE";
            cmbCine.ValueMember = "IDCINE";

        }
    }
}
