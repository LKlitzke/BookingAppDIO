namespace BookingAppDio.Core.Models
{
    public interface IAggregate<out T> : IAggregate
    {
        T Id { get; }
    }

    public interface IAggregate
    {
    }
}
