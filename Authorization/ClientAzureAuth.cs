using Microsoft.IdentityModel.Clients.ActiveDirectory; 

namespace CDS.Authorization
{
    public class ClientAzureAuth
    {
        private string _serviceUrl;
        private string _clientId;
        private string _clientSecret;
        private string _tenatId;

        public ClientAzureAuth(string serviceUrl, string clientId, string clientSecret, string tenatId)
        {
            _serviceUrl = serviceUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _tenatId = tenatId;
        }

        public string GetAuthToken()
        {

            AuthenticationContext authContext = new AuthenticationContext($"https://login.microsoftonline.com/{_tenatId}");
            ClientCredential credential = new ClientCredential(_clientId, _clientSecret);

            AuthenticationResult result = authContext.AcquireTokenAsync(_serviceUrl, credential).Result;

            return result.AccessToken;
        }
    }
}
