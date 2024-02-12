using EFCoreTutoral.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutoral.Context
{
    public partial class EfCoreContext
    {
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
