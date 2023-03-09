using MediatR;

namespace CleanArquitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVm>>
    {
        public string Username { get; set; } = String.Empty;
        public GetVideosListQuery(string? username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
