using Newtonsoft.Json;
using System;


namespace TestTaskCK
{
    internal class Application
    {

        Client client { get; set; }

        public Application()
        {
            client = new Client();
        }

        public void Login(Customer cr)
        {
            client.LoginAsCustomer(cr.Login, cr.Pass);
            cr.CustomerId = client.GetCustomerId(); 
        }

        public Responce PlaceOrder(Order order)
        {
            string ord = JsonConvert.SerializeObject(order, Formatting.Indented);
            Responce resp = JsonConvert.DeserializeObject<Responce>(client.PlaceOrder(ord));
            return resp;  
        }
    }
}