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

            int res; 
            var request = new RestRequest("/customerid");
            request.Method = Method.GET;
            var response = cl.Execute(request);
            return Convert.ToInt32(response.Content);

        }

        internal void PlaceOrder(string ord)
        {
            var request = new RestRequest("/placeorder");
            request.Method = Method.POST;
            RequestBody rb = new RequestBody("json/text", "order", ord);
            request.Body = rb;
            var response = cl.Execute(request);
        }

        public  Client()
        {

            var config = new TestConfig();
            baseUrl = config.getBaseUrl();
        }

    }
}