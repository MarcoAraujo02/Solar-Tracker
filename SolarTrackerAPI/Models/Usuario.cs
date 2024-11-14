using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solar_Tracker.SolarTrackerAPI.Models
{
    public class Usuario
    {

        [Key]
        public int IdUsuario { get; set; }

        [Column("nm_usuario")]
        public string Nome { get; set; } = string.Empty;

        [Column("cd_senha")]
        public string Senha { get; set; } = string.Empty;

        [Column("ds_email")]
        public string Email { get; set; } = string.Empty;

    }
}
