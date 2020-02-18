using System;

namespace Simplesoft
{
	/// <summary>
	/// Represents an integer.
	/// </summary>
	public struct Integer
	{
		/// <summary>
		/// Converts an <see cref="Integer"/> to an <see cref="Integer"/>.
		/// </summary>
		/// <param name="value">The <see cref="Integer"/>.</param>
		static public implicit operator Integer(Int64 value) => new Integer { _value = value };
		/// <summary>
		/// Converts an <see cref="Integer"/> to an <see cref="Integer"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonPositiveInteger"/>.</param>
		static public implicit operator Int64(Integer value) => value._value;

		/// <summary>
		/// The smallest possible integer value.
		/// </summary>
		public const Int64 MinValue = Int64.MinValue;
		/// <summary>
		/// The largest possible integer value.
		/// </summary>
		public const Int64 MaxValue = Int64.MaxValue;

		internal Int64 _value;
	}
}