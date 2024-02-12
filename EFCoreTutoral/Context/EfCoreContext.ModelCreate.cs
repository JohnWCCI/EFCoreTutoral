using EFCoreTutoral.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutoral.Context
{
    public partial class EfCoreContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressModel>().HasData(
                new AddressModel()
                {
                    Id= 1,
                    Address1 = "123 Main st",
                    Address2 = "Apt 5",
                    City = "NewCity",
                    State = "Ohio",
                    ZipCode= "43224"
                },
                new AddressModel()
                {
                    Id = 2,
                    Address1 = "123 Addres 2",
                    Address2 = "Apt 5",
                    City = "NewCity",
                    State = "Ohio",
                    ZipCode = "43224"
                }
                );
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    AddressID = 1,
                    BillingAddressID = 2,
                    EmailAddress = "John@noWay.com"
                });
        }
    }
}
