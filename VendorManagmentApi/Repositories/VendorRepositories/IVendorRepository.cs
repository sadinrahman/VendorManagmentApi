using VendorManagmentApi.Models;

namespace VendorManagmentApi.Repositories.VendorRepositories
{
	public interface IVendorRepository
	{
		Task<List<Vendor>> GetAllVendorsAsync();
		Task<Vendor> GetVendorByIdAsync(int id);
		Task<bool> AddVendorAsync(Vendor vendor);
		Task<bool> UpdateVendorasync(Vendor vendor);
		Task<bool> DeleteVendorAsync(Vendor vendor);
	}
}
