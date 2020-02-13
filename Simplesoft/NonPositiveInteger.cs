using System;

namespace Simplesoft
{
	/// <summary>
	/// Represents a non-positive 64-bit signed integer.
	/// </summary>
	public struct NonPositiveInteger
	{
		/// <summary>
		/// Provides exceptions for <see cref="NonPositiveInteger"/> implicit operators.
		/// </summary>
		static public class ImplicitOperatorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the value argument value is greater than 0.
			/// </summary>
			public sealed class ValueInvalidException : Exception
			{
				internal ValueInvalidException() { }
			}
		}

		/// <summary>
		/// Converts an <see cref="Int64"/> to a <see cref="NonPositiveInteger"/>.
		/// </summary>
		/// <param name="value">The <see cref="Int64"/>.</param>
		/// <exception cref="ImplicitOperatorExceptions.ValueInvalidException"/>
		static public implicit operator NonPositiveInteger(Int64 value)
		{
			if (value > 0x0)
				throw new ImplicitOperatorExceptions.ValueInvalidException();
			return new NonPositiveInteger { _value = value };
		}
		/// <summary>
		/// Converts a <see cref="NonPositiveInteger"/> to an <see cref="Int64"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonPositiveInteger"/>.</param>
		static public implicit operator Int64(NonPositiveInteger value) => value._value;
		/// <summary>
		/// Inverts a <see cref="NonPositiveInteger"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonPositiveInteger"/>.</param>
		/// <returns>An additive inverse of <paramref name="value"/>.</returns>
		static public NonNegativeInteger operator -(NonPositiveInteger value) => new NonNegativeInteger { _value = -value._value };

		internal Int64 _value;
	}
}