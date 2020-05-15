using System;
using System.Threading.Tasks;


namespace R5T.D0002.Default
{
    public class StaticValueNowProvider : INowProvider
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
