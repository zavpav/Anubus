namespace Anubus.Services.Security
{
    public class SecuritySettings
    {
        public bool WithoutIdm { get; set; }

        public string IdmConnectionString { get; set; } = string.Empty;

    }
}
