using System;
using System.Threading.Tasks;using R5T.T0064;


namespace R5T.D0002.Default
{[ServiceImplementationMarker]
    public class NowProvider : INowProvider,IServiceImplementation
    {
        public Task<DateTime> GetNowAsync()
        {
            var now = DateTime.Now;

            return Task.FromResult(now);
        }
    }
}
