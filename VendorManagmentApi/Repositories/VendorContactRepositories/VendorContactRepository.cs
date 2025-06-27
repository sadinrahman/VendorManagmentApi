using Microsoft.EntityFrameworkCore;
using VendorManagmentApi.DBContext;
using VendorManagmentApi.Dto;
using VendorManagmentApi.Models;

namespace VendorManagmentApi.Repositories.VendorContactRepositories
{
	public class VendorContactRepository: IVendorContactRepository
	{
		private readonly AppDbContext _context;
		public VendorContactRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<List<VendorContactPerson>> GetAllVendorContact(int id)
		{
			return await _context.vendorContactPersons.Where(v => v.VendorId == id).ToListAsync();
		}
		public async Task<VendorContactPerson> GetVendorContactById(int id)
		{
			return await _context.vendorContactPersons.FirstOrDefaultAsync(v => v.Id == id);
		}
		public async Task<bool> AddvendorContact(VendorContactPerson vendor)
		{
			_context.vendorContactPersons.Add(vendor);
			await _context.SaveChangesAsync();
			return true;
		}
		public async Task<bool> DeleteVendorContact (VendorContactPerson vendor)
		{
			_context.vendorContactPersons.Remove(vendor);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
