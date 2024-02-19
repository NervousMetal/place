using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace place.Models
{
    public class Publication
    {
        [Key] //clé primaire de la table.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //généré automatiquement
        [Column("publication_id")] //nom de la colonne
        public int PublicationId { get; set; }

        [Required] //not null dans la bd
        [StringLength(500)]
        [Column("publication_title")]
        public string PublicationTitle { get; set; }

        [Required]
        [Column("publication_desc")]
        public string PublicationDescription { get; set; }

        [Column("publication_img")]
        public string PublicationImage { get; set; }

        [Required]
        [Column("publication_date")]
        public DateTime PublicationDate { get; set; }




        //Ajouter la géolocalisation<



        // Foreign Keys
        public int CatId { get; set; }
        [ForeignKey("CatId")]
        public Categorie Categorie { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Utilisateur Utilisateur { get; set; }

    }
}

