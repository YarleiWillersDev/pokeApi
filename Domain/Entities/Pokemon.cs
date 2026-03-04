using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PokeAPI.Domain.Entities;

namespace PokeAPI.Domain.Entities
{
    [Table("Pokemon")]
    public class Pokemon
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Especie { get; set; } = null!;

        public int ColorGroupId { get; set; }

        public PokemonColorGroup ColorGroup { get; set; } = null!;

    }
}