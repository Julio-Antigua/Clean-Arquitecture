using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Domain;
using CleanArquitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Infrastructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context): base(context) 
        { }

        public async Task<Video> GetvideoByName(string name) => await _context.Videos!.Where(o => o.Name == name).FirstOrDefaultAsync();

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username) => await _context.Videos!.Where(v => v.CreatedBy == username).ToListAsync();
       
    }
}
