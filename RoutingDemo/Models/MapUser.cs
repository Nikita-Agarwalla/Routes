using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutingDemo.Models
{
    [Table("tbl_MapUser")]
    public class MapUser
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Master_Roles Role { get; set; }
    }

}