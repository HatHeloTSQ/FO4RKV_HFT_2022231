﻿using FO4RKV_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Logic.Interface
{
    public interface ISongLogic
    {
        public string MostPopularGenre();
        public double? AvgLength();
        public string PubAndAOfSong(int songID);
        public string ListOfSongs(int value);
        void Create(Song item);
        void Delete(int id);
        Song Read(int id);
        IQueryable<Song> ReadAll();
        void Update(Song item);
    }
}
