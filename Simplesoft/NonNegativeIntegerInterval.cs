using System;

namespace Simplesoft
{
	/// <summary>
	/// Represents an interval defined by two 64-bit signed integers whose values are non-negative.
	/// </summary>
	public struct NonNegativeIntegerInterval
	{
		/// <summary>
		/// Provides exceptions for <see cref="NonNegativeIntegerInterval"/> constructors.
		/// </summary>
		static public class ConstructorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the min argument value is less than 0.
			/// </summary>
			public sealed class MinInvalidException : Exception
			{
				internal MinInvalidException() { }
			}
			/// <summary>
			/// Represents the exception that is thrown when the min argument value is less than the max argument value.
			/// </summary>
			public sealed class MinMaxInvalidException : Exception
			{
				internal MinMaxInvalidException() { }
			}
		}
		/// <summary>
		/// Provides exceptions for <see cref="NonNegativeIntegerInterval"/> implicit operators.
		/// </summary>
		static public class ImplicitOperatorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the left bound of the interval argument value is less than 0.
			/// </summary>
			public sealed class MinInvalidException : Exception
			{
				internal MinInvalidException() { }
			}
		}

		/// <summary>
		/// Converts an <see cref="IntegerInterval"/> to a <see cref="NonNegativeIntegerInterval"/>.
		/// </summary>
		/// <param name="value">The <see cref="IntegerInterval"/>.</param>
		/// <exception cref="ImplicitOperatorExceptions.MinInvalidException"/>
		static public implicit operator NonNegativeIntegerInterval(IntegerInterval value)
		{
			if (value.Min < 0x0)
				throw new ImplicitOperatorExceptions.MinInvalidException();
			return new NonNegativeIntegerInterval
			{
				_min = value.Min,
				_max = value.Max
			};
		}
		/// <summary>
		/// Converts a <see cref="NonNegativeIntegerInterval"/> to an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonNegativeIntegerInterval"/>.</param>
		static public implicit operator IntegerInterval(NonNegativeIntegerInterval value)
		{
			return new IntegerInterval
			{
				_min = value.Min,
				_max = value.Max
			};
		}

		/// <summary>
		/// Inverts a <see cref="NonNegativeIntegerInterval"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonNegativeIntegerInterval"/>.</param>
		/// <returns>A symmetric <see cref="NonPositiveIntegerInterval"/> of <paramref name="value"/>.</returns>
		static public NonPositiveIntegerInterval operator -(NonNegativeIntegerInterval value)
		{
			return new NonPositiveIntegerInterval
			{
				_min = -value.Max,
				_max = -value.Min
			};
		}

		internal Int64 _min;
		internal Int64 _max;

		/// <summary>
		/// Initializes the <see cref="NonNegativeIntegerInterval"/>
		/// </summary>
		/// <param name="min">The left bound of the <see cref="NonNegativeIntegerInterval"/>.</param>
		/// <param name="max">The right bound of the <see cref="NonNegativeIntegerInterval"/>.</param>
		/// <exception cref="ConstructorExceptions.MinInvalidException"/>
		/// <exception cref="ConstructorExceptions.MinMaxInvalidException"/>
		public NonNegativeIntegerInterval(Int64 min, Int64 max)
		{
			if (min < 0x0)
				throw new ConstructorExceptions.MinInvalidException();
			if (max < min)
				throw new ConstructorExceptions.MinMaxInvalidException();
			_min = min;
			_max = max;
		}

		/// <summary>
		/// Gets the left bound of the <see cref="NonNegativeIntegerInterval"/>.
		/// </summary>
		public Int64 Min => _min;
		/// <summary>
		/// Gets the right bound of the <see cref="NonNegativeIntegerInterval"/>.
		/// </summary>
		public Int64 Max => _max;
	}
}