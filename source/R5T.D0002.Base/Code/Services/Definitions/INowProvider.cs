using System;
using System.Threading.Tasks;


namespace R5T.D0002
{
    public interface INowProvider
    {
        Task<DateTime> GetNowAsync();
    }
}
