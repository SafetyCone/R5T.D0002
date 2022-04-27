using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0002
{
    [ServiceDefinitionMarker]
    public interface INowProvider : IServiceDefinition
    {
        Task<DateTime> GetNowAsync();
    }
}
