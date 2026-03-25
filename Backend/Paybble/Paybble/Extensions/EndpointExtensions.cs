using Paybble.Endpoints.Contracts;

namespace Paybble.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = typeof(Program).Assembly
                .GetTypes()
                .Where(t =>
                    typeof(IEndpoint).IsAssignableFrom(t) &&
                    !t.IsInterface &&
                    !t.IsAbstract);

            foreach (var endpoint in endpoints)
            {
                var instance = (IEndpoint)ActivatorUtilities.CreateInstance(app.Services, endpoint);
                instance.Map(app);
            }
        }
    }
}
