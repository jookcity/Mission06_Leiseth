using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }  // Primary key
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Category { get; set; }
        
        [Required]
        [Display(Name = "Year Released")]
        public int Year { get; set; }
        
        [Required]
        public string Director { get; set; }
        
        [Required]
        public string Rating { get; set; } 
        
        public bool Edited { get; set; } 
        
        public string LentTo { get; set; }
        
        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string Notes { get; set; }
    }
}