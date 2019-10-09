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
    public partial class frmReservaCliente : MaterialForm
    {
        public frmReservaCliente()
        {
            InitializeComponent();
        }
        PruebaDataContext bd = new PruebaDataContext();
        private void frmReservaCliente_Load(object sender, EventArgs e)
        {
            cboCliente.DataSource = bd.CLIENTE.Where(p => p.BHABILITADO.Equals(true)).ToList();
            cboCliente.DisplayMember = "APPATERNO";
            cboCliente.ValueMember = "IDCLIENTE";
            listar();
        }

        private void listar()
        {
            dgvReserva.DataSource = (from reserva in bd.RESERVA
                                     join empleado in bd.EMPLEADO
                                     on reserva.IDEMPLEADO equals
                                     empleado.IDEMPLEADO
                                     join cliente in bd.CLIENTE
                                     on reserva.IDCLIENTE equals
                                     cliente.IDCLIENTE
                                     where reserva.BHABILITADO.Equals(true)
                                     select new
                                     {
                                         IdReserva = reserva.IDRESERVA,
                                         NombreCliente = cliente.NOMBRE + " " + cliente.APPATERNO + " " + cliente.APMATERNO,
                                         NombreEmpleado = empleado.NOMBREEMPLEADO + " " + empleado.APPATERNO + " " + empleado.APMATERNO,
                                         TotalPagar = reserva.TOTAL
                                     }).ToList();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idCliente = ((CLIENTE)cboCliente.SelectedItem).IDCLIENTE;
            dgvReserva.DataSource = (from reserva in bd.RESERVA
                                     join empleado in bd.EMPLEADO
                                     on reserva.IDEMPLEADO equals
                                     empleado.IDEMPLEADO
                                     join cliente in bd.CLIENTE
                                     on reserva.IDCLIENTE equals
                                     cliente.IDCLIENTE
                                     where reserva.BHABILITADO.Equals(true)
                                     && reserva.IDCLIENTE.Equals(idCliente)
                                     select new
                                     {
                                         IdReserva = reserva.IDRESERVA,
                                         NombreCliente = cliente.NOMBRE + " " + cliente.APPATERNO + " " + cliente.APMATERNO,
                                         NombreEmpleado = empleado.NOMBREEMPLEADO + " " + empleado.APPATERNO + " " + empleado.APMATERNO,
                                         TotalPagar = reserva.TOTAL
                                     }).ToList();
        }

        private void obtenerDatos(object sender, DataGridViewCellEventArgs e)
        {
            int idReserva = (int)dgvReserva.CurrentRow.Cells[0].Value;
            var consulta = (from detallereserva in bd.DETALLERESERVA
                            join cliente in bd.CLIENTE
                            on detallereserva.IDCLIENTE equals
                            cliente.IDCLIENTE
                            join funcion in bd.FUNCION
                            on detallereserva.IDFUNCION equals
                            funcion.IDFUNCION
                            join pelicula in bd.PELICULA
                            on funcion.IDPELICULA equals
                            pelicula.IDPELICULA
                            join cine in bd.CINE
                            on funcion.IDCINE equals
                            cine.IDCINE
                            where detallereserva.BHABILITADO.Equals(true)
                            && detallereserva.IDRESERVA.Equals(idReserva)
                            select new
                            {
                                NombreCompletoCliente = cliente.NOMBRE + " " + cliente.APPATERNO + " " + cliente.APPATERNO,
                                NombreCine = cine.NOMBRE,
                                NombrePelicula = pelicula.FECHAESTRENO,
                                Precio = detallereserva.PRECIO,

                            }).ToList();

            dgvDetalle.DataSource = consulta;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            listar();
            dgvDetalle.DataSource = null;
        }
    }
}
