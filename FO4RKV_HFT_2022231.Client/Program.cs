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
                    rest.Delete(del, "song");
                    break;
                case "Artist":
                    rest.Delete(del, "artist");
                    break;
                case "Publisher":
                    rest.Delete(del, "publisher");
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
                    var songUpdate = rest.Get<Song>(updateid,"song");
                    Console.WriteLine($"Enter new song title (old: {songUpdate.Title}):");
                    string newSongTitle = Console.ReadLine();
                    Console.WriteLine($"Enter new song artist (old: {songUpdate.ArtistName}):");
                    string newSongArtist = Console.ReadLine();
                    Console.WriteLine($"Enter new song length (old: {songUpdate.Length}):");
                    int newSongLength = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Enter new song genre (old: {songUpdate.Genre}):");
                    string newSongGenre = Console.ReadLine();
                    songUpdate.Length = newSongLength;
                    songUpdate.Genre = newSongGenre;
                    songUpdate.Title = newSongTitle;
                    songUpdate.ArtistName = newSongArtist;
                    rest.Put(songUpdate,"song");
                    break;
                case "Artist":
                    var artistUpdate = rest.Get<Artist>(updateid, "artist");
                    Console.WriteLine($"Enter new artist studio ID (old: {artistUpdate.StudioID}):");
                    int newArtistStudioID = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Enter new artist name (old: {artistUpdate.Name}):");
                    string newArtistName = Console.ReadLine();
                    Console.WriteLine($"Enter new artist age(old: {artistUpdate.Age}):");
                    int newArtistAge = int.Parse(Console.ReadLine());
                    artistUpdate.Age = newArtistAge;
                    artistUpdate.StudioID = newArtistStudioID;
                    artistUpdate.Name = newArtistName;
                    rest.Put(artistUpdate, "artist");
                    break;
                case "Publisher":
                    var publisherUpdate = rest.Get<Publisher>(updateid, "publisher");
                    Console.WriteLine($"Enter new publisher name (old: {publisherUpdate.StudioName}):");
                    string newPublisherName = Console.ReadLine();
                    Console.WriteLine($"Enter new publisher country (old: {publisherUpdate.Country}):");
                    string newPublisherCountry = Console.ReadLine();
                    publisherUpdate.Country = newPublisherCountry;
                    publisherUpdate.StudioName = newPublisherName;
                    rest.Put(publisherUpdate, "publisher");
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
                    Console.WriteLine("Enter song title:");
                    string newSongTitle = Console.ReadLine();
                    Console.WriteLine("Enter song artist:");
                    string newSongArtist = Console.ReadLine();
                    Console.WriteLine("Enter song length:");
                    int newSongLength = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter song genre:");
                    string newSongGenre = Console.ReadLine();
                    var songCreate = new Song() { ArtistName = newSongArtist, Genre = newSongGenre, Title = newSongTitle, Length = newSongLength };
                    rest.Post(songCreate, "song");
                    break;
                case "Artist":
                    Console.WriteLine("Enter artist name:");
                    string newArtistName = Console.ReadLine();
                    Console.WriteLine("Enter artist StudioID:");
                    int newArtistStudio = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter age:");
                    int newArtistAge = int.Parse(Console.ReadLine());
                    var artistCreate = new Artist() { StudioID = newArtistStudio, Name = newArtistName, Age = newArtistAge };
                    rest.Put(artistCreate, "artist");
                    break;
                case "Publisher":
                    Console.WriteLine("Enter publisher name:");
                    string newPublisherName = Console.ReadLine();
                    Console.WriteLine("Enter publisher country:");
                    string newPublisherCountry = Console.ReadLine();
                    var publisherCreate = new Publisher() { StudioName = newPublisherName, Country = newPublisherCountry };
                    rest.Put(publisherCreate, "publisher");
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
                    List<Song> songs = rest.Get<Song>("song");
                    Console.WriteLine("");
                    foreach (Song s in songs) Console.WriteLine($"{s.SongID}\t>>{s.Title}\t>>{s.Genre}\t>>{s.Artist.Name}\t>>{s.Length}");
                    break;
                case "Artist":
                    List<Artist> artists = rest.Get<Artist>("artist");
                    foreach (Artist a in artists)
                    {
                        Console.WriteLine($"{a.ArtistID}\t>>{a.Name}\t>>{a.Studio.StudioID}\t>>{a.Age}");
                        foreach (Song s in a.Songs) Console.Write($"\t\t\t>>{s.Title}");
                    }
                    break;
                case "Publisher":
                    List<Publisher> pubs = rest.Get<Publisher>("publisher");
                    foreach (Publisher p in pubs)
                    {
                        Console.WriteLine($"{p.StudioID}\t>>{p.StudioName}\t>>{p.Country}");
                        foreach (Artist a in p.Artists) Console.Write($"\t\t>>{a.Name}");
                    }
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var rest = new RestService("http://localhost:14705/","artist");

            var songSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => Read("Song"))
                .Add("Create", () => Create("Song"))
                .Add("Update", () => Update("Song"))
                .Add("Delete", () => Delete("Song"))
                .Add("Exit", ConsoleMenu.Close);

            var artSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => Read("Artist"))
                .Add("Create", () => Create("Artist"))
                .Add("Update", () => Update("Artist"))
                .Add("Delete", () => Delete("Artist"))
                .Add("Exit", ConsoleMenu.Close);

            var pubSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => Read("Publisher"))
                .Add("Create", () => Create("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Exit", ConsoleMenu.Close);

            var mainMenu = new ConsoleMenu(args, level: 0)
                .Add("Artists", () => artSubMenu.Show())
                .Add("Songs", () => songSubMenu.Show())
                .Add("Publishers", () => pubSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

        }
    }
}

