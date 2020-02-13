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
		/// Converts an <see cref="long"/> to a <see cref="NonPositiveInteger"/>.
		/// </summary>
		/// <param name="value">The <see cref="long"/>.</param>
		/// <exception cref="ImplicitOperatorExceptions.ValueInvalidException"/>
		static public implicit operator NonPositiveInteger(long value)
		{
			if (value > 0x0)
				throw new ImplicitOperatorExceptions.ValueInvalidException();
			return new NonPositiveInteger { _value = value };
		}
		/// <summary>
		/// Converts a <see cref="NonPositiveInteger"/> to an <see cref="long"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonPositiveInteger"/>.</param>
		static public implicit operator long(NonPositiveInteger value) => value._value;
		/// <summary>
		/// Inverts a <see cref="NonPositiveInteger"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonPositiveInteger"/>.</param>
		/// <returns>An additive inverse of <paramref name="value"/>.</returns>
		static public NonNegativeInteger operator -(NonPositiveInteger value) => new NonNegativeInteger { _value = -value._value };

		internal long _value;
	}
}