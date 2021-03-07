namespace Test.NET_Core_Console_.Model
{
    public class Credentials
    {
        public readonly string _userName;
        public readonly string _password;
        public readonly string _url;
        public readonly string _authType;
        //
        public Credentials(string authType, string url, string userName, string passwrod)
        {
            _authType = authType;
            _url = url;
            _userName = userName;
            _password = passwrod;
        }
        public string GetConnectionString() => $"AuthType = {_authType}; Url = {_url};Username={_userName};Password={_password}";
    }
}
