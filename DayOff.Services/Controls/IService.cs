using System.Threading.Tasks;

namespace DayOff.Services.Controls
{
    public interface IService
    {
        Task<string> GetInfoFromRemoteService(string uri);
    }
}
