using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public abstract class LibraryAsset
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public string Cost { get; set; }
        
        public string ImageUrl { get; set; }
        
        public string NumberOfCopies { get; set; }

        [Required]
        public virtual LibraryBranch Location { get; set; }
    }
}
