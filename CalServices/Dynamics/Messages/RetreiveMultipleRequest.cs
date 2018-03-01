using System;
using CalServices.Dynamics.Base;

namespace CalServices.Dynamics.Messages
{
    public class RetreiveMultipleRequest : BaseRetreiveRequest
    {
        public RetreiveMultipleRequest()
        {
        }

        #region Overrides
        public QueryFilter Filter { get; set; }
        public override string Operation
        {
            get
            {
                return $"{EntityName.ToLower()}s?{SelectString}{Filter.QueryString}{RelatedString}";
            }
        }
        #endregion
    }

}
