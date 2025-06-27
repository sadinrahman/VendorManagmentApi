using System.ComponentModel.DataAnnotations;

namespace VendorManagmentApi.Dto
{
	public class VendorViewDto
	{
		public int Id { get; set; }
		public string? PanNumber { get; set; }
		public string? vendorDescription { get; set; }
		public string? VendorId { get; set; }
		public string? FinanceVendorId { get; set; }
		public string? VendorGroupName { get; set; }
		public int VendorGroupId { get; set; }

		public string? VendorAddress1 { get; set; }
		public string? Address2 { get; set; }
		public string? BuildingNo { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? ZipCode { get; set; }
	}
}
