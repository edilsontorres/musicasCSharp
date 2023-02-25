using System.ComponentModel.DataAnnotations;

namespace Musica.Models
{
    public class MusicaModel
    {
        [Key]
        public int Id { get; set; }

        public string? NomeArtista { get; set; }

        public string? NomeMusica { get;  set; }

        public DateTime Data { get; set; }
    }
}