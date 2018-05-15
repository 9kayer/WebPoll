using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.Repository.EntityModel
{
    public class Music
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [Required]
        public int GenreID { get; set; }

        [Required]
        public int ArtistID { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("GenreID")]
        public Genre Genre { get; set; }

        [ForeignKey("ArtistID")]
        public Artist Artist { get; set; }
    }
}
