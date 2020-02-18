using System;

namespace Simplesoft
{
	/// <summary>
	/// Represents an interval defined by two integers whose values are non-positive.
	/// </summary>
	public struct NonPositiveIntegerInterval
	{
		/// <summary>
		/// Provides exceptions for <see cref="NonPositiveIntegerInterval"/> constructors.
		/// </summary>
		static public class ConstructorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the max argument value is greater than 0.
			/// </summary>
			public sealed class MaxInvalidException : Exception
			{
				internal MaxInvalidException() { }
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
		/// Provides exceptions for <see cref="NonPositiveIntegerInterval"/> implicit operators.
		/// </summary>
		static public class ImplicitOperatorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the right bound of the interval argument value is greater than 0.
			/// </summary>
			public sealed class MaxInvalidException : Exception
			{
				internal MaxInvalidException() { }
			}
		}
		/// <summary>
		/// Provides exceptions for <see cref="NonPositiveIntegerInterval"/> minus operator.
		/// </summary>
		static public class MinusOperatorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the left bound of the interval argument value equals to <see cref="Integer.MinValue"/>.
			/// </summary>
			public sealed class MinInvalidException : Exception
			{
				internal MinInvalidException() { }
			}
		}

		/// <summary>
		/// Converts an <see cref="IntegerInterval"/> to a <see cref="NonPositiveIntegerInterval"/>.
		/// </summary>
		/// <param name="value">The <see cref="IntegerInterval"/>.</param>
		/// <exception cref="ImplicitOperatorExceptions.MaxInvalidException"/>
		static public implicit operator NonPositiveIntegerInterval(IntegerInterval value)
		{
			if (value.Max > 0x0)
				throw new ImplicitOperatorExceptions.MaxInvalidException();
			return new NonPositiveIntegerInterval
			{
				_min = value.Min,
				_max = value.Max
			};
		}
		/// <summary>
		/// Converts a <see cref="NonPositiveIntegerInterval"/> to an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonPositiveIntegerInterval"/>.</param>
		static public implicit operator IntegerInterval(NonPositiveIntegerInterval value)
		{
			return new IntegerInterval
			{
				_min = value.Min,
				_max = value.Max
			};
		}

		/// <summary>
		/// Inverts a <see cref="NonPositiveIntegerInterval"/>.
		/// </summary>
		/// <param name="value">The <see cref="NonPositiveIntegerInterval"/>.</param>
		/// <returns>A symmetric <see cref="NonNegativeIntegerInterval"/> of <paramref name="value"/>.</returns>
		/// <exception cref="MinusOperatorExceptions.MinInvalidException"/>
		static public NonNegativeIntegerInterval operator -(NonPositiveIntegerInterval value)
		{
			if (value._min == Integer.MinValue)
				throw new MinusOperatorExceptions.MinInvalidException();
			return new NonNegativeIntegerInterval
			{
				_min = -value.Max,
				_max = -value.Min
			};
		}

		internal Integer _min;
		internal Integer _max;

		/// <summary>
		/// Initializes the <see cref="NonPositiveIntegerInterval"/>
		/// </summary>
		/// <param name="min">The left bound of the <see cref="NonPositiveIntegerInterval"/>.</param>
		/// <param name="max">The right bound of the <see cref="NonPositiveIntegerInterval"/>.</param>
		/// <exception cref="ConstructorExceptions.MaxInvalidException"/>
		/// <exception cref="ConstructorExceptions.MinMaxInvalidException"/>
		public NonPositiveIntegerInterval(Integer min, Integer max)
		{
			if (max > 0x0)
				throw new ConstructorExceptions.MaxInvalidException();
			if (max < min)
				throw new ConstructorExceptions.MinMaxInvalidException();
			_min = min;
			_max = max;
		}

		/// <summary>
		/// Gets the left bound of the <see cref="NonPositiveIntegerInterval"/>.
		/// </summary>
		public Integer Min => _min;
		/// <summary>
		/// Gets the right bound of the <see cref="NonPositiveIntegerInterval"/>.
		/// </summary>
		public Integer Max => _max;
	}
}