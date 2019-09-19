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
    public partial class frmMantenimientoFuncion : Form
    {
        public frmMantenimientoFuncion()
        {
            InitializeComponent();
        }

        private void ToolStripNuevo_Click(object sender, EventArgs e)
        {
            frmPopupFuncion ofrmPopupFuncion = new frmPopupFuncion();
            ofrmPopupFuncion.accion = "Nuevo";
            ofrmPopupFuncion.ShowDialog();
        }

        private void ToolStripEditar_Click(object sender, EventArgs e)
        {
            frmPopupFuncion ofrmPopupFuncion = new frmPopupFuncion();
            ofrmPopupFuncion.accion = "Editar";
            ofrmPopupFuncion.id = dgvPeliculaFun.CurrentRow.Cells[0].Value.ToString();
            ofrmPopupFuncion.ShowDialog();
        }
    }
}
