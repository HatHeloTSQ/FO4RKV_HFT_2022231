using ConsoleTools;
using FO4RKV_HFT_2022231.Models;
using FO4RKV_HFT_2022231.Repository.Database;
using System;
using System.Collections.Generic;

namespace FO4RKV_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;
        static void Delete(string entity)
        {
            Console.WriteLine($"Enter {entity} id to delete:");
            int del = int.Parse(Console.ReadLine());
            switch (entity)
            {
                case "Song":
                    rest.Delete(del, "Song");
                    break;
                case "Artist":
                    rest.Delete(del, "Artist");
                    break;
                case "Publisher":
                    rest.Delete(del, "Publisher");
                    break;
                default:
                    Console.WriteLine("Invalid entity");
                    break;
            }
        }
        static void Update(string entity)
        {
            Console.WriteLine($"Enter {entity}'s ID to update");
            int updateid = int.Parse(Console.ReadLine());
            switch (entity)
            {
                case "Song":
                    try
                    {
                        Song songUpdate = rest.Get<Song>(updateid, "Song/");
                        Console.WriteLine($"Enter new song title (old: {songUpdate.Title}):");
                        string newSongTitle = Console.ReadLine();
                        Console.WriteLine($"Enter new song artist id (old: {songUpdate.ArtistID}):");
                        int newSongArtist = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Enter new song length (old: {songUpdate.Length}):");
                        int newSongLength = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Enter new song genre (old: {songUpdate.Genre}):");
                        string newSongGenre = Console.ReadLine();
                        songUpdate.Length = newSongLength;
                        songUpdate.Genre = newSongGenre;
                        songUpdate.Title = newSongTitle;
                        songUpdate.ArtistID = newSongArtist;
                        rest.Put(songUpdate, "Song");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                case "Artist":
                    try
                    {
                        Artist artistUpdate = rest.Get<Artist>(updateid, "Artist/");
                        Console.WriteLine($"Enter new artist studio ID (old: {artistUpdate.StudioID}):");
                        int newArtistStudioID = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Enter new artist name (old: {artistUpdate.Name}):");
                        string newArtistName = Console.ReadLine();
                        Console.WriteLine($"Enter new artist age(old: {artistUpdate.Age}):");
                        int newArtistAge = int.Parse(Console.ReadLine());
                        artistUpdate.Age = newArtistAge;
                        artistUpdate.StudioID = newArtistStudioID;
                        artistUpdate.Name = newArtistName;
                        rest.Put(artistUpdate, "Artist");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                case "Publisher":
                    try
                    {
                        Publisher publisherUpdate = rest.Get<Publisher>(updateid, "Publisher/");
                        Console.WriteLine($"Enter new publisher name (old: {publisherUpdate.StudioName}):");
                        string newPublisherName = Console.ReadLine();
                        Console.WriteLine($"Enter new publisher country (old: {publisherUpdate.Country}):");
                        string newPublisherCountry = Console.ReadLine();
                        publisherUpdate.Country = newPublisherCountry;
                        publisherUpdate.StudioName = newPublisherName;
                        rest.Put(publisherUpdate, "Publisher");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid entity");
                    break;
            }
        }
        static void Create(string entity)
        {
            switch (entity)
            {
                case "Song":
                    try
                    {
                        Console.WriteLine("Enter song title: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter song genre: ");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Enter ArtistID: ");
                        int aid = int.Parse(Console.ReadLine());
                        rest.Post<Song>(new Song(title, genre, aid), "Song");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                case "Artist":
                    try
                    {
                        Console.WriteLine("Enter artist name:");
                        string newArtistName = Console.ReadLine();
                        Console.WriteLine("Enter artist StudioID:");
                        int newArtistStudio = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter age:");
                        int newArtistAge = int.Parse(Console.ReadLine());
                        rest.Post(new Artist(newArtistName, newArtistStudio, newArtistAge), "Artist");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                case "Publisher":
                    try
                    {
                        Console.WriteLine("Enter publisher name:");
                        string newPublisherName = Console.ReadLine();
                        Console.WriteLine("Enter publisher country:");
                        string newPublisherCountry = Console.ReadLine();
                        rest.Post(new Publisher(newPublisherCountry, newPublisherName), "Publisher");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid entity");
                    break;
            }
        }
        static void Read(string entity)
        {
            switch (entity)
            {
                case "Song":
                    List<Song> songs = rest.Get<Song>("Song");
                    Console.WriteLine("");
                    Console.WriteLine("=================================================");
                    foreach (var s in songs)
                    {
                        Console.Write($"{s.SongID}\t{s.Title}\n\t{s.Genre} | {s.Length} | ");
                        if (s.Artist == null) Console.Write("Artist has been deleted\n=================================================\n");
                        else Console.Write($"{s.Artist.Name}\n=================================================\n");
                    }
                    break;
                case "Artist":
                    List<Artist> artists = rest.Get<Artist>("Artist");
                    Console.WriteLine("");
                    Console.WriteLine("=================================================");
                    foreach (var a in artists)
                    {
                        Console.WriteLine($"{a.ArtistID}\t{a.Name}\n\t{a.Age}\t{a.StudioID}-{a.Studio.StudioName}\n=================================================");
                    }
                    break;
                case "Publisher":
                    List<Publisher> pubs = rest.Get<Publisher>("Publisher");
                    Console.WriteLine("");
                    Console.WriteLine("=================================================");
                    foreach (Publisher p in pubs)
                    {
                        Console.WriteLine($"{p.StudioID}\t{p.StudioName}\t{p.Country}\n=================================================");
                    }
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
        static void AverageAge()
        {
            var avg = rest.GetSingle<double?>("Artist/avgage");
            Console.WriteLine($"The average age of artists is {avg}");
            Console.ReadLine();
        }
        static void YorO()
        {
            Console.WriteLine("Would you like to see the youngest or the oldest artist?\n(y/o)");
            char c = char.Parse(Console.ReadLine());
            Console.WriteLine("");
            Artist yoro = rest.GetChar<Artist>(c, "Artist/yoro");
            if (c == 'y') Console.WriteLine($"Youngest artist's name is {yoro.Name} and age is {yoro.Age}");
            else Console.WriteLine($"Oldest artist's name is {yoro.Name} and age is {yoro.Age}");
            Console.ReadLine();
        }
        static void MostPopularCountry()
        {
            var ctr = rest.GetSingle<string>("Publisher/mostpopularcountry");
            Console.WriteLine($"The most popular country is {ctr}");
            Console.ReadLine();
        }
        static void MostPopularGenre()
        {
            var gen = rest.GetSingle<string>("Song/mostpopulargenre");
            Console.WriteLine($"The most popular genre is {gen}");
            Console.ReadLine();
        }
        static void AverageSongLength()
        {
            var avg = rest.GetSingle<double?>("Song/averagesonglength");
            Console.WriteLine($"The average length of all songs is {(int)avg / 60}:{(int)avg % 60}");
            Console.ReadLine();
        }
        static void PublisherAndArtist() //song 
        {
            Console.WriteLine("Please enter the ID of the song you're looking for");
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error.");
            }
            string panda = rest.Get<string>(input, "Song/pubandasong?songID=");
            Console.WriteLine(panda);
            Console.ReadLine();
        }
        static void ListOfSongs() //song
        {
            Console.WriteLine("Please enter a value (in seconds):");
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error.");
            }
            string los = rest.Get<string>(input, "Song/longerthanvalue?value=");
            Console.WriteLine(los);
            Console.ReadLine();
        }
        static void LongestAndShortest() //art
        {
            Console.WriteLine("Please enter that artist's name you're looking for:");
            string input = Console.ReadLine();
            if (input == null || input == "")
            {
                Console.WriteLine("Error: invalid input.");
            }
            else
            {
                List<Song> las = rest.GetString<List<Song>>(input, "Artist/artistsonglength?artistName=");
                Console.WriteLine($"\nThe longest and shortest songs of {input} are:");
                foreach (var item in las)
                {
                    try
                    {
                        Console.WriteLine($"\t{item.Title} ({item.Genre}) - {item.Length / 60}:{item.Length % 60}");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error.");
                    }
                }
            }
            Console.ReadLine();
        }
        static void QueriedGenre() //art
        {
            Console.WriteLine("Please specify a genre: ");
            string input = Console.ReadLine();
            if (input == null ||input == "")
            {
                Console.WriteLine("Error: invalid input.");
            }
            else
            {
                string query = rest.GetString<string>(input, "Artist/queriedgenre?genre=");
                Console.WriteLine("\n" + query);
            }
            Console.ReadLine();
        }
        static void StudioArtists() //pub
        {
            Console.WriteLine("Enter a the name of which studio's roster would you like to see:");
            string input = Console.ReadLine();
            if (input == null || input == "")
            {
                Console.WriteLine("Error: invalid input.");
            }
            else
            {
                string studart = rest.GetString<string>(input, "Publisher/studioartists?studioName=");
                Console.WriteLine(studart);
            }
            Console.ReadLine();
        }
        static void FullLengthStudio() //pub
        {
            Console.WriteLine("Enter the studio's ID you're looking for:");
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: invalid input.");
            }
            if (input == int.MinValue)
            {
                Console.WriteLine("Error: invalid output.");
            }
            else
            {
                int studart = rest.Get<int>(input, "Publisher/fulllength?studioID=");
                Console.WriteLine($"The time it'd take to listen to all songs of the studio ({input}) is {studart / 60} minutes {studart % 60} seconds");
            }
            Console.ReadLine();
        }
        static void PopularGenreOfCountry() //pub 
        {
            Console.WriteLine("Enter the country's id you're looking for:");
            string input = Console.ReadLine();
            string genre = rest.GetString<string>(input, "Publisher/codeofcountry?countryCode=");
            Console.WriteLine(genre);
            Console.ReadLine();
        } 


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:14705/", "swagger");

            var sonNCSubMenu = new ConsoleMenu(args, level: 2)
                .Add("Most popular genre", () => MostPopularGenre())
                .Add("Average song length", () => AverageSongLength())
                .Add("Publishers and artists of queried song", () => PublisherAndArtist())
                .Add("List of songs that are longer than the specified value", () => ListOfSongs())
                .Add("Exit", ConsoleMenu.Close);

            var songSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => Read("Song"))
                .Add("Create", () => Create("Song"))
                .Add("Update", () => Update("Song"))
                .Add("Delete", () => Delete("Song"))
                .Add("Queries", () => sonNCSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            var artNCSubMenu = new ConsoleMenu(args, level: 2)
                .Add("Average artist age", () => AverageAge())
                .Add("Youngest or oldest artist", () => YorO())
                .Add("Longest and shortest song of queried artist", () => LongestAndShortest())
                .Add("Which artist made the most songs of the specified genre", () => QueriedGenre())
                .Add("Exit", ConsoleMenu.Close);

            var artSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => Read("Artist"))
                .Add("Create", () => Create("Artist"))
                .Add("Update", () => Update("Artist"))
                .Add("Delete", () => Delete("Artist"))
                .Add("Queries", () => artNCSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            var pubNCSubMenu = new ConsoleMenu(args, level: 2)
               .Add("Most popular country", () => MostPopularCountry())
               .Add("Lists all artists associated with studio", () => StudioArtists())
               .Add("The total length of songs of specified studio", () => FullLengthStudio())
               .Add("What is the most popular genre in queried country", () => PopularGenreOfCountry())
               .Add("Exit", ConsoleMenu.Close);

            var pubSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => Read("Publisher"))
                .Add("Create", () => Create("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Queries", () => pubNCSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            var mainMenu = new ConsoleMenu(args, level: 0)
                .Add("Artists", () => artSubMenu.Show())
                .Add("Songs", () => songSubMenu.Show())
                .Add("Publishers", () => pubSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            mainMenu.Show();
        }
    }
}

