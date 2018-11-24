using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Patron
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        public LibraryCard LibraryCard { get; set; }
        public LibraryBranch HomeLibraryBranch { get; set; }


    }
}
