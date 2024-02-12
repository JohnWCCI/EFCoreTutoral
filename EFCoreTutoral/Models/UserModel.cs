using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EFCoreTutoral.Models
{
    [Table("UserTBL")]
    [Index(nameof(LastName), nameof(FirstName), IsUnique=false)]
    [Index(nameof(EmailAddress),IsUnique =true)]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        private string firstName = null!;
        private string lastName = null!; 
        private string emailAddress = null!;

        public UserModel() { 
        }

        public UserModel( string firstName, string lastName, string emailAddress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
        }

        public int Id { get => id; set => id = value; }

        [Required]
        [StringLength(50)]
        public string FirstName { get => firstName; set => firstName = value; }

        [Required]
        [StringLength(50)]
        public string LastName { get => lastName; set => lastName = value; }

        [NotMapped]
        public string FullName { get => $"{LastName}, {firstName}";  }

        [StringLength(500)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required]
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }


        public int? AddressID { get; set; }

        [ForeignKey("AddressID")] 
        public virtual AddressModel AddressModel { get; set; }

        public int? BillingAddressID { get; set; }

        [ForeignKey("BillingAddressID")]
        public virtual AddressModel BillAddress { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
