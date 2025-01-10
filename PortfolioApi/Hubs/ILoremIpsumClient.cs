namespace PortfolioApi.Hubs
{
    public interface ILoremIpsumClient
    {
        Task ReceivedNotification(LoremIpsum ipsum);
    }
}
