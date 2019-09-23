using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ProyectoFinalUdemyLinq
{
    public partial class frmPopupFuncion : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        public frmPopupFuncion()
        {
            InitializeComponent();
        }
        PruebaDataContext bd = new PruebaDataContext();
        List<ENTRADA> listaEntrada = new List<ENTRADA>();
        private void FrmPopupFuncion_Load(object sender, EventArgs e)
        {
            cboPelicula.DataSource = bd.PELICULA;
            cboPelicula.DisplayMember = "TITULO";
            cboPelicula.ValueMember = "IDPELICULA";

            cboCine.DataSource = bd.CINE;
            cboCine.DisplayMember = "NOMBRE";
            cboCine.ValueMember = "IDCINE";

            cboTipo.DataSource = bd.TIPOENTRADA;
            cboTipo.DisplayMember = "NOMBRE";
            cboTipo.ValueMember = "IDTIPOENTRADA";

            if (accion.Equals("Editar"))
            {
                this.Text = "Editando Funcion";
                var consulta = bd.FUNCION.Where(p => p.IDFUNCION.Equals(id));
                foreach (FUNCION oFUNCION in consulta)
                {
                    txtfecha.Value = (DateTime)oFUNCION.FECHAFUNCION;
                    cboPelicula.SelectedValue = oFUNCION.IDPELICULA;
                    cboCine.SelectedValue = oFUNCION.IDCINE;
                    cboSala.SelectedValue = oFUNCION.IDSALA;
                }
                listaEntrada = (from funcionentrada in bd.FUNCIONENTRADA
                                join tipoEntrada in bd.TIPOENTRADA
                                on funcionentrada.IDTIPOENTRADA equals
                                tipoEntrada.IDTIPOENTRADA
                                where funcionentrada.IDFUNCION.Equals(id)
                                && funcionentrada.BHABILITADO.Equals(true)
                                select new ENTRADA
                                {
                                    idtipoentrada = funcionentrada.IDTIPOENTRADA,
                                    nombreTipo = tipoEntrada.NOMBRE,
                                    precio = (decimal)funcionentrada.PRECIO
                                }).ToList();
                dgvPrecios.DataSource = listaEntrada;
            }
            else
            {
                this.Text = "Agregando Funcion";

            }
        }
        private void obtenerDatos(object sender, EventArgs e)
        {
            int idcine = ((CINE)cboCine.SelectedItem).IDCINE;
            var consulta = bd.SALA.Where(p => p.IDCINE.Equals(idcine));
            cboSala.DataSource = consulta;
            cboSala.DisplayMember = "NOMBRE";
            cboSala.ValueMember = "IDSALA";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idTipoEntrada = ((TIPOENTRADA)cboTipo.SelectedItem).IDTIPOENTRADA;
            string nombre = ((TIPOENTRADA)cboTipo.SelectedItem).NOMBRE;
            decimal precio = txtprecio.Value;
            if (precio <= 0)
            {
                MessageBox.Show("Debe ser mayor 0 el precio");
                return;
            }
            var consulta = listaEntrada.Where(p => p.idtipoentrada.Equals(idTipoEntrada));
            int nveces = consulta.Count();
            if (nveces > 0)
            {
                MessageBox.Show("Ya se registro un precio para ese tipo");
                return;
            }
            dgvPrecios.DataSource = null;
            listaEntrada.Add(new ENTRADA
            {
                idtipoentrada = idTipoEntrada,
                nombreTipo = nombre,
                precio = precio
            });
            dgvPrecios.DataSource = listaEntrada;
            txtprecio.Value = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Insercion
            DateTime fecha = txtfecha.Value;
            int idPelicula = ((PELICULA)cboPelicula.SelectedItem).IDPELICULA;
            int idCine = ((CINE)cboCine.SelectedItem).IDCINE;
            int idSala = ((SALA)cboSala.SelectedItem).IDSALA;
            if (accion.Equals("Nuevo"))
            {
                if (dgvPrecios.Rows.Count.Equals(0))
                {
                    MessageBox.Show("Debe ingresar un precio");
                    return;
                }
                try
                {
                    using (var transaccion = new TransactionScope())
                    {
                        //Primer grabamos la funcion
                        FUNCION oFUNCION = new FUNCION
                        {
                            FECHAFUNCION = fecha,
                            IDPELICULA = idPelicula,
                            IDCINE = idCine,
                            IDSALA = idSala,
                            BHABILITADO = true
                        };
                        bd.FUNCION.InsertOnSubmit(oFUNCION);
                        //Confirmar los cambios
                        bd.SubmitChanges();
                        //Obtengo el Id autogenerado luego de insertar una funcion
                        int idfuncion = oFUNCION.IDFUNCION;

                        var consulta = bd.SALA.Where(p => p.IDSALA.Equals(idSala));
                        int ncolumnas = 0;
                        int nfilas = 0;
                        foreach (SALA osala in consulta)
                        {
                            ncolumnas = (int)osala.NUMEROCOLUMNAS;
                            nfilas = (int)osala.NUMEROFILAS;
                        }
                        int c = 1;
                        for (int i = 1; i <= nfilas; i++)
                        {
                            for (int j = 1; j <= ncolumnas; j++)
                            {
                                BUTACA obutaca = new BUTACA
                                {
                                    IDFUNCION = idfuncion,
                                    IDBUTACA = c,
                                    INDICECOLUMNA = j,
                                    INDICEFILA = i,
                                    BHABILITADO = true,
                                    BLIBRE = true
                                };
                                bd.BUTACA.InsertOnSubmit(obutaca);
                                c++;
                            }
                        }
                        bd.SubmitChanges();
                        //Guardar los tipos de entrada
                        int nlistas = listaEntrada.Count;
                        for (int i = 0; i < nlistas; i++)
                        {
                            FUNCIONENTRADA fe = new FUNCIONENTRADA
                            {
                                IDFUNCION = idfuncion,
                                IDTIPOENTRADA = listaEntrada[i].idtipoentrada,
                                PRECIO = listaEntrada[i].precio,
                                BHABILITADO = true
                            };
                            bd.FUNCIONENTRADA.InsertOnSubmit(fe);
                        }
                        bd.SubmitChanges();
                        transaccion.Complete();
                        MessageBox.Show("Se guardo correctamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error");

                }
            }
            else
            {
                try
                {
                    using (var transaccion = new TransactionScope())
                    {
                        var consultaFuncion = bd.FUNCION.Where(p => p.IDFUNCION.Equals(id));
                        foreach (FUNCION oFuncion in consultaFuncion)
                        {
                            oFuncion.FECHAFUNCION = fecha;
                            oFuncion.IDPELICULA = idPelicula;
                            oFuncion.IDCINE = idCine;
                            oFuncion.IDSALA = idSala;
                        }
                        //Editamos poner en bhabilitado=false
                        var consultaEntrada = bd.FUNCIONENTRADA.Where(p => p.IDFUNCION.Equals(id));
                        foreach (FUNCIONENTRADA oFUNCIONENTRADA in consultaEntrada)
                        {
                            oFUNCIONENTRADA.BHABILITADO = false;
                        }
                        //Id que esta en la grilla existe en la bd , lo que haremos
                        //es actualizar precio (bhabilitado=true)

                        //Id no existe en la bd entonces lo insertamos , y ponemos el bhabilitado=true
                        int nlista = listaEntrada.Count;
                        for (int i = 0; i < nlista; i++)
                        {
                            var consulta = bd.FUNCIONENTRADA.Where(p => p.IDTIPOENTRADA.Equals(
                                  listaEntrada[i].idtipoentrada
                                  ) && p.IDFUNCION.Equals(id));
                            int nveces = consulta.Count();
                            if (nveces == 0)
                            {
                                FUNCIONENTRADA FE = new FUNCIONENTRADA
                                {
                                    IDFUNCION = int.Parse(id),
                                    IDTIPOENTRADA = listaEntrada[i].idtipoentrada,
                                    PRECIO = listaEntrada[i].precio,
                                    BHABILITADO = true
                                };
                            }
                            else
                            {
                                foreach (FUNCIONENTRADA fe in consulta)
                                {
                                    fe.BHABILITADO = true;
                                    fe.PRECIO = listaEntrada[i].precio;
                                }
                            }
                        }
                        bd.SubmitChanges();
                        MessageBox.Show("Se edito correctamente");
                        transaccion.Complete();


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPrecios.Rows.Count.Equals(0))
            {
                MessageBox.Show("No hay registros a eliminar");
                return;
            }
            if (MessageBox.Show("Desea eliminar?", "Aviso", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                int id = (int)dgvPrecios.CurrentRow.Cells[0].Value;
                listaEntrada.RemoveAll(p => p.idtipoentrada.Equals(id));
                dgvPrecios.DataSource = null;
                dgvPrecios.DataSource = listaEntrada;
            }
        }
    }
}
