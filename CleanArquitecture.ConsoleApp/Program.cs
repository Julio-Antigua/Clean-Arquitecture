using CleanArquitecture.Data;
using CleanArquitecture.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

StreamerDbContext dbContext = new();

//await AddNewRecords();
//QueryStreaming();
//await QueryFilter();

await Task.WhenAll(
    //QueryMethods()
    //QueryLinq()
    //TrakingAndNotTracking()
    //AddNewStreamerWithVideoId()
    //AddNewActorWithVideo()
    //AddNewDirectorWithVideo()
    //MultipleEntitiesQuery()
);

Pelicula pelicula = new Pelicula();
pelicula.testFunc();

Console.WriteLine("Presione cualquier tecla para terminar el programa");
Console.ReadKey();


async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext!.Videos!.Include(q => q.Actors).FirstOrDefaultAsync(q => q.Id == 1);
    //var actor = await dbContext!.Actors!.Select(x => x.Name).ToListAsync();
    var videowithDirector = await dbContext!.Videos!
        .Where(q => q.Director != null)
        .Include(q => q.Director)
        .Select(q =>
            new
            {
                Director_Full_Name = $"{q.Director.Name} {q.Director.LastName}",
                Movie = q.Name
            }
        ).ToListAsync();

    foreach(var movies in videowithDirector)
    {
        Console.WriteLine($"Movie: {movies.Movie} | Director: {movies.Director_Full_Name}");
    }

}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Name = "Lorenzo",
        LastName = "Basteri",
        VideoId = 1
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor = new Actor 
    {
        Name = "Brad",
        LastName = "Pitt"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{
    var batmanForever = new Video
    {
        Name = "Batman Forever",
        StreamerId = 4
    };

    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var screen = new Streamer
    {
        Name = "Pantaya"
    };

    var hungerGames = new Video
    {
        Name = "Hunger Games",
        Streamer = screen
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}

async Task TrakingAndNotTracking()
{
    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNoTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTracking.Name = "Netflix Super";
    streamerWithNoTracking.Name = "Amazon Plus";

    await dbContext!.SaveChangesAsync();
}

async Task QueryLinq()
{
    Console.WriteLine($"Ingrese el servicio de streaming");
    string streamerName = Console.ReadLine();

    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i.Name, $"{streamerName}")
                           select i).ToListAsync();

    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}

async Task QueryMethods()
{
    
    var streamer = dbContext.Streamers;

    var FirstAsync = await streamer!.Where(y => y.Name.Contains("a")).FirstAsync();
    var FirstOrDefaultAsync = await streamer!.Where(y => y.Name.Contains("a")).FirstOrDefaultAsync();
    var FirstOrDefaultAsync_v2 = await streamer!.FirstOrDefaultAsync(y => y.Name.Contains("a"));

    var singleAsync = await streamer!.Where(y => y.Id == 1).SingleAsync();
    var singleOrDefaultAsync = await streamer!.Where(y => y.Id == 1).SingleOrDefaultAsync();

    var result = await streamer!.FindAsync(1);

    var count = await streamer!.CountAsync();
    var longAccount = await streamer.LongCountAsync();
    var min = await streamer.MinAsync();
    var max = await streamer.MaxAsync();

}

async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compania de streaming:");
    var nameStreaming = Console.ReadLine();
    var streamers = await dbContext!.Streamers!.Where(x => x.Name.Equals(nameStreaming)).ToListAsync();
    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }

    //var streamerPartialResults = await dbContext!.Streamers!.Where(x => x.Name.Contains(nameStreaming)).ToListAsync();
    var streamerPartialResults = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Name, $"%{nameStreaming}%")).ToListAsync();
    foreach (var streamer in streamerPartialResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}

void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Name = "Disney",
        Url = "https://disney.com"

    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    List<Video> movies = new List<Video>
    {
    new Video
    {
        Name = "La Ceniciente",
        StreamerId = streamer.Id,
    },
     new Video
    {
        Name = "1001 dalmatas",
        StreamerId = streamer.Id,
    },
      new Video
    {
        Name = "El Jorobado de Notredame",
        StreamerId = streamer.Id,
    },
       new Video
    {
        Name = "Citizen Kane",
        StreamerId = streamer.Id,
    },
};

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();

}

public class Pelicula
{
    public Pelicula()
    {

    }
    public string? Nombre { get; set; }

    List<Pelicula> peliculas = new List<Pelicula>
        {
            new Pelicula {Nombre = "matrix"},
            new Pelicula {Nombre = "mad max"},
            new Pelicula {Nombre = "avatar"}
        };


    public void testFunc()
    {

        Func<Pelicula, string> selector = pelicula => "Pelicula:" + pelicula.Nombre;

        IEnumerable<string> videoTitulos = peliculas.Select(selector);

        foreach (string titulos in videoTitulos)
        {
            Console.WriteLine(titulos);
        }
    }
 
}

