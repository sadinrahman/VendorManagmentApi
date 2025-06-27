using Microsoft.EntityFrameworkCore;
using VendorManagmentApi.Models;

namespace VendorManagmentApi.DBContext
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{
		}
		public DbSet<Vendor> vendors { get; set; }
		public DbSet<VendorContactPerson> vendorContactPersons { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Vendor>()
				.HasMany(v => v.VendorContactPersons)
				.WithOne(o => o.Vendor)
				.HasForeignKey(o => o.VendorId);
		}
	}
}
