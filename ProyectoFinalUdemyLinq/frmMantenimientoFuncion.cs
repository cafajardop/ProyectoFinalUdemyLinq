using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;

namespace ProyectoFinalUdemyLinq
{
    public partial class frmMantenimientoFuncion : Form
    {
        public frmMantenimientoFuncion()
        {
            InitializeComponent();
        }
        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            frmPopupFuncion OfrmPopupFuncion = new frmPopupFuncion();
            OfrmPopupFuncion.accion = "Nuevo";
            OfrmPopupFuncion.ShowDialog();
            if (OfrmPopupFuncion.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }
        
        PruebaDataContext bd = new PruebaDataContext();
        private void listar()
        {
            dgvPeliculaFun.DataSource = (from funcion in bd.FUNCION
                                     join sala in bd.SALA
                                     on funcion.IDSALA equals sala.IDSALA
                                     join pelicula in bd.PELICULA
                                     on funcion.IDPELICULA equals pelicula.IDPELICULA
                                     join cine in bd.CINE
                                     on funcion.IDCINE equals cine.IDCINE
                                     where funcion.BHABILITADO.Equals(true)
                                     && pelicula.BHABILITADO.Equals(true)
                                     select new
                                     {
                                         idFuncion = funcion.IDFUNCION,
                                         nombreSala = sala.NOMBRE,
                                         nombrePelicula = pelicula.TITULO,
                                         nombreCine = cine.NOMBRE
                                     }).ToList();
        }


        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            frmPopupFuncion OfrmPopupFuncion = new frmPopupFuncion();
            OfrmPopupFuncion.accion = "Editar";
            OfrmPopupFuncion.id = dgvPeliculaFun.CurrentRow.Cells[0].Value.ToString();
            OfrmPopupFuncion.ShowDialog();
            if (OfrmPopupFuncion.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }

        private void frmMantenimientoFuncion_Load(object sender, EventArgs e)
        {
            cmbPeliculaFun.DataSource = bd.PELICULA.Where(p => p.BHABILITADO.Equals(true)).ToList();
            cmbPeliculaFun.DisplayMember = "TITULO";
            cmbPeliculaFun.ValueMember = "IDPELICULA";
            listar();
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar?", "Aviso", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                int idFuncion = (int)dgvPeliculaFun.CurrentRow.Cells[0].Value;
                try
                {
                    using (var transaccion = new TransactionScope())
                    {
                        var consultaFuncion = bd.FUNCION.Where(p => p.IDFUNCION.Equals(idFuncion));
                        foreach (var item in consultaFuncion)
                        {
                            item.BHABILITADO = false;
                        }
                        var consultaButaca = bd.BUTACA.Where(p => p.IDFUNCION.Equals(idFuncion));
                        foreach (var item in consultaButaca)
                        {
                            item.BHABILITADO = false;
                        }
                        bd.SubmitChanges();
                        listar();
                        transaccion.Complete();
                        MessageBox.Show("Se elimino correctamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
        }

        private void filtrar(object sender, EventArgs e)
        {
            int idPelicula = int.Parse(cmbPeliculaFun.SelectedValue.ToString());
            dgvPeliculaFun.DataSource = (from funcion in bd.FUNCION
                                     join sala in bd.SALA
                                     on funcion.IDSALA equals sala.IDSALA
                                     join pelicula in bd.PELICULA
                                     on funcion.IDPELICULA equals pelicula.IDPELICULA
                                     join cine in bd.CINE
                                     on funcion.IDCINE equals cine.IDCINE
                                     where funcion.BHABILITADO.Equals(true)
                                     && pelicula.IDPELICULA.Equals(idPelicula)
                                     && pelicula.BHABILITADO.Equals(true)
                                     select new
                                     {
                                         idFuncion = funcion.IDFUNCION,
                                         nombreSala = sala.NOMBRE,
                                         nombrePelicula = pelicula.TITULO,
                                         nombreCine = cine.NOMBRE
                                     }).ToList();
        }
    }
}