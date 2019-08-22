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
    public partial class frmMantenimientoCliente : Form
    {
        public frmMantenimientoCliente()
        {
            InitializeComponent();
        }

        private void toolNuevo_Click(object sender, EventArgs e)
        {
            frmPopup frmPopup = new frmPopup();
            frmPopup.accion = "Nuevo";
            frmPopup.ShowDialog();
            if (frmPopup.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }

        }

        private void toolEditar_Click(object sender, EventArgs e)
        {
            frmPopup frmPopup = new frmPopup();
            frmPopup.accion = "Editar";
            frmPopup.id = dgvCliente.CurrentRow.Cells[0].Value.ToString();
            frmPopup.ShowDialog();
            if (frmPopup.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }

        private void frmMantenimientoCliente_Load(object sender, EventArgs e)
        {
            listar();
        }

        PruebaDataContext bd = new PruebaDataContext();
        private void listar()
        {
            dgvCliente.DataSource = bd.CLIENTE.Where(p => p.BHABILITADO.Equals(1)).Select(
                p =>
                new
                {
                    p.IDCLIENTE,
                    p.DNICLIENTE,
                    p.NOMBRE,
                    p.APPATERNO,
                    p.APMATERNO,
                    p.TELEFONOFIJO,
                    p.TELEFONOCELULAR
                }
                ).ToList();
        }

        private void toolEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea eliminar", "Aviso", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                string id = dgvCliente.CurrentRow.Cells[0].Value.ToString();

                var consulta = bd.CLIENTE.Where(p => p.IDCLIENTE.Equals(id));
                foreach (CLIENTE cli in consulta)
                {
                    cli.BHABILITADO = false;
                }
                try
                {
                    bd.SubmitChanges();
                    listar();
                    MessageBox.Show("Se elimino correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurio un error");
                }
            }
        }

        private void filtra(object sender, EventArgs e)
        {
            dgvCliente.DataSource = bd.CLIENTE.Where(p => p.BHABILITADO.Equals(1) && p.DNICLIENTE.Contains(txtCliente.Text )).Select(
                p =>
                new
                {
                    p.IDCLIENTE,
                    p.DNICLIENTE,
                    p.NOMBRE,
                    p.APPATERNO,
                    p.APMATERNO,
                    p.TELEFONOFIJO,
                    p.TELEFONOCELULAR
                }
                ).ToList();
        }
    }
}
