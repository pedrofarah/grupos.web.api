using System.Text.Json.Serialization;

namespace PedroFarah.Web.Api.Entity
{
    public class GrupoCliente : BaseEntity
    {
        public Guid GrupoId { get; set; }
        public Guid ClienteId { get; set; }
        [JsonIgnore]
        public virtual Grupo Grupo { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
    }
}
