using VendorManagmentApi.Dto;
using VendorManagmentApi.Helper;
using VendorManagmentApi.Models;

namespace VendorManagmentApi.Services.VendorContactServices
{
	public interface IVendorContactService
	{
		Task<ApiResponse<List<VendorContactPerson>>> GetAllContactPersonByVendor(int id);
		Task<ApiResponse<string>> AddVendorContactPerson(VendorContactAddDto dto);
		Task<ApiResponse<string>> DeleteVendorContactPerson(int id);
	}
}
