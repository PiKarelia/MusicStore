using System;
using System.ComponentModel.DataAnnotations;

namespace MSt.Data.Entity
{
	/// <summary>
	/// Base class with neccessary properties for role and user claims
	/// </summary>
	public class Claim
	{
		/// <summary>
		/// Guid of any extended object from this
		/// </summary>
		[Key]
		public Guid Guid { get; set; }

		/// <summary>
		/// Type of Claim
		/// </summary>
		[Required]
		public virtual string ClaimType { get; set; }

		/// <summary>
		/// Value of Claim
		/// </summary>
		[Required]
		public virtual string ClaimValue { get; set; }
	}
}
