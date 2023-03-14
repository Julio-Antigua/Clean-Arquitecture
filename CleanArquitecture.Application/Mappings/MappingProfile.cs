using AutoMapper;
using CleanArquitecture.Application.Features.Streamers.Commands.CreateStreamer;
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
            CreateMap<CreateStreamerCommand, Streamer>().ReverseMap();
        }
    }
}
