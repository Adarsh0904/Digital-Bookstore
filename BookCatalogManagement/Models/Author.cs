using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBookstoreManagement.Models
{
    public class Author
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorID { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="Author name cannot exceed 50 characters")]
        public string AuthorName { get; set; }
    }
}
