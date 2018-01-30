using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DayOff.Controllers
{
    [RoutePrefix("api/info")]
    public class InfoController : ApiController
    {
        [Route("remotegames")]
        public string GetRemoteGames()
        {
            var request = WebRequest.Create("http://localhost:49500//api/game");
            request.Method = "GET";
            using (var response = request.GetResponse())
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
