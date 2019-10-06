using System;

namespace MSt.Data.Entity
{
	/// <summary>
	/// Claim per role entity
	/// </summary>
	public class RoleClaim : Claim
	{
		/// <summary>
		/// Role of Claim
		/// </summary>
		public Guid RoleGuid { get; set; }

		/// <summary>
		/// Role object of the claim
		/// </summary>
		public Role Role { get; set; }
	}
}
