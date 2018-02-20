using System;
using System.Net.Http;
using System.Threading.Tasks;
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

        #region AbstractMethods
        public abstract Task Load();

        #endregion

        #region Properties
        public DataSourceStatus Status
        {
            get => _status;
            private set { _status = value; }
        }
        #endregion

        #region Methods
        protected async Task<DataServiceResponse<T>> GetData<T>(string ServiceUrl){
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
                        ErrorType = ErrorType.OtherHttp,
                        ErrorMessage = json,
                        Data = default(T)
                    };
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
                        ErrorType = ErrorType.OtherHttp,
                        ErrorMessage = string.Empty,
                        Data = (T)Convert.ChangeType(data, typeof(T)) 
                    };
                    Status = DataSourceStatus.Loaded;
                    return response;
                }

            }catch(Exception ex)
            {
                DataServiceResponse<T> response = new DataServiceResponse<T>()
                {
                    Success = false,
                    ErrorType = ErrorType.UnExpected,
                    ErrorMessage = ex.Message,
                    Data = default(T)
                };
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
