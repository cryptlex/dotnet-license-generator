using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using System.Net.Mime;
using System.Collections.Generic;

using DotnetLicenseGenerator.Dtos;

namespace DotnetLicenseGenerator.Services
{

    public class LicenseService
    {
        private const string _apiUrl = "https://api.cryptlex.com/v3";
        private readonly string _accessToken;


        public LicenseService(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task<LicenseDto> CreateLicense(string postData)
        {
            var json = await PostAsync($"{_apiUrl}/licenses", postData);
            return JsonConvert.DeserializeObject<LicenseDto>(json);
        }

        public async Task<UserDto> CreateUser(string postData)
        {
            var json = await PostAsync($"{_apiUrl}/users", postData);
            return JsonConvert.DeserializeObject<UserDto>(json);
        }

        public async Task<LicenseDto> RenewLicense(string productId, string key)
        {
            // searching for existing license...
            var licenses = await GetListAsync($"{_apiUrl}/licenses?productId={productId}&key={key}");
            if (licenses.Count == 0)
            {
                throw new Exception("License does not exist!");
            }
            var license = licenses.FirstOrDefault();

            // "renewing existing license..."
            var json = await PostAsync($"{_apiUrl}/licenses/{license.Id}/renew", null);
            return JsonConvert.DeserializeObject<LicenseDto>(json);
        }

        public async Task<string> PostAsync(string url, string postData)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url)
            };
            if (!String.IsNullOrEmpty(postData))
            {
                request.Content = new StringContent(postData, Encoding.UTF8, MediaTypeNames.Application.Json);
            }
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken); ;
            var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<List<LicenseDto>> GetListAsync(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken); ;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LicenseDto>>(json);
        }

    }
}
