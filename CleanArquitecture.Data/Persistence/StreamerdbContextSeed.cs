using CleanArquitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArquitecture.Infrastructure.Persistence
{
    public class StreamerdbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerdbContextSeed> logger)
        {
            if (!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreConfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreConfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer {CreatedBy = "vaxidrez", Name = "Maxi HBP", Url = "http://www.hbp.com"},
                new Streamer {CreatedBy = "vaxidrez", Name = "Amazon VIP", Url = "http://www.amazonvip.com"},
            };
        }
    }
}
