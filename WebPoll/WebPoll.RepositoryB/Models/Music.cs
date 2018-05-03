using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.RepositoryB.Models
{
    public class Music
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        public int GenderID { get; set; }
        
        public int ArtistID { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public Artist Artist { get; set; }
    }
}
