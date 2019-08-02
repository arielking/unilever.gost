
namespace Sistema.Web.Models.Wcm.Anomalia
{
    public class AnomaliaModel
    {
        public int idanomalia { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public bool eliminado { get; set; }
    }
}
