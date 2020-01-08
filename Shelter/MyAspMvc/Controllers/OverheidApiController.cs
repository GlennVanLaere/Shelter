using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MyAspMvc.Controllers
{
    public class OverheidApiController : Controller
    {
        [HttpGet("api/confirmAddress")]
        public string GetAdress(string Straatnaam, string Huisnummer, string Gemeentenaam)
        {
            string httpCall = "https://basisregisters.vlaanderen.be/api/v1.0/adressen?Straatnaam=" + Straatnaam + "&Huisnummer=" + Huisnummer + "&Gemeentenaam=" + Gemeentenaam;
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(httpCall);
            HttpWebResponse webResp = (HttpWebResponse)webReq.GetResponse();
            StreamReader loResponseStream = new StreamReader(webResp.GetResponseStream());
            var str = loResponseStream.ReadToEnd();
            JObject o = JObject.Parse(str);
            JArray address = (JArray)o["adressen"];
            loResponseStream.Close();
            webResp.Close();

            return address.ToString();
        }

    }
}



