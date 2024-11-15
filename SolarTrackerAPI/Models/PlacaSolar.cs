﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace Solar_Tracker.SolarTrackerAPI.Models
{
    public class PlacaSolar
    {
        [Key]
        public int idPlacaSolar { get; set; }


        [Column("ds_placa_solar")]
        public string Descricao { get; set; } = string.Empty;


        [Column("st_placa_solar")]
        public Status Status { get; set; }


        [Column("Id_estabelecimento")]
        public int IdEstabelecimento { get; set; }
    }
}
