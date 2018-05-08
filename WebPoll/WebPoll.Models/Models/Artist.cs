using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPoll.Model.Models
{
    public class Artist : IModel
    {
        public int? ID { get; set; }

        public string Name { get; set; }

        public ICollection<Music> Musics { get; set; }

        public void AddMusic(Music music)
        {
            Musics.Add(music);
        }

        public void RemoveMusic(Music music)
        {
            Musics.Remove(music);
        }

        public override bool Equals(object obj)
        {
            var artist = obj as Artist;
            return artist != null &&
                   ( EqualityComparer<int?>.Default.Equals(ID, artist.ID) || Name == artist.Name );
        }

        public override int GetHashCode()
        {
            var hashCode = 1204972891;
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Music>>.Default.GetHashCode(Musics);
            return hashCode;
        }
    }
}