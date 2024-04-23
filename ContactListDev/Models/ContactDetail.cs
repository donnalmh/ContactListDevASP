
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactListDev.Models
{
    public class ContactDetail
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public required string Name { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public required string Surname { get; set; }

        [Column(TypeName = "BIGINT")]
        public required long ContactNumber { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public required string EmailAddress { get; set; }

        [Column(TypeName = "DATE")]
        public required DateTime DateOfBirth { get; set; }
    }
}
