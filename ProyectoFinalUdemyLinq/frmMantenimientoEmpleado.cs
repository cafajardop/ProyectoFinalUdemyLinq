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
    public partial class frmMantenimientoEmpleado : Form
    {
        public frmMantenimientoEmpleado()
        {
            InitializeComponent();
        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            frmPopupEmpleado ofrmPopupEmpleado = new frmPopupEmpleado();
            ofrmPopupEmpleado.accion = "Nuevo";
            ofrmPopupEmpleado.ShowDialog();
        }

        private void ToolStripLabel2_Click(object sender, EventArgs e)
        {
            frmPopupEmpleado ofrmPopupEmpleado = new frmPopupEmpleado();
            ofrmPopupEmpleado.accion = "Editar";
            ofrmPopupEmpleado.id = dgvEmpleado.CurrentRow.Cells[0].Value.ToString();
            ofrmPopupEmpleado.ShowDialog();
        }

        private void FrmMantenimientoEmpleado_Load(object sender, EventArgs e)
        {
            listar();
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void listar()
        {
            dgvEmpleado.DataSource = bd.EMPLEADO.Where(p => p.BHABILITADO.Equals(1)).Select(
                p => new
                {
                    p.IDEMPLEADO,
                    p.NOMBREEMPLEADO,
                    p.APPATERNO,
                    p.APMATERNO,
                    p.FECHAINICIO
                }).ToList();
        }

        private void filtrar(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = bd.EMPLEADO.Where(p => p.BHABILITADO.Equals(1) && p.NOMBREEMPLEADO.Contains(txtIngreseNombre.Text)).Select(
                p => new
                {
                    p.IDEMPLEADO,
                    p.NOMBREEMPLEADO,
                    p.APPATERNO,
                    p.APMATERNO,
                    p.FECHAINICIO
                }).ToList();
        }
    }
}
