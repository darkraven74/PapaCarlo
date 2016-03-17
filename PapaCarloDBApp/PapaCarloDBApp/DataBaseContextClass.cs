using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PapaCarloDBApp
{
    public class DataBaseContext : DbContext
    {
            public DataBaseContext(): base("DbConnection"){ }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<EmployeeRight> EmployeeRights { get; set; }
            public DbSet<Position> Positions { get; set; }

            public DbSet<StoreCell> StoreCells { get; set; }
            public DbSet<Storehouse> Storehouses { get; set; }

            public DbSet<Product> Products { get; set; }

            public DbSet<Contractor> Contractors { get; set; }

            public DbSet<TechnologicalCard> TechnologicalCards { get; set; }
            public DbSet<ProductTechCard> ProductTechCards { get; set; }

            public DbSet<ContractSupply> ContractSupplys { get; set; }
            public DbSet<SupplyProduct> SupplyProducts { get; set; }
            public DbSet<ContractAccept> ContractAccepts { get; set; }
            public DbSet<AcceptProduct> AcceptProducts { get; set; }
            public DbSet<ContractMove> ContractMoves { get; set; }
            public DbSet<ContractShipment> ContractShipments { get; set; }
            public DbSet<ContractTechOperation> ContractTechOperations { get; set; }

            public DbSet<ReportBalance> ReportBalances { get; set; }
            public DbSet<ReportPredict> ReportPredicts { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            }
    }
   
}
