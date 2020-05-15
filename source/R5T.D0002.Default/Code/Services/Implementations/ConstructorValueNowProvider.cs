using System;
using System.Threading.Tasks;


namespace R5T.D0002.Default
{
    public class ConstructorValueNowProvider : INowProvider
    {
        #region Static

        public static ConstructorValueNowProvider NewFromLocalNow(DateTime localNow)
        {
            var constantValueUtcNowProvider = new ConstructorValueNowProvider(localNow);
            return constantValueUtcNowProvider;
        }

        /// <summary>
        /// Uses the <see cref="ConstructorValueNowProvider.NewFromLocalNow(DateTime)"/> as the default.
        /// </summary>
        public static ConstructorValueNowProvider New(DateTime now)
        {
            var constantValueUtcNowProvider = ConstructorValueNowProvider.NewFromLocalNow(now);
            return constantValueUtcNowProvider;
        }

        public static ConstructorValueNowProvider NewFromUtcNow(DateTime utcNow)
        {
            var localNow = utcNow.ToLocalTime();

            var constantValueUtcNowProvider = new ConstructorValueNowProvider(localNow);
            return constantValueUtcNowProvider;
        }

        public static ConstructorValueNowProvider NewFromOffset(TimeSpan offset)
        {
            var offsetNow = DateTime.Now + offset;

            var constantValueUtcNowProvider = ConstructorValueNowProvider.NewFromLocalNow(offsetNow);
            return constantValueUtcNowProvider;
        }

        #endregion


        private DateTime Now { get; }


        public ConstructorValueNowProvider(DateTime now)
        {
            this.Now = now;
        }

        public Task<DateTime> GetNowAsync()
        {
            return Task.FromResult(this.Now);
        }
    }
}
