using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPoll.Repository.EntityModel
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [InverseProperty("Artist")]
        public ICollection<Music> Musics { get; set; }

        public void AddMusic(Music music)
        {
            Musics.Add(music);
        }

        public void RemoveMusic(Music music)
        {
            Musics.Remove(music);
        }
    }
}