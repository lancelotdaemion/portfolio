using Portfolio.Model;

namespace Portfolio.Api.Hubs
{
    public interface ILoremIpsumClient
    {
        Task ReceivedNotification(LoremIpsum ipsum);
    }
}
