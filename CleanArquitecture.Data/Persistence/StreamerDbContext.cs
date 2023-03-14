﻿using CleanArquitecture.Domain;
using CleanArquitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArquitecture.Infrastructure.Persistence
{
    public class StreamerDbContext : DbContext
    {

        public StreamerDbContext(DbContextOptions<StreamerDbContext> options) : base(options) 
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=LPTF1S5Q55; 
        //        Initial Catalog=Streamer; Integrated Security=True")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate= DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
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
        public DbSet<Director>? Directors { get; set; }
        public DbSet<VideoActor>? VideosActors { get; set; }
    }
}
