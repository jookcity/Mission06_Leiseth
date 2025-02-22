using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }  // Primary key
        
        [Required]
        public string CategoryId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year cannot be before 1888.")]
        [Display(Name = "Year Released")]
        public int Year { get; set; }
        
        public string? Director { get; set; }
        
        public string? Rating { get; set; } 
        
        [Required]
        public bool Edited { get; set; } 
        
        public string? LentTo { get; set; }
        
        [Required]
        public bool CopiedToPlex { get; set; }
        
        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}