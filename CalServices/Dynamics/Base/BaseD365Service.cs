using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CalServices.Utils;
using CalServices.Dynamics.Models;

namespace CalServices.Dynamics.Base
{
    public abstract class BaseD365Service
    {
        #region Constructor
        public BaseD365Service() { }
        #endregion

        #region Methods
        protected async Task<D365ServiceResponse> SendGetRequestAsync(string Operation, string Parameters = "")
        {
            HttpResponseMessage apiResponse = null;
            D365ServiceResponse response = null;

            try
            {
                string token = await KeyVault.Tokens.GetD365ServiceToken();

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(KeyVault.Tokens.DynamicsSettings.ApiBaseUrl);
                    httpClient.Timeout = new TimeSpan(0, 2, 0);
                    httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                    httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);
                    httpClient.DefaultRequestHeaders.Add("Prefer", "odata.include-annotations=\"OData.Community.Display.V1.FormattedValue\"");
                    using (apiResponse = await httpClient.GetAsync(Operation))
                    {
                        if (apiResponse.IsSuccessStatusCode)
                        {
                            string json = await apiResponse.Content.ReadAsStringAsync();
                            response = new D365ServiceResponse(apiResponse, ServiceResult.Success, json);
                        }
                        else
                        {
                            string responseText = await apiResponse.Content.ReadAsStringAsync();
                            response = new D365ServiceResponse(apiResponse, ServiceResult.WebRequestError, responseText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"BaseD365Service.SendGetRequest() Error: {ex.Message}";
                response = new D365ServiceResponse(ServiceResult.InternalError, errorMessage);
            }
            return response;
        }
        protected async Task<D365ServiceResponse> D365CreateAsync(BaseEntity Entity)
        {
            try
            {
                string token = await KeyVault.Tokens.GetD365ServiceToken();

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(KeyVault.Tokens.DynamicsSettings.ApiBaseUrl);
                    httpClient.Timeout = new TimeSpan(0, 2, 0);
                    httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                    httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);
                    httpClient.DefaultRequestHeaders.Add("Prefer", "odata.include-annotations=\"OData.Community.Display.V1.FormattedValue\"");
                    string json = JsonConvert.SerializeObject(Entity);
#if DEBUG
                    System.Diagnostics.Debug.WriteLine($"BaseD365Service.CreateAsync Json: {json}");
#endif
                    StringContent content = new StringContent(json);
                    content.Headers.ContentType.MediaType = "application/json";
                    content.Headers.ContentLength = json.Length;
                    using (HttpResponseMessage response = await httpClient.PostAsync($"{KeyVault.Tokens.DynamicsSettings.ApiBaseUrl}{Entity.EntityName}", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            //deserialize create response
                            return new D365ServiceResponse(response, ServiceResult.Success, responseData);
                        }
                        else
                        {
                            //error
#if DEBUG
                            System.Diagnostics.Debug.WriteLine($"BaseD365Service.CreateAsync: {responseData}");
#endif
                            return new D365ServiceResponse(response, ServiceResult.WebRequestError, responseData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new D365ServiceResponse(ServiceResult.InternalError, ex.Message);
            }
        }
        private string FormatUrl(string Url)
        {
            if (Url.Substring(Url.Length - 1, 1).Equals(@"/"))
            {
                return Url;
            }
            return $"{Url}/";
        }
        #endregion

        #region Properties
        protected string BaseServiceUrl
        {
            get => FormatUrl(KeyVault.Tokens.DynamicsSettings.ApiBaseUrl);
        }
        #endregion
    }
}
