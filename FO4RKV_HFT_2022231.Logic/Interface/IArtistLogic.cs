using FO4RKV_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Logic.Interface
{
    public interface IArtistLogic
    {
        public double? AverageAge();    
        public Artist YoungestOrOldestArtist(char YoungOrOld = 'y');
        public List<Song> LandSArtistSong(string artistName);
        public string MostSongOfQueriedGenre(string genre);
        void Create(Artist item);
        void Delete(int id);
        Artist Read(int id);
        IQueryable<Artist> ReadAll();
        void Update(Artist item);
    }
}
