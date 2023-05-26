using System.Net.Http;

namespace ClubView.APIConfiguration
{
    public class GetAPIBaseUrl
    {
        private readonly IConfiguration _configuration;

        public GetAPIBaseUrl(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetBaseUrl()
        {
            return _configuration["AppSettings:BaseUrl"];
        }
    }
}
