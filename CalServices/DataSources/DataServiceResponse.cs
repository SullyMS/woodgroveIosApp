using System;
namespace CalServices.DataSources
{
    public class DataServiceResponse<T>
    {
        public DataServiceResponse()
        {
        }

        #region Properties
        public ErrorType ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public T Data{ get; set; }
        #endregion
    }

    public enum ErrorType
    {
        NotFound,
        NoNetwork,
        UnExpected,
        InternalServerError,
        NotAuthorized,
        OtherHttp
    }

}
