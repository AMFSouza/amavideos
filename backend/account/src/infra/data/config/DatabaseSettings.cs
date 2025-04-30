namespace AmaMovies.Account.Infra.Data.Config
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public int CommandTimeout { get; set; } = 30;
        public bool EnableLogging { get; set; } = false;
    }
}