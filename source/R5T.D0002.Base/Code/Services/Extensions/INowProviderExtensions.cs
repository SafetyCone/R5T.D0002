using System;
using System.Threading.Tasks;


namespace R5T.D0002
{
    public static class INowProviderExtensions
    {
        public static async Task<DateTime> GetUtcNowAsync(this INowProvider nowProvider)
        {
            var now = await nowProvider.GetNowAsync();

            var utcNow = now.ToUniversalTime();
            return utcNow;
        }
    }
}
