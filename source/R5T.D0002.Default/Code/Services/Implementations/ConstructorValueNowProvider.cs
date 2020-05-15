using System;
using System.Threading.Tasks;


namespace R5T.D0002.Default
{
    public class ConstructorValueNowProvider : INowProvider
    {
        #region Static

        public static ConstructorValueNowProvider NewFromLocalNow(DateTime localNow)
        {
            var constantValueNowProvider = new ConstructorValueNowProvider(localNow);
            return constantValueNowProvider;
        }

        /// <summary>
        /// Uses the <see cref="ConstructorValueNowProvider.NewFromLocalNow(DateTime)"/> as the default.
        /// </summary>
        public static ConstructorValueNowProvider New(DateTime now)
        {
            var constantValueNowProvider = ConstructorValueNowProvider.NewFromLocalNow(now);
            return constantValueNowProvider;
        }

        public static ConstructorValueNowProvider NewFromUtcNow(DateTime utcNow)
        {
            var localNow = utcNow.ToLocalTime();

            var constantValueNowProvider = new ConstructorValueNowProvider(localNow);
            return constantValueNowProvider;
        }

        public static ConstructorValueNowProvider NewFromOffset(TimeSpan offset)
        {
            var offsetNow = DateTime.Now + offset;

            var constantValueNowProvider = ConstructorValueNowProvider.NewFromLocalNow(offsetNow);
            return constantValueNowProvider;
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
