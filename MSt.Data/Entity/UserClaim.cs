using System;

namespace MSt.Data.Entity
{
	/// <summary>
	/// Particular claims per users
	/// </summary>
	public class UserClaim : Claim
	{
		/// <summary>
		/// User ID
		/// </summary>
		public Guid UserId { get; set; }

		/// <summary>
		/// User object
		/// </summary>
		public User User { get; set; }
	}
}
