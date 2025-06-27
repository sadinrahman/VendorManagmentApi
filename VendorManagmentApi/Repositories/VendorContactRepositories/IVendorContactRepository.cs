using VendorManagmentApi.Models;

namespace VendorManagmentApi.Repositories.VendorContactRepositories
{
	public interface IVendorContactRepository
	{
		Task<List<VendorContactPerson>> GetAllVendorContact(int id);
		Task<VendorContactPerson> GetVendorContactById(int id);
		Task<bool> AddvendorContact(VendorContactPerson vendor);
		Task<bool> DeleteVendorContact(VendorContactPerson vendor);
	}
}
