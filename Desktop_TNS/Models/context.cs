using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    class context : DbContext
    {
        private static context _context;
        public context() : base("sql") { }
        public static context GetContext()
        {
            if (_context == null)
                _context = new context();
            return _context;
        }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<Magistral> Magistrals { get; set; }
        public DbSet<AccsessNetwork> AccsessNetworks { get; set; }
        public DbSet<AbontentEquipment> AbontentEquipments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}
