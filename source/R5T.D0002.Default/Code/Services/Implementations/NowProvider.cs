using System;
using System.Threading.Tasks;


namespace R5T.D0002.Default
{
    public class NowProvider : INowProvider
    {
        public Task<DateTime> GetNowAsync()
        {
            var now = DateTime.Now;

            return Task.FromResult(now);
        }
    }
}
