using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoFinalUdemyLinq
{
    public partial class frmPeliculaPorGenero : MaterialForm
    {
        public frmPeliculaPorGenero()
        {
            InitializeComponent();
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void frmPeliculaPorGenero_Load(object sender, EventArgs e)
        {
            cboGenero.DataSource = bd.GENERO.Where(p=>p.BHABILITADO.Equals(true)).ToList();
            cboGenero.DisplayMember = "NOMBRE";
            cboGenero.ValueMember = "IDGENERO";
            listar();
        }
        private void listar()
        {
            dgvPelicula.DataSource = (from pelicula in bd.PELICULA
                                     join genero in bd.GENERO
                                     on pelicula.IDGENERO equals
                                     genero.IDGENERO
                                     join pais in bd.PAIS
                                     on pelicula.IDPAIS equals
                                     pais.IDPAIS
                                     where pelicula.BHABILITADO.Equals(true)
                                     select new
                                     {
                                       Titulo=  pelicula.TITULO,
                                       FechaEstreno =  pelicula.FECHAESTRENO,
                                       DuracionPelicula=  pelicula.DURACION,
                                       NombreGenero =  genero.NOMBRE,
                                       NombrePais = pais.NOMBRE
                                     }).ToList();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            int idGenero = ((GENERO)cboGenero.SelectedItem).IDGENERO;
            dgvPelicula.DataSource = (from pelicula in bd.PELICULA
                                      join genero in bd.GENERO
                                      on pelicula.IDGENERO equals
                                      genero.IDGENERO
                                      join pais in bd.PAIS
                                      on pelicula.IDPAIS equals
                                      pais.IDPAIS
                                      where pelicula.BHABILITADO.Equals(true)
                                      && pelicula.IDGENERO.Equals(idGenero)
                                      select new
                                      {
                                          Titulo = pelicula.TITULO,
                                          FechaEstreno = pelicula.FECHAESTRENO,
                                          DuracionPelicula = pelicula.DURACION,
                                          NombreGenero = genero.NOMBRE,
                                          NombrePais = pais.NOMBRE
                                      }).ToList();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            listar();
        }
    }
}
