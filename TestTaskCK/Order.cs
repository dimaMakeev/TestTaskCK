using System.Collections.Generic;

namespace TestTaskCK
{
    public class Order {
        public int Customer_id { get; set; }
        public int Order_id { get; set; }

        public List<OrderLine> order_lines { get; set; }

    }
}