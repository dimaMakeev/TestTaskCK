namespace TestTaskCK
{
    public interface IOrderLinesBuilder
    {
        void AddProduct_id();
        void AddQuantity();

        void AddTotalAmount();

        void AddAction();

        OrderLine GetOrderLine();

    }
}