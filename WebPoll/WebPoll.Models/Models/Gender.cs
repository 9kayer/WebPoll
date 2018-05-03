using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.Model.Models
{
    public class Gender : IModel
    {
        public int? ID { get; set; }
        public string Name { get; set; }
    }
}
