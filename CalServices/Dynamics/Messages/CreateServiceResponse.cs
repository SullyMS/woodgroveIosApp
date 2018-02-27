using System.Net.Http;
using CalServices.Dynamics.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalServices.Dynamics.Messages
{
    public class CreateServiceResponse : D365ServiceResponse
    {
        public CreateServiceResponse(ServiceResult Result, string InternalError) : base(Result, InternalError) { }
        public CreateServiceResponse(HttpResponseMessage Response, ServiceResult Result, string Json = "") :
            base(Response, Result, Json)
        { }

        public string Id
        {
            get
            {
                if (HttpResponse.Headers.Contains(ID_HDR))
                {
                    return ParseId(HttpResponse.Headers.GetValues(ID_HDR).First());
                }
                return string.Empty;
            }
        }

        private string ParseId(string Url)
        {
            Regex regex = new Regex(ID_PAT);
            var matches = regex.Matches(Url);
            return matches.Count > 0 ? matches[0].Value.Substring(1, matches[0].Value.Length - 2) : string.Empty;
        }

        private const string ID_PAT = @"\((.*?)\)";
        private const string ID_HDR = "OData-EntityId";
    }
}
