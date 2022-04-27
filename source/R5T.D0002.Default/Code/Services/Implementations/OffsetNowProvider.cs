using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0002.Default
{
    [ServiceImplementationMarker]
    public class OffsetNowProvider : INowProvider, IServiceImplementation
    {
        #region Static

        public static OffsetNowProvider NewFromOffset(TimeSpan offset)
        {
            var offsetNowProvider = new OffsetNowProvider(offset);
            return offsetNowProvider;
        }

        public static OffsetNowProvider New(TimeSpan offset)
        {
            var offsetNowProvider = OffsetNowProvider.NewFromOffset(offset);
            return offsetNowProvider;
        }

        public static OffsetNowProvider NewFromDesiredNowUtc(DateTime desiredNowUtc)
        {
            var offset = DateTime.UtcNow - desiredNowUtc;

            var offsetNowProvider = OffsetNowProvider.NewFromOffset(offset);
            return offsetNowProvider;
        }

        public static OffsetNowProvider NewFromDesiredNowLocal(DateTime desiredNowLocal)
        {
            var offset = DateTime.Now - desiredNowLocal;

            var offsetNowProvider = OffsetNowProvider.NewFromOffset(offset);
            return offsetNowProvider;
        }

        #endregion


        private TimeSpan Offset { get; }


        public OffsetNowProvider(
            [NotServiceComponent] TimeSpan offset)
        {
            this.Offset = offset;
        }

        public Task<DateTime> GetNowAsync()
        {
            var now = DateTime.Now;

            var nowOffset = now + this.Offset;
            return Task.FromResult(nowOffset);
        }
    }
}
