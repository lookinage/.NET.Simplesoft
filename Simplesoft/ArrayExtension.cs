using System;

namespace Simplesoft
{
	/// <summary>
	/// Provides extended functional for <see cref="Array"/> objects.
	/// </summary>
	static public class ArrayExtension
	{
		/// <summary>
		/// Provides exceptions for <see cref="EnsureLength{T}(ref T[], NonNegativeInteger)"/> method.
		/// </summary>
		static public class EnsureLengthExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the desiredLength argument value is greater than <see cref="MaxArrayLength"/>.
			/// </summary>
			public sealed class DesiredLengthInvalidException : Exception
			{
				internal DesiredLengthInvalidException() { }
			}
		}

		/// <summary>
		/// The maximum array length.
		/// </summary>
		public const long MaxArrayLength = 0x7FEFFFFF;

		/// <summary>
		/// Initializes an <see cref="Array"/> by a desired length if the <see cref="Array"/> is <see langword="null"/>; otherwise, doubles the length of the <see cref="Array"/> while the length is less than the desired length.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> which length is to be ensured.</param>
		/// <param name="desiredLength">The desired length of the <see cref="Array"/>.</param>
		/// <exception cref="EnsureLengthExceptions.DesiredLengthInvalidException"/>
		static public bool EnsureLength<T>(ref T[] array, NonNegativeInteger desiredLength)
		{
			long currentLength;
			long newLength;
			T[] newArray;

			if (desiredLength > MaxArrayLength)
				throw new EnsureLengthExceptions.DesiredLengthInvalidException();
			if (array == null || (currentLength = array.Length) == 0x0 && desiredLength > 0x0)
			{
				array = new T[desiredLength];
				return true;
			}
			if (currentLength >= desiredLength)
				return false;
			newLength = currentLength;
			do
			{
				newLength <<= 0x1;
				if (newLength < 0x0 || newLength > MaxArrayLength)
				{
					newLength = MaxArrayLength;
					break;
				}
			}
			while (newLength < desiredLength);
			newArray = new T[newLength];
			Array.Copy(array, newArray, currentLength);
			array = newArray;
			return true;
		}
	}
}