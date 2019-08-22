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
                    txtNombre.Text = ocine.NOMBRE;
                    txtDireccion.Text = ocine.DIRECCION;
                    txtFechaApertura.Value = DateTime.Parse(ocine.FECHAAPERTURA.ToString());

                }

            }

        }
    }
}
