using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace place.Models
{

    public class Utilisateur
    {

        [Key] //clé primaire de la table.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //généré automatiquement
        [Column("user_id")] //nom de la colonne
        public int UserId { get; set; }

        [Required] //not null dans la bd
        [EmailAddress]
        [StringLength(200)]
        [Column("user_email")]
        public string Email { get; set; }


        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Column("user_password")]
        public string Password { get; set; }


        [Required]
        [StringLength(45)]
        [Column("user_l_name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(45)]
        [Column("user_f_name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [StringLength(45)]
        [Column("user_role")]
        public string Role { get; set; }

        //Ne sera pas affiché dans la bd
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }



        public ICollection<Publication> Publications { get; set; }



    }
}
