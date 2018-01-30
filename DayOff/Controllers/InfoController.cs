using DayOff.Services.Controls;
using System.Threading.Tasks;
using System.Web.Http;

namespace DayOff.Controllers
{
    [RoutePrefix("api/info")]
    public class InfoController : ApiController
    {
        const string REMOTE_GAMES_URI = "http://localhost:49500/api/game";

        public InfoController(IService service)
        {
            infoService = service;
        }

        private readonly IService infoService;

        [Route("remotegames")]
        public async Task<string> GetRemoteGames()
        {
            var result = await infoService.GetInfoFromRemoteService(REMOTE_GAMES_URI);
            return result; 
        }
    }
}
