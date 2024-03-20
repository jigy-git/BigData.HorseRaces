

namespace BigData.HorseRaces.ViewModels;

public class DataRecievedEvent(string dataSourceName, Guid dataId)
{
    public string EventType { private set; get; } = "DataRecievedEvent";

    public Guid DataId { private set; get; } = dataId;

    public string DataSourceName { private set; get; } = dataSourceName;
}
