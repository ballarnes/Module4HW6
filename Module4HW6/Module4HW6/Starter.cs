using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4HW6.DataAccess;
using Module4HW6.DataAccess.Entities;

namespace Module4HW6
{
    public class Starter
    {
        public void Run()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = configuration.GetConnectionString("Module4HW6");
            dbOptionsBuilder.UseSqlServer(connectionString, i => i.CommandTimeout(20));
            var applicationContext = new ApplicationContext(dbOptionsBuilder.Options);

            // query1 //
            var songs = applicationContext.Song
                    .Include(i => i.ArtistSong)
                        .ThenInclude(i => i.Artist)
                    .Include(i => i.Genre)
                    .Where(i => i.Genre != null)
                    .Where(i => i.ArtistSong.Select(a => a.Artist.IsAlive).Contains(true))
                    .Select(i => new { Title = i.Title, Artists = i.ArtistSong.Select(a => a.Artist.Name), Genre = i.Genre.Title })
                    .ToList();

            Console.WriteLine("===QUERY_1===");
            foreach (var song in songs)
            {
                Console.WriteLine("=============");
                Console.WriteLine($"Song name: {song.Title}");
                Console.WriteLine($"Song genre: {song.Genre}");
                Console.Write("Artists: ");
                foreach (var artist in song.Artists)
                {
                    Console.Write($"[{artist}] ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            // query2 //
            var genres = applicationContext.Song
                .GroupBy(i => i.GenreId)
                .Select(i => new { Title = i.Key, Count = i.Count() })
                .ToList();

            Console.WriteLine("===QUERY_2===");
            foreach (var genre in genres)
            {
                if (genre.Title == null)
                {
                    Console.WriteLine($"Songs without genre: {genre.Count}");
                }
                else
                {
                    switch (genre.Title)
                    {
                        case 1:
                            Console.WriteLine($"Rock: {genre.Count}");
                            break;
                        case 2:
                            Console.WriteLine($"Pop: {genre.Count}");
                            break;
                        case 3:
                            Console.WriteLine($"Rap: {genre.Count}");
                            break;
                        case 4:
                            Console.WriteLine($"Blues: {genre.Count}");
                            break;
                        case 5:
                            Console.WriteLine($"Dance: {genre.Count}");
                            break;
                    }
                }
            }

            Console.WriteLine();

            // query3 //
            var theYoungestArtist = applicationContext.Artist.Max(i => i.DateOfBirth);
            var selectedSongs = applicationContext.Song.Where(i => i.ReleasedDate < theYoungestArtist).Include(i => i.ArtistSong).ThenInclude(i => i.Artist)
                    .Select(i => new { Title = i.Title, Artists = i.ArtistSong.Select(a => a.Artist.Name), Duration = i.Duration, Genre = i.Genre.Title, ReleasedDate = i.ReleasedDate })
                    .ToList();

            Console.WriteLine("===QUERY_3===");
            foreach (var song in selectedSongs)
            {
                Console.WriteLine("=============");
                Console.WriteLine($"Song name: {song.Title}");
                Console.Write("Song genre: ");
                if (song.Genre == null)
                {
                    Console.WriteLine("No genre");
                }
                else
                {
                    Console.WriteLine(song.Genre);
                }

                Console.Write("Artists: ");
                foreach (var artist in song.Artists)
                {
                    Console.Write($"[{artist}] ");
                }

                Console.WriteLine();
                Console.WriteLine($"Song duration: {song.Duration / 60}m {song.Duration % 60}s");
                Console.WriteLine($"Song released date: {song.ReleasedDate.ToString("dd.MM.yyyy")}");
            }

            applicationContext.SaveChanges();
        }
    }
}
