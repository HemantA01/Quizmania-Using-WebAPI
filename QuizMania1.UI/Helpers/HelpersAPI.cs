using System.Net.Security;

namespace QuizMania1.UI.Helpers
{
    public class HelpersAPI
    {
        HttpClientHandler httpclienthandler = new();
        public HelpersAPI()
        {
            httpclienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chains, sslpolicyerrors) => { return true; };
        }
        public HttpClient Initial()
        {
            var client = new HttpClient(httpclienthandler);
            client.BaseAddress = new Uri("https://localhost:7125/");   //pass the address of API (QuizMania1.UI > Properties > Debug > App Url)
            return client;
        }
    }
}
