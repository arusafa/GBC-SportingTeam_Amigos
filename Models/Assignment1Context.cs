using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Team_Amigos.Models
{
    public class Assignment1Context : DbContext
    {
        public Assignment1Context(DbContextOptions<Assignment1Context> options)
            : base(options) { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 01, CountryName = "Canada" },
                new Country { CountryId = 02, CountryName = "Iran" },
                new Country { CountryId = 03, CountryName = "Turkey" },
                new Country { CountryId = 04, CountryName = "France" },
                new Country { CountryId = 05, CountryName = "The United States" },
                new Country { CountryId = 06, CountryName = "Spain" },
                new Country { CountryId = 07, CountryName = "Portugal" },
                new Country { CountryId = 08, CountryName = "The United Kingdom" },
                new Country { CountryId = 09, CountryName = "Greece" },
                new Country { CountryId = 10, CountryName = "Colombia" }
            );

            modelBuilder.Entity<Customer>().HasData(

                new Customer
                {
                    CustomerId = 0001,
                    Firstname = "Safa",
                    Lastname = "Aru",
                    Address = "Bourret Ave",
                    City = "Montreal",
                    State = "Quebec",
                    PostalCode = "H3W 1L4",
                    CountryId = 01,
                    Email = "Safa.Aru@georgebrown.ca",
                    Phone = "647-834-8928"
                },
                  new Customer
                  {
                      CustomerId = 0002,
                      Firstname = "Ebi",
                      Lastname = "Safdari",
                      Address = "446 Gilmour St",
                      City = "Ottawa",
                      State = "Otario",
                      PostalCode = "KP2 0R8",
                      CountryId = 01,
                      Email = "Ebrahim.Safdari@georgebrown.ca",
                      Phone = "6476-789-2035"
                  },
                    new Customer
                    {
                        CustomerId = 0003,
                        Firstname = "Elham",
                        Lastname = "Veisouei",
                        Address = "565 Lawrence Ave",
                        City = "Toronto",
                        State = "Ontario",
                        PostalCode = "M6A 1A5",
                        CountryId = 01,
                        Email = "Elham.Veisouei@georgebrown.ca",
                        Phone = "647-876-6989"
                    },
                     new Customer
                     {
                         CustomerId = 0004,
                         Firstname = "Hakan",
                         Lastname = "Inel",
                         Address = "1190 W 12th Ave",
                         City = "Vancouver",
                         State = "British Columbia",
                         PostalCode = "V6H 1L6",
                         CountryId = 01,
                         Email = "Hakan.Inel@georgebrown.ca",
                         Phone = "416-746-8900"
                     }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1111,
                    Code = "DFAFT10",
                    Name = "Draft Manager 1.0",
                    Price = 4.5,
                    ReleaseDate = DateTime.Parse("2018/01/14"),
                },
                new Product
                {
                    ProductId = 1112,
                    Code = "TEAM10",
                    Name = "Team Manager 1.0",
                    Price = 4.99,
                    ReleaseDate = DateTime.Parse("2019/01/15"),
                },
                 new Product
                 {
                     ProductId = 1113,
                     Code = "LEAG10",
                     Name = "League Scheduler Deluxe 1.0",
                     Price = 7.99,
                     ReleaseDate = DateTime.Parse("2019/02/16"),
                 },
                  new Product
                  {
                      ProductId = 1114,
                      Code = "DRAFT20",
                      Name = "Draft Manager 2.0",
                      Price = 5.99,
                      ReleaseDate = DateTime.Parse("2020/02/17"),
                  }
                );

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 2221,
                    CustomerId = 0001,
                    ProductId = 1111,
                    Title = "Error launching program",
                    Description = "Program fails with error, unable to launch the program.",
                    TechnicianId = 3333,
                    OpenDate = DateTime.Parse("2018/01/14"),
                    CloseDate = DateTime.Parse("2018/02/10")

                },
                 new Incident
                 {
                     IncidentId = 2222,
                     CustomerId = 0002,
                     ProductId = 1112,
                     Title = "Error importing data",
                     Description = "Program fails with error, unable to open import data.",
                     TechnicianId = 3334,
                     OpenDate = DateTime.Parse("2019/03/10"),
                     CloseDate = DateTime.Parse("2019/04/14")

                 },
                  new Incident
                  {
                      IncidentId = 2223,
                      CustomerId = 0003,
                      ProductId = 1113,
                      Title = "Could not install",
                      Description = "Program fails with error code 510, unable to open database.",
                      TechnicianId = 3335,
                      OpenDate = DateTime.Parse("2020/01/06"),
                      CloseDate = DateTime.Parse("2020/01/10")

                  },
                   new Incident
                   {
                       IncidentId = 2224,
                       CustomerId = 0004,
                       ProductId = 1114,
                       Title = "Could not install",
                       Description = "Program fails with error code 510, unable to open database.",
                       TechnicianId = 3336,
                       OpenDate = DateTime.Parse("2021/04/12"),
                       CloseDate = DateTime.Parse("2021/06/19")
                   }
                );

            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId = 3333,
                    Name = "Alison Diaz",
                    Email = "Alison.Diaz@gmail.com",
                    Phone = "243-768-9102"
                },
                new Technician
                {
                    TechnicianId = 3334,
                    Name = "Ali Ahmad",
                    Email = "Ali.Ahmad@gmail.com",
                    Phone = "468-990-1002"
                },
                new Technician
                {
                    TechnicianId = 3335,
                    Name = "Gina Friori",
                    Email = "Gina.Friori@gmail.com",
                    Phone = "567-356-3829"
                },
                new Technician
                {
                    TechnicianId = 3336,
                    Name = "Andrew Wendt",
                    Email = "Andrew.Wendt@gmail.com",
                    Phone = "467-389-2349"
                }
               );

            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    RegistrationId = 00001,
                    CustomerId = 0001,
                    ProductId = 1111
                },
                 new Registration
                 {
                     RegistrationId = 00002,
                     CustomerId = 0002,
                     ProductId = 1112
                 },
                  new Registration
                  {
                      RegistrationId = 00003,
                      CustomerId = 0003,
                      ProductId = 1113
                  },
                   new Registration
                   {
                       RegistrationId = 00004,
                       CustomerId = 0004,
                       ProductId = 1114
                   }
                );
        }
    }
}
