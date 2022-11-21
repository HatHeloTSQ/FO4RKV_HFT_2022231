using FO4RKV_HFT_2022231.Repository.Database;
using System;

namespace FO4RKV_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicDbContext db = new MusicDbContext();

            var artists = db.Artists;
            var songs = db.Songs;
            var publishers = db.Publishers;
            ;

        }
    }
}
