namespace netart.Services;

public class AppSettingService(IConfiguration configuration)
{
    public string SecretKey { get; set; } = configuration["JwtSettings:SecretKey"]  ?? throw new InvalidOperationException("JWT secret key is missing in configuration.");
    public string Issuer { get; set; } = configuration["JwtSettings:Issuer"]  ?? throw new InvalidOperationException("JWT Issuer is missing in configuration.");
    public string Audience { get; set; } = configuration["JwtSettings:Audience"]  ?? throw new InvalidOperationException("JWT Audience is missing in configuration.");
}