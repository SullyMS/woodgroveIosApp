
namespace CalServices.Dynamics.Messages
{
    public class RelatedEntity
    {
        public string IdField { get; set; }
        public SelectFieldsList Fields { get; set; }
        public string ExpandString
        {
            get
            {
                string expand = $"{IdField}";
                if (Fields != null)
                {
                    expand += $"({Fields.SelectString})";
                }
                return expand;
            }
        }
    }
}
