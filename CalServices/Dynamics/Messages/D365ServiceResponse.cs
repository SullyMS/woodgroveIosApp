using System;
using System.Net.Http;
using CalServices.Dynamics.Base;
using Newtonsoft.Json;

namespace CalServices.Dynamics.Messages
{
    public class D365ServiceResponse
    {
        #region members
        private HttpResponseMessage _httpResponse = null;
        private string _json = string.Empty;
        private ServiceResult _result;
        private string _error = string.Empty;
        #endregion

        #region Constructor
        public D365ServiceResponse(HttpResponseMessage Response, ServiceResult Result, string Json = "")
        {
            _httpResponse = Response;
            _json = Json;
            _result = Result;
        }
        public D365ServiceResponse(ServiceResult Result, string InternalError)
        {
            _result = Result;
            _error = InternalError;
        }
        #endregion

        #region Properties
        public bool Success => (Result == ServiceResult.Success);

        public string ErrorMessage
        {
            get
            {
                if (Result == ServiceResult.WebRequestError)
                {
                    return Json;
                }
                else if (Result == ServiceResult.InternalError)
                {
                    return _error;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public HttpResponseMessage HttpResponse => _httpResponse;
        public ServiceResult Result => _result;
        public string Json => _json;
        #endregion

        #region Methods
        public T GetData<T>()
        {
            if (!string.IsNullOrEmpty(Json))
            {
                try
                {
                    DynamicsPayload payload = JsonConvert.DeserializeObject<DynamicsPayload>(Json);
                    T data = default(T);
                    if (payload.Value == null)
                    {
                        data = JsonConvert.DeserializeObject<T>(Json);
                        return (T)Convert.ChangeType(data, typeof(T));
                    }
                    else
                    {
                        return payload.Value.ToObject<T>();
                    }
                }
                catch (Exception ex)
                {
                    IServiceErrorResponse response = (IServiceErrorResponse)Activator.CreateInstance(typeof(T));
                    response.IsSuccessFull = false;
                    response.ErrorMessage = ex.Message;
#if DEBUG
                    System.Diagnostics.Debug.WriteLine($"D365ServiceResponse.GetData() - Parsing Error: {ex.Message}");
#endif
                    return (T)response;
                }
            }
            return default(T);
        }
        #endregion
    }

    public enum ServiceResult
    {
        Success = 0,
        WebRequestError = 1,
        InternalError = 2
    }
}
