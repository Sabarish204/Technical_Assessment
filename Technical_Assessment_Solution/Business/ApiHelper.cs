using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Technical_Assessment_Solution.Models;
using Technical_Assessment_Solution.Utilities;

namespace Technical_Assessment_Solution.Business
{
    public class ApiHelper : IApiHelper
    {
        private readonly IOptions<Settings> _appSettings;
        public ApiHelper(IOptions<Settings> appSettings)
        {
            _appSettings = appSettings;
        }


        public async Task<AssessmentViewModel> GetJsonData()
        {

            string ApiUrl = _appSettings.Value.ApiUrl;

            string response = string.Empty;
            IDictionary<string, MathClass> apiResponse = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(ApiUrl);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                    apiResponse = JsonConvert.DeserializeObject<IDictionary<string, MathClass>>(response);
                }
            }


            AssessmentViewModel obj = new AssessmentViewModel();
            obj.Min = apiResponse.Min(r => r.Value.Math1);
            obj.Max = apiResponse.Max(r => r.Value.Math1);

            return obj;
        }
    }
}
