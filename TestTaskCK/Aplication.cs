using Newtonsoft.Json;
using System;


namespace TestTaskCK
{
    internal class Aplication
    {

        Client client { get; set; }

        public Aplication()
        {
            client = new Client();
        }

        public void Login(Customer cr)
        {
            client.LoginAsCustomer(cr.Login, cr.Pass);
            cr.CustomerId = client.GetCustomerId(); 
        }

        public void PlaceOrder(Order order)
        {
            string ord = JsonConvert.SerializeObject(order, Formatting.Indented);
            client.PlaceOrder(ord);  
        }
    }
}