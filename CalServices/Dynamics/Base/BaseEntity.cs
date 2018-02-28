using Newtonsoft.Json;

namespace CalServices.Dynamics.Base
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
