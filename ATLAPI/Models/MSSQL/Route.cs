using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATLAPI.Models.MSSQL
{
    public class Route
    {
        [Key]
        public Guid Route_Id { get; set; }
        public string RouteNodes { get; set; }
        public int Total_KM { get; set; }
        public float Total_CO2 { get; set; }
        public int Total_Time { get; set; }  // hours  
    }
}
