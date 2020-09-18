using System;
using System.Collections.Generic;
using TestTaskCK.Mock;
using Xunit;

namespace TestTaskCK
{
    public class OrderTest : IDisposable
    {
        Application app; 
        Customer customer; 
        TestData testData;  
        OrderLine orderLine;
        MockServer mock;

        public OrderTest()
        {
          
            mock = new MockServer();
            mock.CreateMock();
            
            app = new Application();
            customer = new Customer();
            testData = new TestData();
            orderLine = new OrderLine();
        }

        [Fact]
        public void AddLineItem()
        {

            app.Login(customer);
            var order =  testData.CreateOrder(12345, customer.CustomerId);
          
            orderLine.product_id = "Existing Product";
            orderLine.quantity = 1;
            orderLine.total_amount = 100;
            orderLine.action = "add_line";


            order.order_lines.Add(orderLine);
            var result = app.PlaceOrder(order);
            Assert.Equal("success", result.result);
            //here will be check in DB
           
        }

        [Fact]
        public void AddLineItemNotExistedProduct()
        {
            app.Login(customer);
            var order = testData.CreateOrder(12345, customer.CustomerId);

            orderLine.product_id = "NotExistedProduct";
            orderLine.quantity = 1;
            orderLine.total_amount = 100;
            orderLine.action = "add_line";

            order.order_lines.Add(orderLine);
            var result = app.PlaceOrder(order);

            Assert.Equal("error", result.result);
             var error = result.errors[0];
            Assert.Equal("Invalid Product ID", error.message);

        }

        [Fact]
        public void AddLineWithIncorectPrice()
        {
        
            app.Login(customer);
            var order = testData.CreateOrder(12345, customer.CustomerId);
            orderLine.product_id = "Wrong Price";
            orderLine.quantity = 1;
            orderLine.total_amount = 1000;
            orderLine.action = "add_line";
            order.order_lines.Add(orderLine);

            var result = app.PlaceOrder(order);

            Assert.Equal("error", result.result);
            var error = result.errors[0];
            Assert.Equal("Incorrect Price", error.message);

        }

        [Fact]
        public void AddLineWithMismatchPrice()
        {

            app.Login(customer);
            var order = testData.CreateOrder(12345, customer.CustomerId);
            orderLine.product_id = "Mismatch Price";
            orderLine.quantity = 1;
            orderLine.total_amount = 1000;
            orderLine.action = "add_line";
            order.order_lines.Add(orderLine);

            var result = app.PlaceOrder(order);

            Assert.Equal("error", result.result);
            var error = result.errors[0];
            Assert.Equal("Incorrect Price", error.message);

        }


        [Fact]
        public void RemoveLineItem()
        {
 
            app.Login(customer);
            var order = testData.CreateOrder(12345, customer.CustomerId);
            orderLine.product_id = "Remove Line";
            orderLine.quantity = 1;
            orderLine.total_amount = 1000;
            orderLine.action = "remove_line";
            order.order_lines.Add(orderLine);

            var result = app.PlaceOrder(order);

            Assert.Equal("success", result.result);
            //here will be check in DB
        }

        [Fact]
        public void InvalidAction()
        {

            app.Login(customer);
            var order = testData.CreateOrder(12345, customer.CustomerId);
            orderLine.product_id = "Invalid Action";
            orderLine.quantity = 1;
            orderLine.total_amount = 200;
            orderLine.action = "upgrate_line";
            order.order_lines.Add(orderLine);

            var result = app.PlaceOrder(order);

            Assert.Equal("error", result.result);
            var error = result.errors[0];
            Assert.Equal("Invalid Action", error.message);
        }


        public void Dispose()
        {
            mock.DeleteMock();
        }


    }
}
