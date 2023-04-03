using System.ComponentModel.DataAnnotations;

namespace AutomationBotAPI.Models
{
    public class Automation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(500, ErrorMessage = "The field 'TITLE' have to be the maximum of 500 characters")]

        public string ?Title { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "The field 'AREA' have to be the maximum of 500 characters")]

        public string ?Area { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "The field 'AUTHOR' have to be the maximum of 500 characters")]

        public string ?Author { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(3000, ErrorMessage = "The field 'DESCRIPTION' have to be the maximum of 500 characters")]

        public string ?Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(500, ErrorMessage = "The field 'PUBLICATIONDATE' have to be the maximum of 500 characters")]

        public string ?PublicationDate { get; set; }
    }
}
