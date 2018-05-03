﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPoll.Model.Models
{
    public class Artist : IModel
    {
        public int? ID { get; set; }

        public string Name { get; set; }

        public ICollection<Music> MusicList { get; set; }

        public void AddMusic(Music music)
        {
            MusicList.Add(music);
        }

        public void RemoveMusic(Music music)
        {
            MusicList.Remove(music);
        }
    }
}