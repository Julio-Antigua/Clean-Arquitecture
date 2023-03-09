using AutoMapper;
using CleanArquitecture.Application.Features.Streamers.Commands;
using CleanArquitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArquitecture.Domain;

namespace CleanArquitecture.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Video
            CreateMap<Video, VideosVm>();

            //Streamer
            CreateMap<StreamerCommand, Streamer>().ReverseMap();
        }
    }
}
