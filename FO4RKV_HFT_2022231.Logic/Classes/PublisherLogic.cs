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
    public class PublisherLogic : IPublisherLogic
    {
        IRepository<Publisher> pubrepo;
        public PublisherLogic(IRepository<Publisher> pubrepo)
        {
            this.pubrepo = pubrepo;
        }
        #region CRUD methods
        public void Create(Publisher item)
        {
            this.pubrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.pubrepo.Delete(id);
        }

        public Publisher Read(int id)
        {
            return this.pubrepo.Read(id);
        }

        public IQueryable<Publisher> ReadAll()
        {
            return this.pubrepo.ReadAll();
        }

        public void Update(Publisher item)
        {
            this.pubrepo.Update(item);
        }
        #endregion
        #region Non-CRUD methods
        public string MostPopularCountry()
        {
            var helper = pubrepo.ReadAll().GroupBy(x => x.Country).Select(m => new {
                Name = m.Key,
                Countries = m.Count()
            }).OrderByDescending(x => x.Countries).FirstOrDefault();
            return helper.Name;
        }

        public string ArtistsOfStudio(string studioName)
        {
            string output = "";
            var selected = pubrepo.ReadAll().Where(c => c.StudioName == studioName).SelectMany(x => x.Artists).Select(x => x.Name);
            foreach (var item in selected)
            {
                output += item + ", ";
            }
            if (output.Length <= 2) return "There was an error: invalid output.";
            else return output.Remove(output.Length - 2);
        }

        public int FullSongLengthOfStudio(int studioID)
        {
            if (studioID.ToString() != null)
            {
                return pubrepo.ReadAll()
                .Where(c => c.StudioID == studioID)
                .SelectMany(x => x.Artists)
                .SelectMany(x => x.Songs)
                .Sum(x => x.Length);
            }
            else return int.MinValue;
        }

        public string MostGenreByCountry(string countryCode)
        {
            if (countryCode != null && countryCode.Length == 2)
            {
                var selectAllCountries = pubrepo.ReadAll().Where(c => c.Country == countryCode);
                var mostGenreOfCountry = selectAllCountries.SelectMany(x => x.Artists)
                    .SelectMany(x => x.Songs)
                    .GroupBy(x => x.Genre)
                    .Select(x => new
                    {
                        name = x.Key,
                        genreNumber = x.Count()
                    })
                    .OrderByDescending(x => x.genreNumber)
                    .FirstOrDefault();
                if (mostGenreOfCountry == null || mostGenreOfCountry.genreNumber.ToString() == null || mostGenreOfCountry.name == "" || mostGenreOfCountry.name == null)
                {
                    return "Error: output was invalid.";
                }
                else return "The most popular genre in the " + countryCode + " is " + mostGenreOfCountry.name + " with " + mostGenreOfCountry.genreNumber + " songs.";
            }
            else return "Error: Country code is invalid (requires a 2 letter code)";
        }
        #endregion
    }
}
