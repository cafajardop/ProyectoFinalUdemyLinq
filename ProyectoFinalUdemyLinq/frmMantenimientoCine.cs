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
    public partial class frmMantenimientoCine : Form
    {
        public frmMantenimientoCine()
        {
            InitializeComponent();
        }

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            frmPopupCine ofrmPopupCine = new frmPopupCine();
            ofrmPopupCine.accion = "Nuevo";
            ofrmPopupCine.ShowDialog();
        }

        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            frmPopupCine ofrmPopupCine = new frmPopupCine();
            ofrmPopupCine.id = dgvCine.CurrentRow.Cells[0].Value.ToString();
            ofrmPopupCine.accion = "Editar";
            ofrmPopupCine.ShowDialog();
        }

        PruebaDataContext bd = new PruebaDataContext();

        private void frmMantenimientoCine_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void listar()
        {
            dgvCine.DataSource = bd.CINE.Where(x=>x.BHABILITADO.Equals(1)).Select(
                p => new
                {
                    p.IDCINE,
                    p.NOMBRE,
                    p.DIRECCION
                }
                ).ToList();
        }

        private void Filtrar(object sender, EventArgs e)
        {
            dgvCine.DataSource = bd.CINE.Where(x => x.BHABILITADO.Equals(1) && x.NOMBRE.Contains(txtNombreCine.Text)).Select(
                p => new
                {
                    p.IDCINE,
                    p.NOMBRE,
                    p.DIRECCION
                }
                ).ToList();
        }
    }
}
