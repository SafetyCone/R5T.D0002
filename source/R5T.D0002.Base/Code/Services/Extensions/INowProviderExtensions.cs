using System;
using System.Threading.Tasks;


namespace R5T.D0002
{
    public static class INowProviderExtensions
    {
        public static async Task<DateTime> GetNowUtcAsync(this INowProvider nowProvider)
        {
            var now = await nowProvider.GetNowAsync();

            var nowUtc = now.ToUniversalTime();
            return nowUtc;
        }
    }
}
