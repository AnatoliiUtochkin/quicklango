using Newtonsoft.Json;
using QuickLingo.Dto;
using System.Net;
using System.Net.Http;
using System.Printing;
using System.Text;

namespace QuickLingo.Services
{
    public class TranslatorService
    {
        private string _route = "/translate?api-version=3.0&to=uk";

        public async Task<string> TranslateAsync(string textToTranslate)
        {
            object[] body = {new {Text = textToTranslate}};
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(TranslatorConfig.TranslatorEndpoint + _route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", TranslatorConfig.TranslatorKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", TranslatorConfig.TranslatorRegion);

                HttpResponseMessage response = await client.SendAsync(request);
                string jsonString = await response.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<TranslationResult[]>(jsonString);

                return results[0].Translations[0].Text;
            }
        }
    }
}
