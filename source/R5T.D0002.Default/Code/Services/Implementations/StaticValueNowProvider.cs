using System;
using System.Threading.Tasks;using R5T.T0064;


namespace R5T.D0002.Default
{[ServiceImplementationMarker]
    public class StaticValueNowProvider : INowProvider,IServiceImplementation
    {
        /// <summary>
        /// Note: not thread-safe.
        /// </summary>
        public static DateTime Now { get; }


        public Task<DateTime> GetNowAsync()
        {
            return Task.FromResult(StaticValueNowProvider.Now);
        }
    }
}
