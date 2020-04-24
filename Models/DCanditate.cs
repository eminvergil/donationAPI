using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace donationAPI.Models
{
      public class DCanditate
      {
            [Key]
            public int Id { get; set; }

            [Column(TypeName = "varchar(100)")]
            public string fullname { get; set; }

            [Column(TypeName = "varchar(16)")]
            public string mobile { get; set; }

            [Column(TypeName = "varchar(100)")]
            public string email { get; set; }
            public int age { get; set; }

            [Column(TypeName = "varchar(3)")]
            public string bloodGroup { get; set; }

            [Column(TypeName = "varchar(100)")]
            public string address { get; set; }
      }
}