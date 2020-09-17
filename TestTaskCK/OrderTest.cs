using System;
using TestTaskCK.Mock;
using Xunit;

namespace TestTaskCK
{
    public class OrderTest : IDisposable
    {

        public OrderTest()
        {
            var mock = new MockServer();
            mock.CreateMock();
        }

        [Fact]
        public void AddLineItem()
        {
            Aplication app = new Aplication();
            Customer cr = new Customer();
            TestData td = new TestData();
            var OL = new OrderLine();

            app.Login(cr);
            var order =  td.CreateOrder(12345, cr.CustomerId);
          
            OL.product_id = "Existing Product";
            OL.quantity = 1;
            OL.total_amount = 100;
            
            order.order_lines.Add(OL);
            var content = app.PlaceOrder(order);
            //CheckOrderHasLineItem(order);
        }

        [Fact]
        public void AddLineItemNotExistedProduct()
        {
            Aplication app = new Aplication();
            Customer cr = new Customer();
            TestData td = new TestData();
            var OL = new OrderLine();

            app.Login(cr);
            var order = td.CreateOrder(12345, cr.CustomerId);

            OL.product_id = "NotExistedProduct";
            OL.quantity = 1;
            OL.total_amount = 100;

            order.order_lines.Add(OL);
            var content = app.PlaceOrder(order);
            //CheckOrderHasLineItem(order);
        }

        [Fact]
        public void AddLineWithIncorectPrice()
        {
            Aplication app = new Aplication();
            Customer cr = new Customer();
            TestData td = new TestData();
            var OL = new OrderLine();

            app.Login(cr);
            var order = td.CreateOrder(12345, cr.CustomerId);

            OL.product_id = "Wrong Price";
            OL.quantity = 1;
            OL.total_amount = 1000;

            order.order_lines.Add(OL);
            var content = app.PlaceOrder(order);
            //CheckOrderHasLineItem(order);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
