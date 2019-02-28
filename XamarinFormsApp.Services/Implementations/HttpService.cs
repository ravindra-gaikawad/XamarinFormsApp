using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Core.Models;
using XamarinFormsApp.Services.Definitions;

namespace XamarinFormsApp.Services.Implementations
{
    public class HttpService : IHttpService
    {
        public HttpService()
        {

        }

        async Task<ResponseModel> IHttpService.Post<T>(string relativeUrl, T model)
        {
            using (HttpClient httpClient = GetHttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = await httpClient.PostAsync(relativeUrl, stringContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return new ResponseModel(isSuccess: true, message: string.Empty);
                }

                var errorMessage = await httpResponse.Content.ReadAsStringAsync();
                return new ResponseModel(isSuccess: false, message: errorMessage);
            }

        }

        async Task<string> IHttpService.Get(string relativeUrl)
        {
            string response = null;

            using (HttpClient httpClient = GetHttpClient())
            {
                HttpResponseMessage httpResponse = await httpClient.GetAsync(relativeUrl);

                if (httpResponse.IsSuccessStatusCode)
                {
                    response = await httpResponse.Content.ReadAsStringAsync();
                }
            }

            return response;

        }

        async Task<ResponseModel> IHttpService.Put<T>(string relativeUrl, T model)
        {
            using (HttpClient httpClient = GetHttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = await httpClient.PutAsync(relativeUrl, stringContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return new ResponseModel(isSuccess: true, message: string.Empty);
                }

                var errorMessage = await httpResponse.Content.ReadAsStringAsync();
                return new ResponseModel(isSuccess: false, message: errorMessage);
            }

        }

        async Task<ResponseModel> IHttpService.Delete(string relativeUrl)
        {
            using (HttpClient httpClient = GetHttpClient())
            {
                HttpResponseMessage httpResponse = await httpClient.DeleteAsync(relativeUrl);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return new ResponseModel(isSuccess: true, message: string.Empty);
                }

                var errorMessage = await httpResponse.Content.ReadAsStringAsync();
                return new ResponseModel(isSuccess: false, message: errorMessage);
            }
        }

        private HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();

            string accessToken = "";
            httpClient.BaseAddress = new Uri("");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            return httpClient;
        }

    }
}
