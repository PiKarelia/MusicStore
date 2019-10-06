using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSt.Data.Entity
{
	/// <summary>
	/// User used to identify a authenticated user
	/// </summary>
	public class User
	{
		/// <summary>
		/// ID User
		/// </summary>
		[Key]
		public Guid Guid { get; set; }

		/// <summary>
		/// User Login
		/// </summary>
		[Required]
		[MaxLength(50)]
		public string Login { get; set; }

		/// <summary>
		/// Password for login
		/// </summary>
		[Required]
		[MaxLength(50)]
		public string Password { get; set; }

		/// <summary> 
		/// User email 
		/// </summary> 
		[Required]
		[MaxLength(50)]
		public string Email { get; set; }

		/// <summary>
		/// Collection of claims of the user
		/// </summary>
		public ICollection<UserClaim> UserClaims { get; set; }

		/// <summary>
		/// Collection of the roles of the user
		/// </summary>
		public ICollection<UserRole> UserRoles { get; set; }

		/// <summary> 
		/// If the user is deleted 
		/// </summary> 
		public bool IsDeleted { get; set; }
	}
}
