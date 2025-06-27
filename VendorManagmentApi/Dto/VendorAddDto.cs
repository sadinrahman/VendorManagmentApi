using System.ComponentModel.DataAnnotations;

namespace VendorManagmentApi.Dto
{
	public class VendorAddDto
	{
		[Required]
		[StringLength(10)]
		public string PanNumber { get; set; }
		[Required]
		public string vendorDescription { get; set; }
		public string VendorId { get; set; } = null;
		public string FinanceVendorId { get; set; } = null;
		public string VendorGroupName { get; set; } = null;
		public int VendorGroupId { get; set; }
		[Required]
		public string VendorAddress1 { get; set; }
		public string Address2 { get; set; } = null;
		public string BuildingNo { get; set; } = null;
		[Required]
		public string City { get; set; }
		[Required]
		public string State { get; set; }
		[Required]
		[MinLength(6)]
		public string ZipCode { get; set; }
	}
}
