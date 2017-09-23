using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Desafio.Controllers
{
    public class CustomController : Controller
    {
        public TransactionReturn Gateway(string key, Transaction obj, string url)
        {
            try
            {
                UTF8Encoding enc = new UTF8Encoding();

                var jsonObj = JsonConvert.SerializeObject(obj);
                var contentData = new StringContent(jsonObj, System.Text.Encoding.UTF8, "application/json");

                HttpClient request = new HttpClient();
                request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.DefaultRequestHeaders.Add("MerchantKey", key);

                HttpResponseMessage response = request.PostAsync(url, contentData).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;

                TransactionReturn retorno = JsonConvert.DeserializeObject<TransactionReturn>(stringData);
                return retorno;
            }
            catch (Exception)
            {
                return new TransactionReturn();
            }
        }
    }
}
