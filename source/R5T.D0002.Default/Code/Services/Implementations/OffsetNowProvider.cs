using System;
using System.Threading.Tasks;


namespace R5T.D0002.Default
{
    public class OffsetNowProvider : INowProvider
    {
        #region Static

        public static OffsetNowProvider NewFromOffset(TimeSpan offset)
        {
            var offsetUtcNowProvider = new OffsetNowProvider(offset);
            return offsetUtcNowProvider;
        }

        public static OffsetNowProvider New(TimeSpan offset)
        {
            var offsetUtcNowProvider = OffsetNowProvider.NewFromOffset(offset);
            return offsetUtcNowProvider;
        }

        public static OffsetNowProvider NewFromDesiredUtcNow(DateTime desiredUtcNow)
        {
            var offset = DateTime.UtcNow - desiredUtcNow;

            var offsetUtcNowProvider = OffsetNowProvider.NewFromOffset(offset);
            return offsetUtcNowProvider;
        }

        public static OffsetNowProvider NewFromDesiredLocalNow(DateTime desiredLocalNow)
        {
            var offset = DateTime.Now - desiredLocalNow;

            var offsetUtcNowProvider = OffsetNowProvider.NewFromOffset(offset);
            return offsetUtcNowProvider;
        }

        #endregion


        private TimeSpan Offset { get; }


        public OffsetNowProvider(TimeSpan offset)
        {
            this.Offset = offset;
        }

        public Task<DateTime> GetNowAsync()
        {
            var now = DateTime.Now;

            var offsetNow = now + this.Offset;
            return Task.FromResult(offsetNow);
        }
    }
}
