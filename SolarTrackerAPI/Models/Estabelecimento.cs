using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solar_Tracker.SolarTrackerAPI.Models
{
    public class Estabelecimento
    {
        [Key]
        public int IdEstabelecimento { get; set; }


        [Column("nm_estabelecimento")]
        public string Nome { get; set; } = string.Empty;


        [Column("ds_localizacao")]
        public string Localizacao { get; set; } = string.Empty;

        [Column("id_usuario")]
        public int IdUsuario { get; set; }
    }
}
