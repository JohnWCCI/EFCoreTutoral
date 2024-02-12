using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EFCoreTutoral.Models
{
    [Table("AddressTBL")]
    public class AddressModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        private string address1;
        private string address2;
        private string city;
        private string state;
        private string zipCode;

        public AddressModel() { }

        public AddressModel( string address1, string address2, string city, string state, string zipCode)
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
        }

        public int Id { get => id; set => id = value; }

        [Required]
        [StringLength(200,ErrorMessage ="Address should not be greater then 200 characters")]
        public string Address1 { get => address1; set => address1 = value; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Address 2 is required")]
        [StringLength(200, ErrorMessage = "Address should not be greater then 200 characters")]
        public string Address2 { get => address2; set => address2 = value; }

        [StringLength(100)]
        public string City { get => city; set => city = value; }

        [StringLength(100)]
        public string State { get => state; set => state = value; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.PostalCode, ErrorMessage = "Invalid Postcode")]
        public string ZipCode { get => zipCode; set => zipCode = value; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
