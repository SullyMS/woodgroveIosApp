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
        public abstract Task<bool> Load();

        #endregion

        #region Properties
        public ErrorType ErrorType { get; private set; }
        public string ErrorMessage { get; private set; }
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
                        Data = default(T)
                    };
                    ErrorType = ErrorType.OtherHttp;
                    ErrorMessage = json;
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        ErrorType = ErrorType.NotFound;
                    }
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        ErrorType = ErrorType.InternalServerError;
                    }
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                       httpResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        ErrorType = ErrorType.NotAuthorized;
                    }
                    OnLoadError();
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
                    ErrorType = ErrorType.None;
                    ErrorMessage = string.Empty;
                    Status = DataSourceStatus.Loaded;
                    OnLoadComplete();
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
                ErrorType = ErrorType.UnExpected;
                ErrorMessage = ex.Message;
                Status = DataSourceStatus.Error;
                OnLoadError();
                return response;
            }

        }
        #endregion

        #region Events
        public event EventHandler LoadComplete;
        public event EventHandler LoadError;

        protected void OnLoadComplete() => LoadComplete?.Invoke(this, EventArgs.Empty);
        protected void OnLoadError() => LoadError?.Invoke(this, EventArgs.Empty);
        #endregion
    }

    public enum DataSourceStatus{
        Default,
        Loading,
        Loaded,
        Error
    }
}
