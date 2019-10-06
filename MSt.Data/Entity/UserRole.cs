using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSt.Data.Entity
{
	/// <summary>
	/// Role that is possessed by an user
	/// </summary>
	public class UserRole
	{
		/// <summary>
		/// Roles guid
		/// </summary>
		[Key]
		public Guid RoleGuid { get; set; }

		/// <summary>
		/// Role object
		/// </summary>
		[ForeignKey("RoleGuid")]
		public Role Role { get; set; }

		/// <summary>
		/// User ID
		/// </summary>
		[Key]
		public Guid UserGuid { get; set; }

		/// <summary>
		/// User object
		/// </summary>
		[ForeignKey("UserGuid")]
		public User User { get; set; }
	}
}
