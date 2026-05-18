namespace StoreSimulation
{
    public struct EntryRequest
    {
        public int customerId;
        public BlockingBuffer<bool> replyBuffer;
    }
}