﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CalServices.Utils;
using Newtonsoft.Json;

namespace CalServices.DataSources
{
    public abstract class BaseDataSource
    {
        #region Members
        private DataSourceStatus _status = DataSourceStatus.Default;
        #endregion


        public BaseDataSource()
        {
        }

        #region Properties
        //public ErrorType ErrorType { get; private set; }
        //public string ErrorMessage { get; private set; }
        public DataSourceStatus Status
        {
            get => _status;
            private set { _status = value; }
        }
        #endregion

        #region Methods
        protected async Task<DataServiceResponse<T>> GetData<T>(string ServiceUrl)
        {
            //send a get method to the end point
            Status = DataSourceStatus.Loading;
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, ServiceUrl);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage httpResponse = await client.SendAsync(request);
                string json = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode == false)
                {
                    //set to loaded because the service has responded
                    Status = DataSourceStatus.Loaded;
                    DataServiceResponse<T> response = new DataServiceResponse<T>()
                    {
                        Success = false,
                        Data = default(T),
                        ErrorMessage = json,
                        RequestUrl = ServiceUrl
                    };
                    response.ErrorType = ErrorType.OtherHttp;
                    //ErrorMessage = json;
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        response.ErrorType = ErrorType.NotFound;
                    }
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        response.ErrorType = ErrorType.InternalServerError;
                    }
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                       httpResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        response.ErrorType = ErrorType.NotAuthorized;
                    }

                    return response;
                }
                else
                {
                    //deserialize
                    T data = JsonConvert.DeserializeObject<T>(json);
                    DataServiceResponse<T> response = new DataServiceResponse<T>()
                    {
                        Success = true,
                        Data = (T)Convert.ChangeType(data, typeof(T)),
                        ErrorType = ErrorType.None,
                        ErrorMessage = string.Empty,
                        RequestUrl = ServiceUrl
                    };
                    Status = DataSourceStatus.Loaded;

                    return response;
                }

            }
            catch (Exception ex)
            {
                DataServiceResponse<T> response = new DataServiceResponse<T>()
                {
                    Success = false,
                    Data = default(T)
                };
                response.ErrorType = ErrorType.UnExpected;
                response.ErrorMessage = ex.Message;
                Status = DataSourceStatus.Error;

                return response;
            }

        }

        protected async Task<DataServiceResponse<T>> PutData<T>(string ServiceUrl, string JsonData)
        {
            //send a get method to the end point
            Status = DataSourceStatus.Loading;
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, ServiceUrl);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(JsonData, System.Text.Encoding.UTF8, "application/json");
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Request: {JsonData}");
#endif

                HttpResponseMessage httpResponse = await client.SendAsync(request);
                string json = await httpResponse.Content.ReadAsStringAsync();

#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Response: {json}");
#endif

                if (httpResponse.IsSuccessStatusCode == false)
                {
                    //set to loaded because the service has responded
                    Status = DataSourceStatus.Loaded;
                    DataServiceResponse<T> response = new DataServiceResponse<T>()
                    {
                        Success = false,
                        Data = default(T),
                        ErrorMessage = json
                    };
                    response.ErrorType = ErrorType.OtherHttp;
                    //ErrorMessage = json;
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        response.ErrorType = ErrorType.NotFound;
                    }
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        response.ErrorType = ErrorType.InternalServerError;
                    }
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                       httpResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        response.ErrorType = ErrorType.NotAuthorized;
                    }

                    return response;
                }
                else
                {
                    //deserialize
                    T data = JsonConvert.DeserializeObject<T>(json);
                    DataServiceResponse<T> response = new DataServiceResponse<T>()
                    {
                        Success = true,
                        Data = (T)Convert.ChangeType(data, typeof(T))
                    };
                    response.ErrorType = ErrorType.None;
                    response.ErrorMessage = string.Empty;
                    Status = DataSourceStatus.Loaded;

                    return response;
                }

            }
            catch (Exception ex)
            {
                DataServiceResponse<T> response = new DataServiceResponse<T>()
                {
                    Success = false,
                    Data = default(T)
                };
                response.ErrorType = ErrorType.UnExpected;
                response.ErrorMessage = ex.Message;
                Status = DataSourceStatus.Error;

                return response;
            }

        }
        #endregion


    }

    public enum DataSourceStatus{
        Default,
        Loading,
        Loaded,
        Error
    }
}
