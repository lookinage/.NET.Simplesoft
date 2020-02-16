using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents a sequence of elements.
	/// </summary>
	/// <typeparam name="T">The type of the elements.</typeparam>
	public interface ISequence<out T>
	{
		/// <summary>
		/// Gets the number of elements of the <see cref="ISequence{T}"/>.
		/// </summary>
		Int64 Count
		{
			get
			{
				Int32 count;
				
				count = 0x0;
				foreach (T element in this)
					count++;
				return count;
			}
		}

		/// <summary>
		/// Gets an <see cref="IEnumerator{T}"/> of the elements of the <see cref="ISequence{T}"/>.
		/// </summary>
		/// <returns>An <see cref="IEnumerator{T}"/> of the elements of the <see cref="ISequence{T}"/>.</returns>
		IEnumerator<T> GetEnumerator();
	}
}