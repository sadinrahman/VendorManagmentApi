using Microsoft.EntityFrameworkCore;
using VendorManagmentApi.DBContext;
using VendorManagmentApi.Models;

namespace VendorManagmentApi.Repositories.VendorRepositories
{
	public class VendorRepository: IVendorRepository
	{
		private readonly AppDbContext _context;
		public VendorRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<List<Vendor>> GetAllVendorsAsync()
		{
			return await _context.vendors.Include(v => v.VendorContactPersons).ToListAsync();
		}
		public async Task<Vendor> GetVendorByIdAsync(int id)
		{
			return await _context.vendors.Include(c=>c.VendorContactPersons).FirstOrDefaultAsync(v => v.Id == id);
		}
		public async Task<bool> AddVendorAsync(Vendor vendor)
		{
			await _context.vendors.AddAsync(vendor);
			await _context.SaveChangesAsync();
			return true;
		}
		public async Task<bool> UpdateVendorasync(Vendor vendor)
		{
			_context.vendors.Update(vendor);
			await _context.SaveChangesAsync();
			return true;
		}
		public async Task<bool> DeleteVendorAsync(Vendor vendor)
		{
			_context.vendors.Remove(vendor);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
