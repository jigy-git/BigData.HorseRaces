namespace BigData.HorseRaces.Interfaces;

public interface IEventPublisher
{
    public Task<object> PublishAsync(object eventData);
}
