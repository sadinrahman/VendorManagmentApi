using System.ComponentModel.DataAnnotations;

namespace VendorManagmentApi.Dto
{
	public class VendorContactAddDto
	{
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
	}
}
