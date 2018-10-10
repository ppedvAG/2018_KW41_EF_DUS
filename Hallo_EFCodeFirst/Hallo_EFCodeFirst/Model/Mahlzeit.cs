using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hallo_EFCodeFirst.Model
{
    [Table("Essen")]
    public class Mahlzeit : Entity
    {
        [Column("Tierdings")]
        [MaxLength(89)]
        public string Bezeichnung { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public HashSet<Tier> Tiere { get; set; } = new HashSet<Tier>();
    }
}
