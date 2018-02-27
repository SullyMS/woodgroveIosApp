using System;
namespace CalServices.Dynamics.Base
{
    interface IServiceErrorResponse
    {
        bool IsSuccessFull { get; set; }
        string ErrorMessage { get; set; }
    }
}
