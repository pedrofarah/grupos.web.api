namespace PedroFarah.Web.Api.Entity
{
    public class Grupo : BaseEntity
    {
        public string Nome { get; set; }
        public List<GrupoCliente> GrupoClientes { get; set; }
    }
}
