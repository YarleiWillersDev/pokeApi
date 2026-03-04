using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAPI.Domain.Entities
{
    [Table("PokemonColorGroup")]
    public class PokemonColorGroup
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(45)]
        public string Color { get; set; } = null!;

        public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    };
}
