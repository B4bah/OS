namespace StoreSimulation
{
    public interface IEntryGate
    {
        void RequestEntry(EntryRequest request);
        void Leave();
    }
}