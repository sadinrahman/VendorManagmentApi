using VendorManagmentApi.Dto;
using VendorManagmentApi.Helper;
using VendorManagmentApi.Models;
using VendorManagmentApi.Repositories.VendorRepositories;

namespace VendorManagmentApi.Services.VendorServices
{
	public class VendorService: IVendorService
	{
		private readonly IVendorRepository _repository;
		public VendorService(IVendorRepository repository)
		{
			_repository = repository;
		}
		public async Task<ApiResponse<List<VendorViewDto>>> GetAllVendors()
		{
			var vendors= await _repository.GetAllVendorsAsync();
			if (vendors == null || vendors.Count == 0)
			{
				return new ApiResponse<List<VendorViewDto>>(404, "No vendors found.");
			}
			var vendorDtos = vendors.Select(v => new VendorViewDto
			{
				Id = v.Id,
				PanNumber = v.PanNumber,
				vendorDescription = v.vendorDescription,
				VendorId = v.VendorId,
				FinanceVendorId = v.FinanceVendorId,
				VendorGroupName = v.VendorGroupName,
				VendorGroupId = v.VendorGroupId,
				VendorAddress1 = v.VendorAddress1,
				Address2 = v.Address2,
				BuildingNo = v.BuildingNo,
				City = v.City,
				State = v.State,
				ZipCode = v.ZipCode
			}).ToList();
			
			return new ApiResponse<List<VendorViewDto>>(200, "Vendors retrieved successfully.", vendorDtos);
		}
		public async Task<ApiResponse<VendorViewDto>> GetVendorById(int id)
		{
			var vendor=await _repository.GetVendorByIdAsync(id);
			if (vendor == null)
			{
				return new ApiResponse<VendorViewDto>(404, "Vendor not found.");
			}
			var vendorDto = new VendorViewDto
			{
				Id = vendor.Id,
				PanNumber = vendor.PanNumber,
				vendorDescription = vendor.vendorDescription,
				VendorId = vendor.VendorId,
				FinanceVendorId = vendor.FinanceVendorId,
				VendorGroupName = vendor.VendorGroupName,
				VendorGroupId = vendor.VendorGroupId,
				VendorAddress1 = vendor.VendorAddress1,
				Address2 = vendor.Address2,
				BuildingNo = vendor.BuildingNo,
				City = vendor.City,
				State = vendor.State,
				ZipCode = vendor.ZipCode
			};
			return new ApiResponse<VendorViewDto>(200, "Vendor retrieved successfully.", vendorDto);
		}
		public async Task<ApiResponse<VendorAddDto>> AddVendor(VendorAddDto vendor)
		{
			if(vendor == null)
			{
				return new ApiResponse<VendorAddDto>(400, "Invalid vendor data.");
			}
			var newvendor = new Vendor
			{
				PanNumber = vendor.PanNumber,
				vendorDescription = vendor.vendorDescription,
				VendorId = vendor.VendorId,
				FinanceVendorId = vendor.FinanceVendorId,
				VendorGroupName = vendor.VendorGroupName,
				VendorGroupId = vendor.VendorGroupId,
				VendorAddress1 = vendor.VendorAddress1,
				Address2 = vendor.Address2,
				BuildingNo = vendor.BuildingNo,
				City = vendor.City,
				State = vendor.State,
				ZipCode = vendor.ZipCode
			};
			var addedVendor = await _repository.AddVendorAsync(newvendor);
			if (addedVendor == false)
			{
				return new ApiResponse<VendorAddDto>(500, "Failed to add vendor.");
			}
			return new ApiResponse<VendorAddDto>(201, "Vendor added successfully.", vendor);
		}
		public async Task<ApiResponse<string>> UpdateVendor(VendorUpdateDto dto)
		{
			var existingVendor = await _repository.GetVendorByIdAsync(dto.Id);
			if (existingVendor == null)
			{
				return new ApiResponse<string>(404, "Vendor not found.");
			}
			existingVendor.PanNumber = dto.PanNumber ?? existingVendor.PanNumber;
			existingVendor.vendorDescription = dto.vendorDescription ?? existingVendor.vendorDescription;
			existingVendor.VendorId = dto.VendorId ?? existingVendor.VendorId;
			existingVendor.FinanceVendorId = dto.FinanceVendorId ?? existingVendor.FinanceVendorId;
			existingVendor.VendorGroupName = dto.VendorGroupName ?? existingVendor.VendorGroupName;
			existingVendor.VendorGroupId = dto.VendorGroupId != 0 ? dto.VendorGroupId : existingVendor.VendorGroupId;
			existingVendor.VendorAddress1 = dto.VendorAddress1 ?? existingVendor.VendorAddress1;
			existingVendor.Address2 = dto.Address2 ?? existingVendor.Address2;
			existingVendor.BuildingNo = dto.BuildingNo ?? existingVendor.BuildingNo;
			existingVendor.City = dto.City ?? existingVendor.City;	
			existingVendor.State = dto.State ?? existingVendor.State;
			existingVendor.ZipCode = dto.ZipCode ?? existingVendor.ZipCode;
			var updatedvendor=await _repository.UpdateVendorasync(existingVendor);
			if (updatedvendor == false)
			{
				return new ApiResponse<string>(500, "Failed to update vendor.");
			}
			return new ApiResponse<string>(200, "Vendor updated successfully.","Vendor Updated Successfully");
		}
		public async Task<ApiResponse<string >> DeleteVendor(int id)
		{
			var vendor=await _repository.GetVendorByIdAsync(id);
			if (vendor == null)
			{
				return new ApiResponse<string>(404, "Vendor not found.");
			}
			var deletedVendor = await _repository.DeleteVendorAsync(vendor);
			if (deletedVendor == false)
			{
				return new ApiResponse<string>(500, "Failed to delete vendor.");
			}
			return new ApiResponse<string>(200, "Vendor deleted successfully.", "Vendor Deleted Successfully");
		}
	}
}
