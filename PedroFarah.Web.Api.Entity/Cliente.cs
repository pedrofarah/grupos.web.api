namespace PedroFarah.Web.Api.Entity
{
    public class Cliente : BaseEntity
    {
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }
        public List<GrupoCliente> GrupoClientes { get; set; }
    }
}
