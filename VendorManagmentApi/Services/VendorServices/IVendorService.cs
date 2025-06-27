using VendorManagmentApi.Dto;
using VendorManagmentApi.Helper;
using VendorManagmentApi.Models;

namespace VendorManagmentApi.Services.VendorServices
{
	public interface IVendorService
	{
		Task<ApiResponse<List<VendorViewDto>>> GetAllVendors();
		Task<ApiResponse<VendorViewDto>> GetVendorById(int id);
		Task<ApiResponse<VendorAddDto>> AddVendor(VendorAddDto vendor);
		Task<ApiResponse<string>> UpdateVendor(VendorUpdateDto dto);
		Task<ApiResponse<string>> DeleteVendor(int id);
	}
}
