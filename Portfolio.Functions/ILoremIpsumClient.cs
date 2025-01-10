using System.Threading.Tasks;

namespace Portfolio.Functions
{
    public interface ILoremIpsumClient
    {
        Task ReceivedNotification(LoremIpsum ipsum);
    }
}
