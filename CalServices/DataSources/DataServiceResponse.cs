using System;
namespace CalServices.DataSources
{
    public class DataServiceResponse<T>
    {
        public DataServiceResponse()
        {
        }

        #region Properties
        public bool Success { get; set; }
        public T Data{ get; set; }
        #endregion
    }

    public enum ErrorType
    {
        None,
        NotFound,
        NoNetwork,
        UnExpected,
        InternalServerError,
        NotAuthorized,
        OtherHttp
    }

}
