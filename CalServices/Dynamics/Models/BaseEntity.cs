using Newtonsoft.Json;

namespace CalServices.Dynamics.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity(string EntityName)
        {
            this.EntityName = EntityName;
        }

        [JsonIgnore]
        public string EntityName { get; private set; }

    }
}
