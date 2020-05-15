using System;
using System.Threading.Tasks;


namespace R5T.D0002.Default
{
    public class ConstructorValueNowProvider : INowProvider
    {
        #region Static

        public static ConstructorValueNowProvider NewFromNowLocal(DateTime nowLocal)
        {
            var constantValueNowProvider = new ConstructorValueNowProvider(nowLocal);
            return constantValueNowProvider;
        }

        /// <summary>
        /// Uses the <see cref="ConstructorValueNowProvider.NewFromNowLocal(DateTime)"/> as the default.
        /// </summary>
        public static ConstructorValueNowProvider New(DateTime now)
        {
            var constantValueNowProvider = ConstructorValueNowProvider.NewFromNowLocal(now);
            return constantValueNowProvider;
        }

        public static ConstructorValueNowProvider NewFromNowUtc(DateTime nowUtc)
        {
            var nowLocal = nowUtc.ToLocalTime();

            var constantValueNowProvider = new ConstructorValueNowProvider(nowLocal);
            return constantValueNowProvider;
        }

        public static ConstructorValueNowProvider NewFromOffset(TimeSpan offset)
        {
            var offsetNow = DateTime.Now + offset;

            var constantValueNowProvider = ConstructorValueNowProvider.NewFromNowLocal(offsetNow);
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
