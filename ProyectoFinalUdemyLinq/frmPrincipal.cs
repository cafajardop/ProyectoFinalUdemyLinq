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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoCliente frmMantenimientoCliente = new frmMantenimientoCliente();
            frmMantenimientoCliente.ShowDialog();
        }

        private void cineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoCine ofrmMantenimientoCine = new frmMantenimientoCine();
            ofrmMantenimientoCine.ShowDialog();

        }

        private void peliculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoPelicula ofrmMantenimientoPelicula = new frmMantenimientoPelicula();
            ofrmMantenimientoPelicula.ShowDialog();
        }

        private void SalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoSala ofrmMantenimientoSala = new frmMantenimientoSala();
            ofrmMantenimientoSala.ShowDialog();
        }

        private void EmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoEmpleado ofrmMantenimientoEmpleado = new frmMantenimientoEmpleado();
            ofrmMantenimientoEmpleado.ShowDialog();
        }

        private void FuncionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoFuncion ofrmMantenimientoFuncion = new frmMantenimientoFuncion();
            ofrmMantenimientoFuncion.ShowDialog();
        }
    }
}
