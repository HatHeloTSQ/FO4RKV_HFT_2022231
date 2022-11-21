using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Models
{
    public class Song
    {
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        [Required]
        public virtual Artist Artist { get; set; }
        [ForeignKey(nameof(Artist))]
        public string ArtistName { get; set; }
        [Range(0,1200)]
        public int Length { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongID { get; set; }

        public Song(string title, string genre, int length, int songID, string artistName)
        {
            Title = title;
            Genre = genre;
            Length = length;
            SongID = songID;
            ArtistName = artistName;
        }

        public Song()
        {

        }
    }
}
