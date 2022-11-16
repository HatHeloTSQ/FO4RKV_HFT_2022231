using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Models
{
    public class Artist
    {
        [Key]
        [Required]
        public string Name { get; set; }
        public int StudioID { get; set; }
        public Publisher Studio { get; set; }
        [JsonIgnore]
        public virtual ICollection<Song> Songs { get; set; }
        [Range(16,70)]
        public int Age { get; set; }

        public Artist(string name, int studioID, int age)
        {
            Name = name;
            StudioID = studioID;
            Songs = new HashSet<Song>();
            Age = age;
        }
    }
}
