using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Configuration;
namespace TestTaskCK
{
     class Client
    {
        private static string baseUrl { get; set; }
        private RestClient cl { get; set; }

        public void LoginAsCustomer(string login, string pass)
        {
            cl = new RestClient(baseUrl);
            cl.Authenticator = new HttpBasicAuthenticator(login, pass);
        }

        public int GetCustomerId()
        {
            
            var request = new RestRequest("/customerid");
            request.Method = Method.GET;
            var responce = cl.Execute(request);
            return 10;

        }

        internal void PlaceOrder(string ord)
        {
            var request = new RestRequest("/placeorder");
            request.Method = Method.POST;
            RequestBody rb = new RequestBody("json/text", "order", ord);
            request.Body = rb;
            var responce = cl.Execute(request);
        }

        public  Client()
        {
            baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");
        }

    }
}