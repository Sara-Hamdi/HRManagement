namespace HRManagement.API.Configurations
{
    public class JwtOptions
    {
        public const string Jwt = "Jwt";
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public bool ValidateAudience { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateEnsureSigningKey { get; set; }
    }
}
