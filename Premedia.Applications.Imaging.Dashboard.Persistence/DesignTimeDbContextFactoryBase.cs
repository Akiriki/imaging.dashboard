using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Premedia.Applications.Imaging.Dashboard.Persistence;

public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
{
    protected DesignTimeDbContextFactoryBase(string connectionStringName, string migrationsAssemblyName)
    {
        ConnectionStringName = connectionStringName;
        MigrationsAssemblyName = migrationsAssemblyName;
    }

    private string ConnectionStringName { get; }
    private string MigrationsAssemblyName { get; }

    public TContext CreateDbContext(string[] args)
    {
        return Create(
            Directory.GetCurrentDirectory(),
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
            ConnectionStringName, MigrationsAssemblyName);
    }

    protected abstract TContext CreateNewInstance(
        DbContextOptions<TContext> options);

    public TContext CreateWithConnectionStringName(string connectionStringName, string migrationsAssemblyName)
    {
        var environmentName =
            Environment.GetEnvironmentVariable(
                "ASPNETCORE_ENVIRONMENT");
        Console.WriteLine("Current Environment: " + environmentName);

        var basePath = AppContext.BaseDirectory;

        return Create(basePath, environmentName, connectionStringName, migrationsAssemblyName);
    }

    private TContext Create(string basePath, string? environmentName, string connectionStringName,
        string migrationsAssemblyName)
    {
        if (String.IsNullOrEmpty(environmentName)) environmentName = "Production";

        var settingsFileName = "appsettings";
        if (!File.Exists(Path.Combine(basePath, settingsFileName + ".json")))
        {
            basePath = Path.Combine(
                Directory.GetParent(basePath)?.ToString() ?? string.Empty,
                "Web");
        }

        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile(settingsFileName + ".json")
            .AddJsonFile($"{settingsFileName}.{environmentName}.json", true)
            .AddEnvironmentVariables();

        var config = builder.Build();

        var connectionString = config.GetConnectionString(connectionStringName);
        Console.WriteLine($"Environment: {environmentName ?? "PRODUCTION"}");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException(
                $"Could not find a connection string named '{connectionStringName}'.");
        return CreateWithConnectionString(connectionStringName, connectionString, migrationsAssemblyName);
    }

    private TContext CreateWithConnectionString(string connectionStringName, string connectionString,
        string migrationsAssembly)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentException(
                $"{nameof(connectionString)} is null or empty.",
                nameof(connectionString));

        var optionsBuilder = new DbContextOptionsBuilder<TContext>();

        Console.WriteLine(
            "DesignTimeDbContextFactory.Create(string): Connection string: {0}",
            connectionStringName);
        Console.WriteLine(migrationsAssembly);
        optionsBuilder.UseSqlServer(connectionString, db => db.MigrationsAssembly(migrationsAssembly));

        var options = optionsBuilder.Options;

        return CreateNewInstance(options);
    }
}