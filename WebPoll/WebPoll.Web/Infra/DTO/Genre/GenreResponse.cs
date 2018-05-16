using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.Web.DTO
{
    public class GenreResponse
    {
        public int? ID { get; set; }
        public string Name { get; set; }
    }
}
