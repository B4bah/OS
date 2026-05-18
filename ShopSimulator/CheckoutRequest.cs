namespace StoreSimulation
{
    public struct CheckoutRequest
    {
        public int customerId;
        public int payTimeMinutes;
        public BlockingBuffer<bool> replyBuffer;
    }
}