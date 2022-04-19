namespace UsersSample.Persistence.Configuration;

using System;

public class PersistenceConfiguration
{
    public string Host { get; }
    public int Port { get; }
    public string User { get; }
    public string Password { get; }
    public string DbName { get; }
    
    public PersistenceConfiguration(string host, int port, string user, string password, string dbName)
    {
        Host = host;
        Port = port;
        User = user;
        Password = password;
        DbName = dbName;
    }

    public static PersistenceConfiguration FromEnvVars()
    {
        if (!int.TryParse(Environment.GetEnvironmentVariable("POSTGRES_PORT"), out int port))
        {
            throw new Exception("Invalid POSTGRES_PORT ENV");
        }
        
        return new PersistenceConfiguration(
            Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? throw new Exception("Invalid POSTGRES_HOST ENV"),
            port,
            Environment.GetEnvironmentVariable("POSTGRES_USER") ?? throw new Exception("Invalid POSTGRES_USER ENV"),
            Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? throw new Exception("Invalid POSTGRES_PASSWORD ENV"),
            Environment.GetEnvironmentVariable("POSTGRES_DB") ?? throw new Exception("Invalid POSTGRES_DB ENV")
        );
    }
    
    internal string GetConnectionString() =>
        $"Host={Host};Port={Port};Username={User};Password={Password};Database={DbName};SSL Mode=Prefer;Trust Server Certificate=true;Server Compatibility Mode=Redshift";
}