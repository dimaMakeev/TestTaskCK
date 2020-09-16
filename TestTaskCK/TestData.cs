using System;

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
            return order;
        }
    }
}