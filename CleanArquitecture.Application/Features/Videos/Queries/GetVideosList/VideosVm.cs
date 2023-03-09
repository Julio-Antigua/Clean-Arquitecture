using CleanArquitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class VideosVm
    {
        public string? Name { get; set; }
        public int StreamerId { get; set; }
    }
}
