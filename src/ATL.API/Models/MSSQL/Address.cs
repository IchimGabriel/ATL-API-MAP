using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATLAPI.Models.MSSQL
{
    public class Address
    {
        [Key]
        public Guid Address_Id { get; set; }
        public Guid User_Id { get; set; }
        public string Field_1 { get; set; }
        public string Field_2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
