namespace PedroFarah.Web.Api.Domain.Dtos.AppSettings
{
    public class AppSettingsDto
    {
        public string Secret { get; set; }
        public int TokenExpirationHours { get; set; }
    }
}
