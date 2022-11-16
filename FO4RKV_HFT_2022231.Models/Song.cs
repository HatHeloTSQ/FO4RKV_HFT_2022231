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
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
        [Range(0,1200)]
        public int Length { get; set; }
        public int StudioID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongID { get; set; }
    }
}
