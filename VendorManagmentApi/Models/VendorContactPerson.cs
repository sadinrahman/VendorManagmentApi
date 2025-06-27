using System.ComponentModel.DataAnnotations;

namespace VendorManagmentApi.Models
{
	public class VendorContactPerson
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[StringLength(10)]
		public string MobileNumber { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public int VendorId { get; set; }
		public Vendor Vendor { get; set; } 
	}
}
