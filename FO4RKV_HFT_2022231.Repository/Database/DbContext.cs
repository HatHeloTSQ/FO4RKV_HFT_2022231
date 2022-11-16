using FO4RKV_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Repository.Database
{
    public class MusicDbContext : DbContext
    {
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }

        public MusicDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("Music").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
                .HasMany(x => x.Artists)
                .WithOne(x => x.Studio)
                .HasForeignKey(x => x.StudioID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Artist>()
                .HasMany(x => x.Songs)
                .WithOne(x => x.Artist)
                .HasForeignKey(x => x.SongID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
                new Publisher("UK", "Hospital Records", 1),
                new Publisher("NL", "Liquicity Records", 2),
                new Publisher("UK", "Breakbeat Kaos", 3),
                new Publisher("UK", "RAM Records", 4),
                new Publisher("CA", "Monstercat", 5)
            });

            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist("Sub Focus", 4, 40),
                new Artist("Andy C", 4, 46),
                new Artist("Grafix", 1, 31),
                new Artist("Metrik", 1, 35),
                new Artist("Camo & Krooked", 3, 36),
                new Artist("DJ Fresh", 3, 45),
                new Artist("Maduk", 2, 32),
                new Artist("Fox Stevenson", 2, 29),
                new Artist("MUZZ", 2, 28),
                new Artist("Koven", 5, 32),
                new Artist("Pegboard Nerds", 5, 45),
                new Artist("Noisestorm", 5, 27)
            });

            modelBuilder.Entity<Song>().HasData(new Song[]
            {
                new Song("Off the Ground", "Drum and Bass", 242, 1, "Sub Focus"),
                new Song("Solar System", "Drum and Bass", 288, 2, "Sub Focus"),
                new Song("Firestarter (Andy C remix)", "Drum and Bass", 232, 3, "Andy C"),
                new Song("Ghost", "Drum and Bass", 166, 4, "Andy C"),
                new Song("Somewhere", "Drum and Bass", 220, 5, "Grafix"),
                new Song("Overdrive", "Drum and Bass", 281, 6, "Grafix"),
                new Song("Parallel", "Drum and Bass", 270, 7, "Metrik"),
                new Song("Ex Machina", "Drum and Bass", 267, 8, "Metrik"),
                new Song("Sientelo", "Drum and Bass", 290, 9, "Camo & Krooked"),
                new Song("No Tomorrow", "Drum and Bass", 271, 10, "Camo & Krooked"),
                new Song("Golddust", "Drum and Bass", 191, 11, "DJ Fresh"),
                new Song("Talkbox", "Drum and Bass", 282, 12, "DJ Fresh"),
                new Song("Ghost Assassin", "Drum and Bass", 221,13, "Maduk"),
                new Song("Colours", "Drum and Bass", 273,14 , "Maduk"),
                new Song("Throwdown", "Dubstep", 212,15, "Fox Stevenson"),
                new Song("Sandblast", "Glitch Hop", 327,16, "Fox Stevenson"),
                new Song("The Warehouse", "Drum and Bass", 282,17, "MUZZ" ),
                new Song("Children of Hell", "Dubstep", 404,18 , "MUZZ"),
                new Song("Shut My Mouth", "Dubstep", 222,19 , "Koven"),
                new Song("Take It All", "Dubstep", 252,20 , "Koven"),
                new Song("Disconnected", "Electro", 241,21 , "Pegboard Nerds"),
                new Song("Razor Sharp", "Glitch Hop", 281,22 , "Pegboard Nerds"),
                new Song("Heist", "Trap", 182,23, "Noisestorm" ),
                new Song("Breakdown VIP", "Drumstep", 236,24, "Noisestorm" )
            });
        }

    }
}
