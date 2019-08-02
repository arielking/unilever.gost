using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Wcm.Tarjeta
{
    public class TarjetaModel
    {
        public int idtarjeta { get; set; }
        public string nombre { get; set; }

        public bool activo { get; set; }
        public string descripcion { get; set; }
        public bool eliminado { get; set; }
    }
}
