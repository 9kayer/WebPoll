using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.DTO
{
    public class ArtistDTO
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public ICollection<MusicDTO> MusicList { get; set; }
    }
}
