using AGL.Api.ApplicationCore.Models.Enum;
using Newtonsoft.Json;

namespace AGL.Api.ApplicationCore.Models
{
	public record AglAdminResult
	{
		public string result_code { get; set; } = string.Empty;
		public string result_message { get; set; } = string.Empty;

	}
	public record AglAdminAPI
	{
		public string uri { get; set; } = string.Empty;
		public string clientId { get; set; } = string.Empty;
		public string clientSecret { get; set; } = string.Empty;
	}
}
