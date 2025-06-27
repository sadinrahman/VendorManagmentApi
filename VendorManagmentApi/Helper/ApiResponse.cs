namespace VendorManagmentApi.Helper
{
	public class ApiResponse<T> where T : class
	{
		public int Statuscode { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }
		public ApiResponse(int statuscode, string message, T data=default)
		{
			Statuscode = statuscode;
			Message = message;
			Data = data;
		}
	}
}
