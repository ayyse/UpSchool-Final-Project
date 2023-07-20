namespace CrawlerApp.Domain.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; } // kim oluşturdu
        public string Audience { get; set; } // kim için oluşturdu
        public int ExpiryInMinutes { get; set; }
    }
}
