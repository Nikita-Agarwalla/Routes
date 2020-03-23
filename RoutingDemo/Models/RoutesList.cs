using System.ComponentModel.DataAnnotations.Schema;

namespace RoutingDemo.Models
{
    [Table("tbl_RouteList")]
    public class RoutesList
    {
        public int ID { get; set; }
        public string Route { get; set; }
    }
}