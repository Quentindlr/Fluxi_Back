using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("film")]
    public class Film
    {
        private int id;
        private string url;
        private int videoId;
        public Film()
        {
        }

        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("url")]
        public string Url { get => url; set => url = value; }

        [Column("video_id")]
        public int VideoId { get => videoId; set => videoId = value; }


        public Video Video { get; set; }
    }
}
