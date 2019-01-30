using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Volte.Core.Files.Objects;

namespace Volte.Core.Services {
    public class DebugService {
        
        public string Execute(string config) {
            var files = new Dictionary<string, Dictionary<string, string>> {
                {
                    "1-Info.txt", new Dictionary<string, string> {
                        {
                            "content",
                            "Thanks to Scarsz lol#4227 on Discord for this tool. Without it, we wouldn't be able to do this!\n\nCheck out his stuff here:\nWebsite: https://scarsz.me\nGitHub: https://github.com/Scarsz\nDiscord: https://discord.gg/WdFa6gc\nTwitter: https://twitter.com/ScarszRawr\n\nSupport Server: https://discord.gg/prR9Yjq\nWebsite: https://greem.xyz\nSource Code: https://github.com/Greeem/SIVA"
                        }, {
                            "description", "Thanks Scarsz for this amazing utility!"
                        }
                    }
                }, {
                    "2-Server.conf", new Dictionary<string, string> {
                        {
                            "content", config
                        }, {
                            "description", "Server config for debug purposes."
                        }
                    }
                }
            };

            var payload = new {
                description = "Discord server settings for support.", files
            };

            var httpClient = new RestClient("https://debug.scarsz.me") {UserAgent = "SIVA/V2"};
            var req = new RestRequest("post", Method.POST);
            req.AddHeader("Content-Type", "application/json");
            req.RequestFormat = DataFormat.Json;
            req.Parameters.Clear();
            req.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            return ((JObject) JsonConvert
                    .DeserializeObject(httpClient.Execute(req).Content))
                .GetValue("url").ToString();
        }
    }
}