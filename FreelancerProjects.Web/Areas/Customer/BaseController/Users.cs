using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authorization {
	public static class Users {
		public static string GetUserID(this ClaimsPrincipal user) {
			return user.FindFirst(ClaimTypes.NameIdentifier).Value;
		}

		public static string GetUserEmail(this ClaimsPrincipal user) {
			return user.FindFirst(ClaimTypes.Email).Value;
		}
	}
}