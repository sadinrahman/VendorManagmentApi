using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendorManagmentApi.Dto;
using VendorManagmentApi.Services.VendorServices;

namespace VendorManagmentApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VendorController : ControllerBase
	{
		private readonly IVendorService _services;
		public VendorController(IVendorService service)
		{
			_services = service;
		}
		[HttpGet("GetAllVendors")]
		public async Task<IActionResult> GetAllVendors()
		{
			var response = await _services.GetAllVendors();
			if (response.Statuscode == 404)
			{
				return NotFound(response);
			}
			return Ok(response);
		}
		[HttpGet("GetVendorById/{id}")]
		public async Task<IActionResult> GetVendorById(int id)
		{
			var response = await _services.GetVendorById(id);
			if (response.Statuscode == 404)
			{
				return NotFound(response);
			}
			return Ok(response);
		}
		[HttpPost("AddVendor")]
		public async Task<IActionResult> AddVendor(VendorAddDto vendor)
		{
			var response = await _services.AddVendor(vendor);
			if (response.Statuscode == 400)
			{
				return BadRequest(response);
			}
			else if (response.Statuscode == 500)
			{
				return StatusCode(500, response);
			}
			return Ok(response);
		}
		[HttpPatch("UpdateVendor")]
		public async Task<IActionResult> UpdateVendor(VendorUpdateDto dto)
		{
			var response=await _services.UpdateVendor(dto);
			if (response.Statuscode == 404)
			{
				return NotFound(response);
			}
			else if (response.Statuscode == 500)
			{
				return StatusCode(500,response);
			}
			else
			{
				return Ok(response);
			}
		}
		[HttpDelete("DeleteVendor/{id}")]
		public async Task<IActionResult> DeleteVendor(int id)
		{
			var response = await _services.DeleteVendor(id);
			if (response.Statuscode == 404)
			{
				return NotFound(response);
			}
			else if (response.Statuscode == 500)
			{
				return StatusCode(500, response);
			}
			return Ok(response);
		}
	}
}
