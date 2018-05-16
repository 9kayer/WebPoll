using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPoll.Web.DTO
{
    public class ArtistResponse
    {
        public int? ID { get; set; }

        public string Name { get; set; }
        
    }
}