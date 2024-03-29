﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudioID { get; set; }
        [StringLength(2)]
        public string Country { get; set; }
        [Required]
        public string StudioName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Artist> Artists { get; set; }

        public Publisher(string country, string studioName, int studioID)
        {
            Country = country;
            StudioName = studioName;
            StudioID = studioID;
            Artists = new HashSet<Artist>();
        }

        public Publisher()
        {

        }

        public Publisher(string country, string studioName)
        {
            Country = country;
            StudioName = studioName;
        }
    }
}
