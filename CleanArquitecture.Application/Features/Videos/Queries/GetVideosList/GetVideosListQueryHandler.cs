using AutoMapper;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Domain;
using MediatR;

namespace CleanArquitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        //private readonly IVideoRepository _videoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_videoRepository = videoRepository;
            _unitOfWork = unitOfWork;
            _mapper     = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Video> videoList = await _unitOfWork.VideoRepository.GetVideoByUsername(request.Username);

            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
