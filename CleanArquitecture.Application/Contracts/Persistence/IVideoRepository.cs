using CleanArquitecture.Domain;

namespace CleanArquitecture.Application.Contracts.Persistence
{
    public interface IVideoRepository: IAsyncRepository<Video>
    {
         Task<Video> GetvideoByName(string name);
         Task<IEnumerable<Video>> GetVideoByUsername(string username);
    }
}
