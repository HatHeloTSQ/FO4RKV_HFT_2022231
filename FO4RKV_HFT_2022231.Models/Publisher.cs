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
    public class Publisher
    {
        [StringLength(3)]
        public string Country { get; set; }
        public string StudioName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudioID { get; set; }
        [JsonIgnore]
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
