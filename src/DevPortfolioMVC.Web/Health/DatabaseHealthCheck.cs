using DevPortfolioMVC.Web.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DevPortfolioMVC.Web.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DatabaseHealthCheck(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await using var scope = _scopeFactory.CreateAsyncScope();
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<ApplicationDbContext>();

                var canConnect = await dbContext.Database
                    .CanConnectAsync(cancellationToken);

                return canConnect
                    ? HealthCheckResult.Healthy("PostgreSQL disponible.")
                    : HealthCheckResult.Unhealthy(
                        "No fue posible conectar con PostgreSQL.");
            }
            catch (Exception exception)
            {
                return HealthCheckResult.Unhealthy(
                    "La comprobación de PostgreSQL produjo un error.",
                    exception);
            }
        }
    }
}
