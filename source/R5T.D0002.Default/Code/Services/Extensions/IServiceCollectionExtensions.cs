using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.D0002.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="NowProvider"/> implementation of <see cref="INowProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDefaultNowProvider(this IServiceCollection services)
        {
            services.AddSingleton<INowProvider, NowProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="NowProvider"/> implementation of <see cref="INowProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<INowProvider> AddDefaultNowProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction<INowProvider>.New(() => services.AddDefaultNowProvider());
            return serviceAction;
        }
    }
}
