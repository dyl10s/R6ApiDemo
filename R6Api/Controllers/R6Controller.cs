using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace R6Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class R6Controller : ControllerBase
    {
        public Player GetByUsername(string Console, string Username)
        {
            WebClient c = new WebClient();
            var results = c.DownloadString("https://r6.tracker.network/profile/" + Console + "/" + Username);
            
            var curPlayer = new Player();
            curPlayer.Username = Username;
            var kdString = results.Split(new string[] { "<div class=\"trn-defstat__value\" data-stat=\"PVPKDRatio\">" }, StringSplitOptions.None)[1].Split("<")[0];

            curPlayer.Kd = Decimal.Parse(kdString);

            return curPlayer;
        }
    }
}
