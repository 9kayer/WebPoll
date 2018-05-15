using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.Model.Models
{
    public class Genre : IModel
    {
        public int? ID { get; set; }
        public string Name { get; set; }


        public ICollection<Music> Musics { get; set; }

        public override bool Equals(object obj)
        {
            var genre = obj as Genre;
            return genre != null &&
                   ( EqualityComparer<int?>.Default.Equals(ID, genre.ID) || Name == genre.Name );
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
