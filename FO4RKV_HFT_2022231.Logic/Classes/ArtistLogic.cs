using FO4RKV_HFT_2022231.Logic.Interface;
using FO4RKV_HFT_2022231.Models;
using FO4RKV_HFT_2022231.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Logic.Classes
{
    public class ArtistLogic : IArtistLogic
    {
        IRepository<Artist> artistrepo;
        public ArtistLogic(IRepository<Artist> artistrepo)
        {
            this.artistrepo = artistrepo;
        }
        #region CRUD methods
        public void Create(Artist item)
        {
            this.artistrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.artistrepo.Delete(id);
        }

        public Artist Read(int id)
        {
            return this.artistrepo.Read(id);
        }

        public IQueryable<Artist> ReadAll()
        {
            return this.artistrepo.ReadAll();
        }

        public void Update(Artist item)
        {
            this.artistrepo.Update(item);
        }
        #endregion
        #region Non-CRUD methods
        public double? AverageAge()
        {
            return this.artistrepo.ReadAll().Average(artist => artist.Age);
        }

        public Artist YoungestOrOldestArtist(char YoungOrOld = 'y')
        {
            var minmax = artistrepo.ReadAll().Select(m => m.Age);
            if (YoungOrOld == 'y') return artistrepo.ReadAll().Where(a => a.Age == minmax.Min()).FirstOrDefault();
            else return artistrepo.ReadAll().Where(a => a.Age == minmax.Max()).FirstOrDefault();
        }

        public List<Song> LandSArtistSong(string artistName)
        {
            var songsOfArtist = artistrepo.ReadAll().Where(art => art.Name.Equals(artistName));
            var shortest = songsOfArtist.SelectMany(s => s.Songs)
                .Where(s => s.Length == songsOfArtist.SelectMany(x => x.Songs).Min(x => x.Length))
                .FirstOrDefault();
            var longest = songsOfArtist.SelectMany(s => s.Songs)
                .Where(s => s.Length == songsOfArtist.SelectMany(x => x.Songs).Max(x => x.Length))
                .FirstOrDefault();
            var output = new List<Song>();
            output.Add(longest);
            output.Add(shortest);
            return output;
        }

        public string MostSongOfQueriedGenre(string genre)
        {
            var listOfArtists = artistrepo.ReadAll()
                .Select(x => new
            {
                ArtistName = x.Name,
                SumOfSongs = x.Songs.Where(x => x.Genre == genre).Count()
            })
                .OrderByDescending(x => x.SumOfSongs)
                .FirstOrDefault();
            if (listOfArtists.SumOfSongs == 0) return "This genre is either mistyped or not added yet.";
            else return listOfArtists.ArtistName +" made "+listOfArtists.SumOfSongs+" songs of the "+genre+" genre.";
        }

        #endregion
    }
}
