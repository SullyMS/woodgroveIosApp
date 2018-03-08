namespace CalServices.Models
{
    public class DynamicsSettings
    {
        public DynamicsSettings() { }

        public string AppId { get; set; }
        public string Secret { get; set; }
        public string OAuthEndPoint { get; set; }
        public string ApiBaseUrl { get; set; }
        public string InstanceUrl { get; set; }
        public string CalServicesUrl { get; set; }
        public string EnvironmentName { get; set; }
    }
}
