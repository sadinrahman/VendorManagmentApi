using VendorManagmentApi.Dto;
using VendorManagmentApi.Helper;
using VendorManagmentApi.Models;
using VendorManagmentApi.Repositories.VendorContactRepositories;
using VendorManagmentApi.Repositories.VendorRepositories;

namespace VendorManagmentApi.Services.VendorContactServices
{
	public class VendorContactService: IVendorContactService
	{
		private readonly IVendorContactRepository _repository;
		private readonly IVendorRepository _vendor;
		public VendorContactService(IVendorContactRepository repository,IVendorRepository vendor)
		{
			_repository = repository;
			_vendor = vendor;
		}
		public async Task<ApiResponse<List<VendorContactPerson>>> GetAllContactPersonByVendor(int id)
		{
			var conatactPersons = await _repository.GetAllVendorContact(id);
			if (conatactPersons == null || conatactPersons.Count == 0)
			{
				return new ApiResponse<List<VendorContactPerson>>(404, "No contact persons found for this vendor.");
			}
			return new ApiResponse<List<VendorContactPerson>>(200, "Contact persons retrieved successfully.", conatactPersons);
		}
		public async Task<ApiResponse<string>> AddVendorContactPerson(VendorContactAddDto dto)
		{
			if (dto == null)
			{
			return new ApiResponse<string>(400, "Invalid contact person data.");
			}
			var vendor = await _vendor.GetVendorByIdAsync(dto.VendorId);
			if (vendor == null)
			{
				return new ApiResponse<string>(404, "Vendor not found.");
			}
			var newContactPerson = new VendorContactPerson
			{
				Name=dto.Name,
				MobileNumber=dto.MobileNumber,
				Email=dto.Email,
				VendorId=dto.VendorId
			};
			var addedContactPerson = await _repository.AddvendorContact(newContactPerson);
			if (!addedContactPerson)
			{
				return new ApiResponse<string>(500, "Failed to add contact person.");
			}
			return new ApiResponse<string>(201, "Contact person added successfully.");
		}
		public async Task<ApiResponse<string>> DeleteVendorContactPerson(int id)
		{
			var contactPerson = await _repository.GetVendorContactById(id);
			if (contactPerson == null)
			{
				return new ApiResponse<string>(404, "Contact person not found.");
			}
			var deleted = await _repository.DeleteVendorContact(contactPerson);
			if (!deleted)
			{
				return new ApiResponse<string>(500, "Failed to delete contact person.");
			}
			return new ApiResponse<string>(200, "Contact person deleted successfully.");
		}
	}
}
