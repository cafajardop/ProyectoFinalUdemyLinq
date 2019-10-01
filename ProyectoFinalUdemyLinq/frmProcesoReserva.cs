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
    public partial class frmProcesoReserva : Form
    {
        public frmProcesoReserva()
        {
            InitializeComponent();
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado ofrmBuscarEmpleado = new frmBuscarEmpleado();
            ofrmBuscarEmpleado.ShowDialog();
            if (ofrmBuscarEmpleado.DialogResult.Equals(DialogResult.OK))
            {
                txtCodigoEmpleado.Text = ofrmBuscarEmpleado.id;
                txtNombreEmpleado.Text = ofrmBuscarEmpleado.nombreCompleto;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente ofrmBuscarCliente = new frmBuscarCliente();
            ofrmBuscarCliente.ShowDialog();
            if (ofrmBuscarCliente.DialogResult.Equals(DialogResult.OK))
            {
                txtDNICliente.Text = ofrmBuscarCliente.id;
                txtNombreCliente.Text = ofrmBuscarCliente.nombreCompleto;
            }
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void frmProcesoReserva_Load(object sender, EventArgs e)
        {
            cboCine.DataSource = bd.CINE.ToList();
            cboCine.DisplayMember = "NOMBRE";
            cboCine.ValueMember = "IDCINE";
            //Carga de clientes
            dgvClientes.DataSource = bd.CLIENTE.Where(p => p.BHABILITADO.Equals(true)).
                Select(
                p => new
                {
                    p.IDCLIENTE,
                    p.DNICLIENTE,
                    p.NOMBRE,
                    p.APPATERNO,
                    p.APMATERNO,
                    p.TELEFONOCELULAR,
                    p.TELEFONOFIJO
                }

                ).ToList();
        }

        private void ObtenerPelicula(object sender, EventArgs e)
        {
            if (cboCine.SelectedValue != null)
            {
                int idcine = ((CINE)cboCine.SelectedItem).IDCINE;
                var consulta = (from funcion in bd.FUNCION
                                join pelicula in bd.PELICULA
                                on funcion.IDPELICULA equals
                                pelicula.IDPELICULA
                                where funcion.IDCINE.Equals(idcine)
                                && funcion.FECHAFUNCION > DateTime.Now
                                select new Pelicula
                                {
                                    idPelicula = pelicula.IDPELICULA,
                                    titulo = pelicula.TITULO
                                }

                                ).Distinct().ToList();
                if (consulta.Count == 0)
                {
                    cboFuncion.DataSource = null;
                    txtSala.Text = "";
                    cboTipoEntrada.DataSource = null;
                    txtprecio.Text = "";
                }
                cboPelicula.Text = "";

                cboPelicula.DataSource = consulta;
                cboPelicula.DisplayMember = "titulo";
                cboPelicula.ValueMember = "idPelicula";
            }
        }

        private void obtenerFunciones(object sender, EventArgs e)
        {
            if (cboPelicula.SelectedValue != null)
            {
                int idCine = ((CINE)cboCine.SelectedItem).IDCINE;
                int idPelicula = ((Pelicula)cboPelicula.SelectedItem).idPelicula;

                var consulta = (from funcion in bd.FUNCION
                                where funcion.IDCINE.Equals(idCine)
                                && funcion.IDPELICULA.Equals(idPelicula)
                                select new Funcion
                                {
                                    idFuncion = funcion.IDFUNCION,
                                    fechaFuncion = (DateTime)funcion.FECHAFUNCION
                                }).ToList();
                cboFuncion.DataSource = consulta;
                cboFuncion.DisplayMember = "FECHAFUNCION";
                cboFuncion.ValueMember = "IDFUNCION";
            }
        }

        private void obtenerSala(object sender, EventArgs e)
        {
            if (cboFuncion.SelectedValue != null)
            {
                int idFuncion = ((Funcion)cboFuncion.SelectedItem).idFuncion;
                var consulta = (from funcion in bd.FUNCION
                                join sala in bd.SALA
                                on funcion.IDSALA equals
                                sala.IDSALA
                                where funcion.IDFUNCION.Equals(idFuncion)
                                select new
                                {
                                    sala.IDSALA,
                                    sala.NOMBRE
                                }).ToList();

                foreach (var item in consulta)
                {
                    txtSala.Text = item.NOMBRE;
                }

                var consultaButacas = (from butaca in bd.BUTACA
                                      join funcion in bd.FUNCION
                                      on butaca.IDFUNCION equals
                                      funcion.IDFUNCION
                                      where funcion.IDFUNCION.Equals(idFuncion)
                                      && butaca.BHABILITADO.Equals(true)
                                      && butaca.BLIBRE.Equals(true)
                                      select new
                                      {
                                          butaca.IDFUNCION,
                                          butaca.IDBUTACA,
                                          butaca.INDICEFILA,
                                          butaca.INDICECOLUMNA
                                      }).ToList();

                dgvButacas.DataSource = consultaButacas;

                var consultaTipoEntrada = (from funcionEntrada in bd.FUNCIONENTRADA
                                           join tipoEntrada in bd.TIPOENTRADA
                                           on funcionEntrada.IDTIPOENTRADA equals
                                           tipoEntrada.IDTIPOENTRADA
                                           where funcionEntrada.IDFUNCION.Equals(idFuncion)
                                           select new TipoEntrada
                                           {
                                               IDTIPOENTRADA = tipoEntrada.IDTIPOENTRADA,
                                               NOMBRE = tipoEntrada.NOMBRE
                                           }).ToList();
                cboTipoEntrada.DataSource = consultaTipoEntrada;
                cboTipoEntrada.DisplayMember = "NOMBRE";
                cboTipoEntrada.ValueMember = "IDTIPOENTRADA";
            }
        }

        private void filtrarDNI(object sender, EventArgs e)
        {
            string dni = txtDNI.Text;
            dgvClientes.DataSource = bd.CLIENTE.Where(p => p.BHABILITADO.Equals(true)
            && p.DNICLIENTE.Contains(dni)
            ).
                Select(
                p => new
                {
                    p.IDCLIENTE,
                    p.DNICLIENTE,
                    p.NOMBRE,
                    p.APPATERNO,
                    p.APMATERNO,
                    p.TELEFONOCELULAR,
                    p.TELEFONOFIJO
                }

                ).ToList();
        }

        private void filtrarApellido(object sender, EventArgs e)
        {
            string apellido = txtApellidoCliente.Text;
            dgvClientes.DataSource = bd.CLIENTE.Where(p => p.BHABILITADO.Equals(true)
            && p.APPATERNO.Contains(apellido) || p.APMATERNO.Contains(apellido)
            ).
                Select(
                p => new
                {
                    p.IDCLIENTE,
                    p.DNICLIENTE,
                    p.NOMBRE,
                    p.APPATERNO,
                    p.APMATERNO,
                    p.TELEFONOCELULAR,
                    p.TELEFONOFIJO
                }

                ).ToList();
        }

        private void ObtenerPrecio(object sender, EventArgs e)
        {
            if(cboTipoEntrada.SelectedValue != null)
            {
                int idfuncion = ((Funcion)cboFuncion.SelectedItem).idFuncion;
                int idTipoEntrada = ((TipoEntrada)cboTipoEntrada.SelectedItem).IDTIPOENTRADA;
                var consulta = (from funcion in bd.FUNCION
                                join funcionEntrada in bd.FUNCIONENTRADA
                                on funcion.IDFUNCION equals funcionEntrada.IDFUNCION
                                where funcionEntrada.IDFUNCION.Equals(idfuncion)
                                && funcionEntrada.IDTIPOENTRADA.Equals(idTipoEntrada)
                                && funcionEntrada.BHABILITADO.Equals(true)
                                select new
                                {
                                    funcionEntrada.PRECIO
                                }).ToList();

                foreach (var item in consulta)
                {
                    txtprecio.Text = item.PRECIO.ToString();
                }

            }
        }
        List<Reserva> listaReserva = new List<Reserva>();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtCodigoEmpleado.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar el empleado que realizara la venta", "Aviso");
                return;
            }
            if(txtDNICliente.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el cliente", "Aviso");
                return;
            }
            int idCliente = (int)dgvClientes.CurrentRow.Cells[0].Value;
            int idFuncion = ((Funcion)cboFuncion.SelectedItem).idFuncion;
            int idButaca = (int)dgvButacas.CurrentRow.Cells[0].Value;
            int idTipoEntrada = ((TipoEntrada)cboTipoEntrada.SelectedItem).IDTIPOENTRADA;
            decimal precio = decimal.Parse(txtprecio.Text);
            string nombreCliente = dgvClientes.CurrentRow.Cells[2].Value.ToString() + " " +
                dgvClientes.CurrentRow.Cells[3].Value.ToString() + " " +
                dgvClientes.CurrentRow.Cells[4].Value.ToString();

            DateTime fechaFuncion = ((Funcion)cboFuncion.SelectedItem).fechaFuncion;
            string nombreCine = ((CINE)cboCine.SelectedItem).NOMBRE;
            string nombrePelicula = ((Pelicula)cboPelicula.SelectedItem).titulo;
            string nombreSala = txtSala.Text;
            Reserva oReserva = new Reserva
            {
                idCliente = idCliente,
                precio = precio,
                idFuncion = idFuncion,
                idButaca = idButaca,
                idTipoEntrada = idTipoEntrada,
                nombreCompleto = nombreCliente,
                fechaFuncion = fechaFuncion,
                nombreCine = nombreCine,
                nombrePelicula = nombrePelicula,
                nombreSala = nombreSala
            };
            listaReserva.Add(oReserva);
            listarDetalle();
            decimal suma = sumarMontos(listaReserva);
            txtPrecioTotal.Text = suma.ToString();
        }
        public decimal sumarMontos(List<Reserva> listaReserva)
        {
            int nelementos = listaReserva.Count;
            decimal suma = 0;
            for(int i= 0;i<nelementos;i++)
            {
                suma += listaReserva[i].precio;
            }
            return suma;
        }

        private void listarDetalle()
        {
            dgvDetalleReserva.DataSource = null;
            dgvDetalleReserva.DataSource = (from item in listaReserva
                                           join funcion in bd.FUNCION
                                           on item.idFuncion equals
                                           funcion.IDFUNCION
                                           join tipoEntrada in bd.TIPOENTRADA
                                           on item.idTipoEntrada equals
                                           tipoEntrada.IDTIPOENTRADA
                                           select new
                                           {
                                               NombreCliente = item.nombreCompleto,
                                               NombreCine = item.nombreCine,
                                               NombrePelicula = item.nombrePelicula,
                                               NombreSala = item.nombreSala,
                                               FechaFuncion = funcion.FECHAFUNCION,
                                               IdButaca = item.idButaca,
                                               TipoEntrada = tipoEntrada.NOMBRE,
                                               Precio = item.precio

                                           }).ToList();

        }
    }
}
