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
    public class SongLogic : ISongLogic
    {
        IRepository<Song> songrepo;
        public SongLogic(IRepository<Song> songrepo)
        {
            this.songrepo = songrepo;
        }

        #region CRUD methods
        public void Create(Song item)
        {
            this.songrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.songrepo.Delete(id);
        }

        public Song Read(int id)
        {
            return this.songrepo.Read(id);
        }

        public IQueryable<Song> ReadAll()
        {
            return this.songrepo.ReadAll();
        }

        public void Update(Song item)
        {
            this.songrepo.Update(item);
        }
        #endregion
        #region Non-CRUD methods
        public double? AvgLength()
        {
            return songrepo.ReadAll().Average(a => a.Length);
        }

        public string MostPopularGenre()
        {
            var helper = songrepo.ReadAll().GroupBy(x => x.Genre).Select(m => new {
                GenreName = m.Key,
                GenresCount = m.Count()
            }).OrderByDescending(x => x.GenresCount).FirstOrDefault();
            return helper.GenreName;
        }

        public string PubAndAOfSong(int songID)
        {
            if (songID.ToString() != null)
            {
                var songList = songrepo.ReadAll().Where(x => x.SongID == songID).Select(x => new
                {
                    Song = x.Title,
                    Artist = x.Artist.Name,
                    Studio = x.Artist.Studio.StudioName
                }).FirstOrDefault();
                if (songList == null || songList.Song == null || songList.Artist == null || songList.Studio == null)
                {
                    return "Error: something went wrong...";
                }
                else return "The artist and publisher of " + songList.Song + " is " + songList.Artist + " (" + songList.Studio + ")";
            }
            return "Error: invalid input";
        }

        public string ListOfSongs(int value)
        {
            
            if (value > 0)
            {
                var songList = songrepo.ReadAll().Where(x => x.Length >= value).Select(x => new {
                    Title = x.Title,
                    Artist = x.Artist.Name,
                    Len = x.Length
                }).ToList().OrderBy(x => x.Len);
                string concat = "The titles of songs that are longer than the queried length (" + value / 60 + ":" + value % 60 + ") is/are:\n";
                foreach (var item in songList)
                {
                    if (item.Artist == null || item.Title == null || item.Len.ToString() == null)
                    {
                        concat += "Error during process; data was null";
                    }
                    else concat += "\t" + item.Artist + " - " + item.Title + "(" + item.Len / 60 + ":" + item.Len % 60 + ")\n";
                }
                return concat;
            }
            return "Error: invalid input";
        }
        #endregion
    }
}
