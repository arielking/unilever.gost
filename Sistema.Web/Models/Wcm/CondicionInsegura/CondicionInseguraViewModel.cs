using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Wcm.CondicionInsegura
{
    public class CondicionInseguraViewModel
    {
        public int idcondinsegura { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public bool eliminado { get; set; }
    }
}
