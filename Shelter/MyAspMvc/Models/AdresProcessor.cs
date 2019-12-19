using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyAspMvc.Models{

    public class AdresProcessor
    {
        public static async Task<AdresModel> LoadAdres(){
            
            string url = "https://basisregisters.vlaanderen.be/api/v1.0/adresmatch?Postcode=9090&Straatnaam=Platanendreef&Huisnummer=9";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    AdresResultModel result = await response.Content.ReadAsAsync<AdresResultModel>();

                    return result.Results;
                }
                else{
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}