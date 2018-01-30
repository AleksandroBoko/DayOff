using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DayOff.Services
{
    public class InfoService
    {
        public async Task<string> GetInfoFromRemoteService(string uri)
        {
            var request = WebRequest.Create(uri);
            request.Method = "GET";
            using (var response = await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var result = streamReader.ReadToEnd();
                        response.Close();
                        return result;
                    }
                }
            }
        }
    }
}
