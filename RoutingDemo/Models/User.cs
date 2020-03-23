using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutingDemo.Models
{
    [Table("tbl_User")]
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Master_Roles Role { get; set; }


    }
}