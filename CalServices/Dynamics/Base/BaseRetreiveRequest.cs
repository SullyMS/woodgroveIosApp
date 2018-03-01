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
        public RelatedEntity[] RelatedEntities { get; set; }
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
                if (RelatedEntities != null)
                {
                    expand = "&$expand=";
                    for (int i = 0; i < RelatedEntities.Length; i++)
                    {
                        if (i == 0)
                        {
                            expand += RelatedEntities[i].ExpandString;
                        }
                        else
                        {
                            expand += $",{RelatedEntities[i].ExpandString}";
                        }
                    }
                }
                return expand;
            }
        }
        #endregion
    }
}
