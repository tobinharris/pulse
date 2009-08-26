namespace Pulse.Domain
{
    public interface ISimpleQueue
    {
        void AddToQueue(string json);
    }
}