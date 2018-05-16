using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.Web.DTO
{
    public class MusicRequest
    {
        public int? ID { get; set; }
        
        public string Name { get; set; }

        public GenreRequest Genre { get; set; }

        public ArtistRequest Artist { get; set; }
        
    }
}
