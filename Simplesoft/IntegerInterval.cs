using System;

namespace Simplesoft
{
	/// <summary>
	/// Represents an interval defined by two 64-bit signed integers.
	/// </summary>
	public struct IntegerInterval
	{
		/// <summary>
		/// Provides exceptions for <see cref="IntegerInterval"/> constructors.
		/// </summary>
		static public class ConstructorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the min argument value is less than the max argument value.
			/// </summary>
			public sealed class MinMaxInvalidException : Exception
			{
				internal MinMaxInvalidException() { }
			}
		}

		internal long _min;
		internal long _max;

		/// <summary>
		/// Initializes the <see cref="IntegerInterval"/>
		/// </summary>
		/// <param name="min">The left bound of the <see cref="IntegerInterval"/>.</param>
		/// <param name="max">The right bound of the <see cref="IntegerInterval"/>.</param>
		/// <exception cref="ConstructorExceptions.MinMaxInvalidException"/>
		public IntegerInterval(long min, long max)
		{
			if (max < min)
				throw new ConstructorExceptions.MinMaxInvalidException();
			_min = min;
			_max = max;
		}

		/// <summary>
		/// Gets the left bound of the <see cref="IntegerInterval"/>.
		/// </summary>
		public long Min => _min;
		/// <summary>
		/// Gets the right bound of the <see cref="IntegerInterval"/>.
		/// </summary>
		public long Max => _max;
	}
}