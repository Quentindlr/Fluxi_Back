﻿using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("serie")]
    public class Serie
    {
        private int id;
        private string url;
        private int saison;
        private int episode;
        private int videoId;

        public Serie()
        {
        }
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("url")]
        public string Url { get => url; set => url = value; }
        [Column("saison")]
        public int Saison { get => saison; set => saison = value; }
        [Column("episode")]
        public int Episode { get => episode; set => episode = value; }

        [Column("video_id")]
        public int VideoId { get => videoId; set => videoId = value; }

        [ForeignKey("VideoId")]
        public Video Video { get; set; }
    }
}
