using ATLAPI.Models.MSSQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATLAPI.Data
{
    public class ShipmentContext : DbContext
    {
        public ShipmentContext(DbContextOptions<ShipmentContext> options) : base(options) { }
        public ShipmentContext() { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
    }
}
