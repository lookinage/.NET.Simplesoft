using System;

namespace Simplesoft
{
	/// <summary>
	/// Represents a non-negative 64-bit signed integer.
	/// </summary>
	public struct NonNegativeInteger
	{
		/// <summary>
		/// Provides exceptions for <see cref="NonNegativeInteger"/> implicit operators.
		/// </summary>
		static public class ImplicitOperatorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the value argument value is less than 0.
			/// </summary>
			public sealed class ValueInvalidException : Exception
			{
				internal ValueInvalidException() { }
			}
		}

		/// <summary>
		/// Converts an <see cref="long"/> to a <see cref="NonNegativeInteger"/>.
		/// </summary>
		/// <param name="value">The <see cref="long"/>.</param>
		/// <exception cref="ImplicitOperatorExceptions.ValueInvalidException"/>
		static public implicit operator NonNegativeInteger(long value)
		{
			if (value < 0x0)
				throw new ImplicitOperatorExceptions.ValueInvalidException();
			return new NonNegativeInteger { _value = value };
		}
		/// <summary>
		/// Converts a <see cref="NonNegativeInteger"/> to an <see cref="long"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonNegativeInteger"/>.</param>
		static public implicit operator long(NonNegativeInteger value) => value._value;
		/// <summary>
		/// Inverts a <see cref="NonNegativeInteger"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonNegativeInteger"/>.</param>
		/// <returns>An additive inverse of <paramref name="value"/>.</returns>
		static public NonPositiveInteger operator -(NonNegativeInteger value) => new NonPositiveInteger { _value = -value._value };

		internal long _value;
	}
}