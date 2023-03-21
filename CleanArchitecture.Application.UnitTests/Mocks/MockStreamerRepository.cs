using AutoFixture;
using CleanArquitecture.Domain;
using CleanArquitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRepository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior()); //esto ayuda evitar el error de referencia circular por las relaciones entre tablas

            var streamers = fixture.CreateMany<Streamer>().ToList();
            streamers.Add(fixture.Build<Streamer>()
                .With(tr => tr.Id, 1008)
                .Without(tr => tr.Videos)
                .Create()
                );


            streamerDbContextFake.Streamers!.AddRange(streamers);
            streamerDbContextFake.SaveChanges();
        }
    }
}
