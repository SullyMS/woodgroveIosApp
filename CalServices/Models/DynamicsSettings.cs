namespace CalServices.Models
{
    public class DynamicsSettings
    {
        public DynamicsSettings(string AppId, string Secret, string OAuthEndPoint, string ApiBaseUrl, string InstanceUrl)
        {
            this.AppId = AppId;
            this.Secret = Secret;
            this.OAuthEndPoint = OAuthEndPoint;
            this.ApiBaseUrl = ApiBaseUrl;
            this.InstanceUrl = InstanceUrl;
        }

        public string AppId { get; private set; }
        public string Secret { get; private set; }
        public string OAuthEndPoint { get; private set; }
        public string ApiBaseUrl { get; private set; }
        public string InstanceUrl { get; private set; }
    }
}
