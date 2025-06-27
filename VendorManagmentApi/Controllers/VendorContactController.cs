using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendorManagmentApi.Dto;
using VendorManagmentApi.Services.VendorContactServices;

namespace VendorManagmentApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VendorContactController : ControllerBase
	{
		private readonly IVendorContactService _service;
		public VendorContactController(IVendorContactService service)
		{
			_service = service;
		}
		[HttpGet("GetAllContactPersonByVendor/{id}")]
		public async Task<IActionResult> GetAllContactByVendorId(int id)
		{
			var response = await _service.GetAllContactPersonByVendor(id);
			if (response.Statuscode == 404)
			{
				return NotFound(response);
			}
			return Ok(response);
		}
		[HttpPost("AddVendorContactPerson")]
		public async Task<IActionResult> AddVendorContactPerson(VendorContactAddDto dto)
		{
			var response = await _service.AddVendorContactPerson(dto);
			if (response.Statuscode == 400)
			{
				return BadRequest(response);
			}
			else if (response.Statuscode == 500)
			{
				return StatusCode(500, response);
			}
			else
			{
				return Ok(response);
			}
		}
		[HttpDelete("DeleteVendorContactPerson/{id}")]
		public async Task<IActionResult> DeleteVendorContactPerson(int id)
		{
			var response=await _service.DeleteVendorContactPerson(id);
			if (response.Statuscode == 404)
			{
				return NotFound(response);
			}
			else if (response.Statuscode == 500)
			{
				return StatusCode(500, response);
			}
			else
			{
				return Ok(response);
			}
		}
	}
}
