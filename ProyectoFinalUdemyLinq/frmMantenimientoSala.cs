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
    public partial class frmMantenimientoSala : Form
    {
        public frmMantenimientoSala()
        {
            InitializeComponent();
        }

        private void ToolStripNuevo_Click(object sender, EventArgs e)
        {
            FrmPopupSala oFrmPopupSala = new FrmPopupSala();
            oFrmPopupSala.accion = "Nuevo";
            oFrmPopupSala.ShowDialog();
            if (oFrmPopupSala.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }

        private void ToolStripEditar_Click(object sender, EventArgs e)
        {
            FrmPopupSala oFrmPopupSala = new FrmPopupSala();
            oFrmPopupSala.accion = "Editar";
            oFrmPopupSala.id = dgvSala.CurrentRow.Cells[0].Value.ToString();
            oFrmPopupSala.ShowDialog();
            if (oFrmPopupSala.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void listar()
        {
            dgvSala.DataSource = (from sala in bd.SALA
                                  join cine in bd.CINE
                                  on sala.IDCINE equals cine.IDCINE
                                  where sala.BHABILITADO.Equals(1)
                                  select new
                                  {
                                      sala.IDSALA,
                                      cine.NOMBRE,
                                      sala.NUMBUTACAS,
                                      sala.NUMEROCOLUMNAS,
                                      sala.NUMEROFILAS
                                  }).ToList();
        }

        private void FrmMantenimientoSala_Load(object sender, EventArgs e)
        {
            listar();
            cmbNombre.DataSource = bd.CINE.ToList();
            cmbNombre.DisplayMember = "NOMBRE";
            cmbNombre.ValueMember = "IDCINE";
        }

        private void filtrar(object sender, EventArgs e)
        {
            int idcine = int.Parse(cmbNombre.SelectedValue.ToString());
            dgvSala.DataSource = (from sala in bd.SALA
                                  join cine in bd.CINE
                                  on sala.IDCINE equals cine.IDCINE
                                  where sala.BHABILITADO.Equals(1) && sala.IDCINE.Equals(idcine)
                                  select new
                                  {
                                      sala.IDSALA,
                                      cine.NOMBRE,
                                      sala.NUMBUTACAS,
                                      sala.NUMEROCOLUMNAS,
                                      sala.NUMEROFILAS
                                  }).ToList();
        }

        private void ToolStripEliminar_Click(object sender, EventArgs e)
        {
            string id = dgvSala.CurrentRow.Cells[0].Value.ToString();
            if(MessageBox.Show("Desea eliminar?","Aviso",MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                var consulta = bd.SALA.Where(p => p.IDSALA.Equals(id));
                foreach (SALA osala in consulta)
                {
                    osala.BHABILITADO = false;
                }
                try
                {
                    bd.SubmitChanges();
                    listar();
                    MessageBox.Show("Se elimino correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error");
                }

            }
        }
    }
}
