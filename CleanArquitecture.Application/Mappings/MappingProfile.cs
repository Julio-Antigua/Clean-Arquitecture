using AutoMapper;
using CleanArquitecture.Application.Features.Directors.Commands.CreateDirector;
using CleanArquitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArquitecture.Application.Features.Streamers.Commands.UpdateStreamer;
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
            CreateMap<UpdateStreamerCommand, Streamer>().ReverseMap();

            //Director
            CreateMap<CreateDirectorCommand, Director>().ReverseMap();
        }
    }
}
