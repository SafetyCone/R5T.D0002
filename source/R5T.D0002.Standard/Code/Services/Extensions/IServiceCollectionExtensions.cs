using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0002.Default;


namespace R5T.D0002.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="INowProvider"/> service.
        /// </summary>
        public static IServiceCollection AddNowProvider(this IServiceCollection services)
        {
            services.AddDefaultNowProvider();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="INowProvider"/> service.
        /// </summary>
        public static ServiceAction<INowProvider> AddNowProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction<INowProvider>.New(() => services.AddNowProvider());
            return serviceAction;
        }
    }
}
