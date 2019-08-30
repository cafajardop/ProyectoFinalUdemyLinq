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
    public partial class frmMantenimientoPelicula : Form
    {
        public frmMantenimientoPelicula()
        {
            InitializeComponent();
        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            frmPopUpPelicula ofrmPopUpPelicula = new frmPopUpPelicula();
            ofrmPopUpPelicula.accion = "Nuevo";
            ofrmPopUpPelicula.ShowDialog();
        }

        private void ToolStripLabel2_Click(object sender, EventArgs e)
        {
            frmPopUpPelicula ofrmPopUpPelicula = new frmPopUpPelicula();
            ofrmPopUpPelicula.accion = "Editar";
            ofrmPopUpPelicula.id = dgvPelicula.CurrentRow.Cells[0].Value.ToString();
            ofrmPopUpPelicula.ShowDialog();
        }

        private void FrmMantenimientoPelicula_Load(object sender, EventArgs e)
        {
            listar();
        }

        PruebaDataContext bd = new PruebaDataContext();
        public void listar()
        {
            dgvPelicula.DataSource = bd.PELICULA.Where(p => p.BHABILITADO.Equals(1)).Select(p =>
               new
               {
                   p.IDPELICULA,
                   p.TITULO,
                   p.FECHAESTRENO,
                   p.SINOPSIS,
                   p.DURACION
               }).ToList();
        }

        private void filtrar(object sender, EventArgs e)
        {
            dgvPelicula.DataSource = bd.PELICULA.Where(p => p.BHABILITADO.Equals(1) && p.TITULO.Contains(txtNombrePelicula.Text) ).Select(p =>
               new
               {
                   p.IDPELICULA,
                   p.TITULO,
                   p.FECHAESTRENO,
                   p.SINOPSIS,
                   p.DURACION
               }).ToList();
        }
    }
}
