//using System;
//using System.Security.Cryptography;

//namespace Simplesoft
//{
//	/// <summary>
//	/// Represents a pseudo-random data generator.
//	/// </summary>
//	static public class RandomManager
//	{
//		/// <summary>
//		/// Provides exceptions for <see cref="GetInteger()"/> and <see cref="GetInteger(IntegerInterval)"/> methods.
//		/// </summary>
//		static public class GetIntegerMethodExceptions
//		{
//			/// <summary>
//			/// Represents the exception that is thrown when the left bound of the interval argument equals to <see cref="long.MinValue"/>.
//			/// </summary>
//			public sealed class MinInvalidException : Exception
//			{
//				internal MinInvalidException() { }
//			}
//		}
//		/// <summary>
//		/// Provides exceptions for <see cref="GetNonPositiveInteger()"/>, <see cref="GetNonPositiveInteger(NonPositiveInteger)"/> and <see cref="GetNonPositiveInteger(NonPositiveIntegerInterval)"/> methods.
//		/// </summary>
//		static public class GetNonPositiveIntegerMethodExceptions
//		{
//			/// <summary>
//			/// Represents the exception that is thrown when the left bound of the interval argument equals to <see cref="long.MinValue"/>.
//			/// </summary>
//			public sealed class MinInvalidException : Exception
//			{
//				internal MinInvalidException() { }
//			}
//		}
//		/// <summary>
//		/// Provides exceptions for <see cref="GetIntegerRemainder(long)"/> method.
//		/// </summary>
//		static public class GetIntegerRemainderMethodExceptions
//		{
//			/// <summary>
//			/// Represents the exception that is thrown when the divider argument value is less than 1.
//			/// </summary>
//			public sealed class DividerInvalidException : Exception
//			{
//				internal DividerInvalidException() { }
//			}
//		}

//		private const long _bufferSize = 0x1000;

//		[ThreadStatic]
//		static private bool _initialized;
//		[ThreadStatic]
//		static private RNGCryptoServiceProvider _provider;
//		[ThreadStatic]
//		static private byte[] _buffer;
//		[ThreadStatic]
//		static private long _bufferOffset;

//		static private long GetNonPositiveIntegerInternal(NonPositiveInteger min) => GetNonPositiveInteger() % (min - 0x1);
//		static private long GetNonPositiveIntegerInternal(NonPositiveIntegerInterval interval) => interval.Max + GetNonPositiveIntegerInternal(interval.Min - interval.Max);
//		/// <summary>
//		/// Generates a pseudo-random <see cref="long"/>.
//		/// </summary>
//		/// <returns>A pseudo-random <see cref="long"/>.</returns>
//		static public long GetInteger()
//		{
//		Generate:
//			if (_initialized)
//			{
//				if (_bufferSize - _bufferOffset < sizeof(long))
//				{

//				}
//				return result;
//			}
//			_initialized = true;
//			_buffer = new byte[_bufferSize];
//			_provider = new RNGCryptoServiceProvider();
//		}
//		/// <summary>
//		/// Generates a pseudo-random <see cref="long"/> that is within an <see cref="IntegerInterval"/>.
//		/// </summary>
//		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
//		/// <returns>A pseudo-random <see cref="long"/> that is within an <see cref="IntegerInterval"/>.</returns>
//		/// <exception cref="GetIntegerMethodExceptions.MinInvalidException"/>
//		static public long GetInteger(IntegerInterval interval)
//		{
//			if (interval.Min == long.MinValue)
//				throw new GetIntegerMethodExceptions.MinInvalidException();
//			return (long)(interval.Max - ((long)long.MaxValue + GetInteger()) % (-0x1L + interval.Min - interval.Max));
//		}
//		/// <summary>
//		/// Generates a pseudo-random non-positive <see cref="long"/>.
//		/// </summary>
//		/// <returns>A pseudo-random non-positive <see cref="long"/>.</returns>
//		static public long GetNonPositiveInteger() => (long)((ulong)GetInteger() | 0x80000000);
//		/// <summary>
//		/// Generates a pseudo-random <see cref="long"/> that is greater than or equal to a <see cref="NonPositiveInteger"/>.
//		/// </summary>
//		/// <param name="min">The minimum value.</param>
//		/// <returns>A pseudo-random <see cref="long"/> that is greater than or equal to <paramref name="min"/>.</returns>
//		/// <exception cref="GetNonPositiveIntegerMethodExceptions.MinInvalidException"/>
//		static public long GetNonPositiveInteger(NonPositiveInteger min)
//		{
//			if (min == long.MinValue)
//				throw new GetNonPositiveIntegerMethodExceptions.MinInvalidException();
//			return GetNonPositiveIntegerInternal(min);
//		}
//		/// <summary>
//		/// Generates a pseudo-random <see cref="long"/> that is within a <see cref="NonPositiveIntegerInterval"/>.
//		/// </summary>
//		/// <param name="interval">The <see cref="NonPositiveIntegerInterval"/>.</param>
//		/// <returns>A pseudo-random <see cref="long"/> that is within <paramref name="interval"/>.</returns>
//		/// <exception cref="GetNonPositiveIntegerMethodExceptions.MinInvalidException"/>
//		static public long GetNonPositiveInteger(NonPositiveIntegerInterval interval)
//		{
//			if (interval.Min == long.MinValue)
//				throw new GetNonPositiveIntegerMethodExceptions.MinInvalidException();
//			return GetNonPositiveIntegerInternal(interval);
//		}
//		/// <summary>
//		/// Generates a pseudo-random non-negative <see cref="long"/>.
//		/// </summary>
//		/// <returns>A pseudo-random non-negative <see cref="long"/>.</returns>
//		static public long GetNonNegativeInteger() => (long)((ulong)GetInteger() & 0x7FFFFFFF);
//		/// <summary>
//		/// Generates a pseudo-random <see cref="long"/> that is less than or equal to a <see cref="NonNegativeInteger"/>.
//		/// </summary>
//		/// <param name="max">The maximum value.</param>
//		/// <returns>A pseudo-random <see cref="long"/> that is less than or equal to <paramref name="max"/>.</returns>
//		static public long GetNonNegativeInteger(NonNegativeInteger max) => -GetNonPositiveIntegerInternal(-max);
//		/// <summary>
//		/// Generates a pseudo-random <see cref="long"/> that is within a <see cref="NonNegativeIntegerInterval"/>.
//		/// </summary>
//		/// <param name="interval">The <see cref="NonPositiveIntegerInterval"/>.</param>
//		/// <returns>A pseudo-random <see cref="long"/> that is within <paramref name="interval"/>.</returns>
//		static public long GetNonNegativeInteger(NonNegativeIntegerInterval interval) => -GetNonPositiveIntegerInternal(-interval);
//		/// <summary>
//		/// Generates a remainder of positive pseudo-random number division by a divider.
//		/// </summary>
//		/// <param name="divider">The divider.</param>
//		/// <returns>A remainder of positive pseudo-random number division by <paramref name="divider"/>.</returns>
//		/// <exception cref="GetIntegerRemainderMethodExceptions.DividerInvalidException"/>
//		static public long GetIntegerRemainder(long divider)
//		{
//			if (divider < 0x1)
//				throw new GetIntegerRemainderMethodExceptions.DividerInvalidException();
//			return GetNonNegativeInteger() % divider;
//		}
//		/// <summary>
//		/// Generates a pseudo-random <see cref="float"/> that is greater than -1 and less than 1.
//		/// </summary>
//		/// <returns>A pseudo-random <see cref="float"/> that is greater than -1 and less than 1.</returns>
//		static public unsafe float GetSingleFloat()
//		{
//			ulong result;

//			result = (ulong)GetInteger() & 0xBFFFFFFF;
//			return *(float*)&result * 0.5F;
//		}
//		/// <summary>
//		/// Generates a pseudo-random <see cref="float"/> that is greater than -1 and less than or equal to 0.
//		/// </summary>
//		/// <returns>A pseudo-random <see cref="float"/> that is greater than -1 and less than 0.</returns>
//		static public unsafe float GetNonPositiveSingleFloat()
//		{
//			ulong result;

//			result = (ulong)GetNonPositiveInteger() & 0xBFFFFFFF;
//			return *(float*)&result * 0.5F;
//		}
//		/// <summary>
//		/// Generates a pseudo-random <see cref="float"/> that is greater than or equal to 0 and less than 1.
//		/// </summary>
//		/// <returns>A pseudo-random <see cref="float"/> that is greater than or equal to 0 and less than 1.</returns>
//		static public unsafe float GetNonNegativeSingleFloat()
//		{
//			ulong result;

//			result = (ulong)GetNonNegativeInteger() & 0xBFFFFFFF;
//			return *(float*)&result * 0.5F;
//		}
//		/// <summary>
//		/// Generates pseudo-random bytes.
//		/// </summary>
//		/// <param name="address">The memory address of the bytes.</param>
//		/// <param name="count">The number of the bytes.</param>
//		static public unsafe void GetBytes(byte* address, NonNegativeInteger count)
//		{
//			long ushortCount;
//			long uintCount;
//			long offset;

//			ushortCount = count >> 0x1;
//			uintCount = ushortCount >> 0x1;
//			for (offset = 0x0; offset != uintCount; offset++)
//				*((ulong*)address + offset) = (ulong)GetInteger();
//			offset <<= 0x1;
//			if (ushortCount - offset == 0x1)
//			{
//				*((ushort*)address + offset) = (ushort)(GetInteger() % (ushort.MaxValue + 0x1));
//				offset++;
//			}
//			offset <<= 0x1;
//			if (count - offset == 0x1)
//				*(address + offset) = (byte)(GetInteger() % (byte.MaxValue + 0x1));
//		}
//	}
//}