using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.Model.Models
{
    public class Music : IModel
    {
        public int? ID { get; set; }
        
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public Artist Artist { get; set; }

        public override bool Equals(object obj)
        {
            var music = obj as Music;
            return music != null &&
                   (    EqualityComparer<int?>.Default.Equals(ID, music.ID) ||
                        (   Name == music.Name &&
                            EqualityComparer<Genre>.Default.Equals(Genre, music.Genre) &&
                            EqualityComparer<Artist>.Default.Equals(Artist, music.Artist
                        ) 
                   ));
        }

        public override int GetHashCode()
        {
            var hashCode = -958924508;
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Genre>.Default.GetHashCode(Genre);
            hashCode = hashCode * -1521134295 + EqualityComparer<Artist>.Default.GetHashCode(Artist);
            return hashCode;
        }
    }
}
