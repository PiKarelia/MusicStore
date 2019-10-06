using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSt.Data.Entity
{
	/// <summary>
	/// Role that can have a user
	/// </summary>
	public class Role
	{
		/// <summary>
		/// Role ID
		/// </summary>
		[Key]
		public Guid Guid { get; set; }

		/// <summary>
		/// Name of Role
		/// </summary>
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// If Role is deleted
		/// </summary>
		public bool IsDeleted { get; set; }

		/// <summary>
		/// Collection of roles that have a user
		/// </summary>
		public ICollection<UserRole> UserRoles { get; set; }

		/// <summary>
		/// Collection of role claims of the user
		/// </summary>
		public ICollection<RoleClaim> RoleClaims { get; set; }
	}
}
