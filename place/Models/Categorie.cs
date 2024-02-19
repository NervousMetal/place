using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace place.Models
{
    public class Categorie
    {
        [Key] //clé primaire de la table.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//pas généré automatiquement
        [Column("cat_id")] //nom de la colonne
        public int CatId { get; set; }

        [Required] //not null dans la bd
        [StringLength(200)]
        [Column("cat_name")]
        public string CatName { get; set; }

        public ICollection<Publication> Publications { get; set; }
    }
}
