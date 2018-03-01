using System;
using CalServices.Dynamics.Base;

namespace CalServices.Dynamics.Messages
{
    public class RetreiveRequest : BaseRetreiveRequest
    {
        public RetreiveRequest()
        {
        }

        #region Properties
        public string KeyFieldName { get; set; }
        public bool IsAlternateKey { get; set; }
        public string IdValue { get; set; }
        #endregion

        #region Overrides
        public override string Operation
        {
            get
            {
                string operation = string.Empty;
                //add primary key filter
                if (IsAlternateKey)
                {
                    operation = $"{EntityName.ToLower()}s({KeyFieldName}='{IdValue}')";
                }
                else
                {
                    operation = $"{EntityName.ToLower()}s({IdValue})";
                }
                //add select
                operation += $"?{SelectString}";
                // add any related entities
                operation += RelatedString;

                return operation;
            }
        }
        #endregion
    }
}
