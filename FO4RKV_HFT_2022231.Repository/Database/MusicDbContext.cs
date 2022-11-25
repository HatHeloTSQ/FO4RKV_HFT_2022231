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

            modelBuilder.Entity<Song>()
                .HasOne(x => x.Artist)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.ArtistID)
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
                new Artist(1,"Sub Focus", 4, 40),
                new Artist(2,"Andy C", 4, 46),
                new Artist(3,"Grafix", 1, 31),
                new Artist(4,"Metrik", 1, 35),
                new Artist(5,"Camo & Krooked", 3, 36),
                new Artist(6,"DJ Fresh", 3, 45),
                new Artist(7,"Maduk", 2, 32),
                new Artist(8,"Fox Stevenson", 2, 29),
                new Artist(9,"MUZZ", 2, 28),
                new Artist(10,"Koven", 5, 32),
                new Artist(11,"Pegboard Nerds", 5, 45),
                new Artist(12,"Noisestorm", 5, 27)
            });

            modelBuilder.Entity<Song>().HasData(new Song[]
            {
                new Song("Off the Ground", "Drum and Bass", 242, 1, 1),
                new Song("Solar System", "Drum and Bass", 288, 2, 1),
                new Song("Firestarter (Andy C remix)", "Drum and Bass", 232, 3, 2),
                new Song("Ghost", "Drum and Bass", 166, 4, 2),
                new Song("Somewhere", "Drum and Bass", 220, 5, 3),
                new Song("Overdrive", "Drum and Bass", 281, 6, 3),
                new Song("Parallel", "Drum and Bass", 270, 7, 4),
                new Song("Ex Machina", "Drum and Bass", 267, 8, 4),
                new Song("Sientelo", "Drum and Bass", 290, 9, 5),
                new Song("No Tomorrow", "Drum and Bass", 271, 10, 5),
                new Song("Golddust", "Drum and Bass", 191, 11, 6),
                new Song("Talkbox", "Drum and Bass", 282, 12, 6),
                new Song("Ghost Assassin", "Drum and Bass", 221,13, 7),
                new Song("Colours", "Drum and Bass", 273,14 , 7),
                new Song("Throwdown", "Dubstep", 212,15, 8),
                new Song("Sandblast", "Glitch Hop", 327,16, 8),
                new Song("The Warehouse", "Drum and Bass", 282,17, 9 ),
                new Song("Children of Hell", "Dubstep", 404,18 , 9),
                new Song("Shut My Mouth", "Dubstep", 222,19 , 10),
                new Song("Take It All", "Dubstep", 252,20 , 10),
                new Song("Disconnected", "Electro", 241,21 , 11),
                new Song("Razor Sharp", "Glitch Hop", 281,22 , 11),
                new Song("Heist", "Trap", 182,23, 12 ),
                new Song("Breakdown VIP", "Drumstep", 236,24, 12 )
            });
        }

    }
}
