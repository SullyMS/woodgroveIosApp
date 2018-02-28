using System;
using CalServices.Dynamics.Messages;

namespace CalServices.Dynamics.Base
{
    public abstract class BaseRetreiveRequest
    {
        public BaseRetreiveRequest()
        {
        }

        #region Properties
        public string EntityName { get; set; }
        public RelatedEntity RelatedEntity { get; set; }
        public SelectFieldsList Fields { get; set; }
        public abstract string Operation { get; }

        protected string SelectString
        {
            get
            {
                string fields = string.Empty;
                if (Fields != null)
                {
                    return Fields.SelectString;
                }
                return fields;
            }
        }
        protected string RelatedString
        {
            get
            {
                string expand = string.Empty;
                if (RelatedEntity != null)
                {
                    expand += $"{RelatedEntity.Fields.SelectString})";
                }
                return expand;
            }
        }
        #endregion
    }
}
