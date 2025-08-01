namespace AGL.Api.ApplicationCore.Models
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = "AGL";
        public string Audience { get; set; } = "VALUABLECLIENTS";
        public string SecretKey { get; set; } = "tlzmfltzlsmsdntjsdlfjgrptjfwjdgkwk";
    }
}