using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUdemyLinq
{
    public class Reserva
    {
        public int idCliente { get; set; }
        public string nombreCompleto { get; set; }
        public decimal precio { get; set; }
        public int idFuncion { get; set; }
        public int idButaca { get; set; }
        public int idTipoEntrada { get; set; }
        public DateTime fechaFuncion { get; set; }
        public string nombreCine { get; set; }
        public string nombrePelicula { get; set; }
        public string nombreSala { get; set; }
    }
}
