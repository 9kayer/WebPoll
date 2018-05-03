using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.DTO
{
    public class MusicDTO
    {
        public int? ID { get; set; }
                
        public string Name { get; set; }

        public GenderDTO Gender { get; set; }

        public ArtistDTO Artist { get; set; }
    }
}
