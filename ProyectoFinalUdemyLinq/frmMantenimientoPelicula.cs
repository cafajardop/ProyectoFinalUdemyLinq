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
            if (ofrmPopUpPelicula.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }

        private void ToolStripLabel2_Click(object sender, EventArgs e)
        {
            frmPopUpPelicula ofrmPopUpPelicula = new frmPopUpPelicula();
            ofrmPopUpPelicula.accion = "Editar";
            ofrmPopUpPelicula.id = dgvPelicula.CurrentRow.Cells[0].Value.ToString();
            ofrmPopUpPelicula.ShowDialog();
            if (ofrmPopUpPelicula.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
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

        private void ToolStripLabel3_Click(object sender, EventArgs e)
        {
            string id = dgvPelicula.CurrentRow.Cells[0].Value.ToString();
            var consulta = bd.PELICULA.Where(p => p.IDPELICULA.Equals(id));
            if (MessageBox.Show("Desea Eliminar el registro?", "Aviso", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                foreach (PELICULA item in consulta)
                {
                    item.BHABILITADO = false;
                }
                try
                {
                    bd.SubmitChanges();
                    listar();
                    MessageBox.Show("Se elimino el registro");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
        }
    }
}
