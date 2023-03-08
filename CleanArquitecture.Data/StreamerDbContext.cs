using CleanArquitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArquitecture.Data
{
    public class StreamerDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LPTF1S5Q55; 
                Initial Catalog=Streamer; Integrated Security=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(a => a.Actors)
                .WithMany(v => v.Videos)
                .UsingEntity<VideoActor>(
                av => av.HasKey(e => new { e.ActorId, e.VideoId })
                );
        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Actor>? Actors { get; set; }
        public DbSet<Director>? Directors { get; set;}
        public DbSet<VideoActor>? VideosActors { get; set;}
    }
}
