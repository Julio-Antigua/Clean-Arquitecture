using AutoMapper;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Domain;
using MediatR;

namespace CleanArquitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Video> videoList = await _videoRepository.GetVideoByUsername(request.Username);

            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
