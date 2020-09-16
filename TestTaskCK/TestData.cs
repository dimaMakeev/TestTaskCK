using System;
using System.Collections.Generic;

namespace TestTaskCK
{
    internal class TestData
    {
        public TestData()
        {
        }

        public Order CreateOrder(int orderId,  int customerId)
        {
            var order = new Order();
            order.Order_id = orderId;
            order.order_lines = new List<OrderLine>();
            return order;
        }
    }
}