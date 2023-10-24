namespace IntegrationTests.Helpers.Database;

public class SeedDataIds
{
    public List<int> NumbersIds { get; }
    public List<int> AudiosIds { get; }

    public SeedDataIds(List<int> numbersIds, List<int> audiosIds)
    {
        NumbersIds = numbersIds;
        AudiosIds = audiosIds;
    }
}