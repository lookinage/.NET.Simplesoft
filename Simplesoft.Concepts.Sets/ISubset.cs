using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents a subset of elements of a set.
	/// </summary>
	/// <typeparam name="T">The type of the elements.</typeparam>
	public interface ISubset<T>
	{
		/// <summary>
		/// References a method that responds to the <see cref="ClearEvent"/>.
		/// </summary>
		/// <param name="subset">The <see cref="ISubset{T}"/> the <see cref="ClearEvent"/> has happened to.</param>
		/// <param name="count">The number of removed elements.</param>
		public delegate void ClearEventResponder(ISubset<T> subset, Int64 count);
		/// <summary>
		/// References a method that responds to the <see cref="RemoveEvent"/>.
		/// </summary>
		/// <param name="subset">The <see cref="ISubset{T}"/> the <see cref="RemoveEvent"/> has happened to.</param>
		/// <param name="element">The element that is removed from the <see cref="ISubset{T}"/>.</param>
		/// <param name="address">The address of <paramref name="element"/> in the <see cref="ISubset{T}"/>.</param>
		public delegate void RemoveEventResponder(ISubset<T> subset, T element, Int64 address);
		/// <summary>
		/// References a method that responds to the <see cref="AddEvent"/>.
		/// </summary>
		/// <param name="subset">The <see cref="ISubset{T}"/> the <see cref="AddEvent"/> has happened to.</param>
		/// <param name="element">The element that is added to the <see cref="ISubset{T}"/>.</param>
		/// <param name="address">The address of <paramref name="element"/> in the <see cref="ISubset{T}"/>.</param>
		public delegate void AddEventResponder(ISubset<T> subset, T element, Int64 address);

		/// <summary>
		/// Represents an editor of an <see cref="ISubset{T}"/>.
		/// </summary>
		public interface IEditor
		{
			/// <summary>
			/// Provides exceptions for <see cref="TryAdd(T, out Int64)"/> method.
			/// </summary>
			static public class TryAddMethodExceptions
			{
				/// <summary>
				/// Represents the exception that is thrown when the <see cref="ISubset{T}"/> contains the maximum number of elements.
				/// </summary>
				public sealed class OverflowedException : Exception
				{
					/// <summary>
					/// Initializes the <see cref="OverflowException"/>.
					/// </summary>
					public OverflowedException() { }
				}
			}

			/// <summary>
			/// Removes all the elements from the <see cref="ISubset{T}"/> and causes the <see cref="ClearEvent"/> on the <see cref="ISubset{T}"/>.
			/// </summary>
			void Clear();
			/// <summary>
			/// Removes an element at an address from the <see cref="ISubset{T}"/>, causes the <see cref="RemoveEvent"/> on the <see cref="ISubset{T}"/> if the <see cref="ISubset{T}"/> contains the element at the address.
			/// </summary>
			/// <param name="address">The address.</param>
			/// <param name="element">The element if the <see cref="ISubset{T}"/> contains the element at <paramref name="address"/>; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the element is removed from the <see cref="ISubset{T}"/>; otherwise, <see langword="false"/>.</returns>
			Boolean TryRemoveAt(Int64 address, out T element);
			/// <summary>
			/// Removes an element from the <see cref="ISubset{T}"/>, causes the <see cref="RemoveEvent"/> on the <see cref="ISubset{T}"/> if the <see cref="ISubset{T}"/> contains the element.
			/// </summary>
			/// <param name="element">The element.</param>
			/// <param name="address">The address of <paramref name="element"/> in the <see cref="ISubset{T}"/> if <paramref name="element"/> is removed from the <see cref="ISubset{T}"/>; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether <paramref name="element"/> is removed from the <see cref="ISubset{T}"/>; otherwise, <see langword="false"/>.</returns>
			Boolean TryRemove(T element, out Int64 address);
			/// <summary>
			/// Adds an element to the <see cref="ISubset{T}"/>, causes the <see cref="AddEvent"/> on the <see cref="ISubset{T}"/> if the <see cref="ISubset{T}"/> does not contain the element.
			/// </summary>
			/// <param name="element">The element.</param>
			/// <param name="address">The address of <paramref name="element"/> in the <see cref="ISubset{T}"/> if <paramref name="element"/> is added to the <see cref="ISubset{T}"/>; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether <paramref name="element"/> is added to the <see cref="ISubset{T}"/>; otherwise, <see langword="false"/>.</returns>
			/// <exception cref="TryAddMethodExceptions.OverflowedException"/>
			Boolean TryAdd(T element, out Int64 address);
		}

		/// <summary>
		/// Gets the number of elements of the <see cref="ISubset{T}"/>.
		/// </summary>
		Int64 Count { get; }
		/// <summary>
		/// Gets an <see cref="ISequence{T}"/> of the elements of the <see cref="ISubset{T}"/>.
		/// </summary>
		public ISequence<T> ElementSequence { get; }

		/// <summary>
		/// Occurs when all elements are removed from the <see cref="ISubset{T}"/>.
		/// </summary>
		public event ClearEventResponder ClearEvent;
		/// <summary>
		/// Occurs when an element is removed from the <see cref="ISubset{T}"/>.
		/// </summary>
		public event RemoveEventResponder RemoveEvent;
		/// <summary>
		/// Occurs when an element is added to the <see cref="ISubset{T}"/>.
		/// </summary>
		public event AddEventResponder AddEvent;

		/// <summary>
		/// Gets an address of an element in the <see cref="ISubset{T}"/> if the <see cref="ISubset{T}"/> contains the element.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="address">The address of <paramref name="element"/> if the <see cref="ISubset{T}"/> contains <paramref name="element"/>; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="ISubset{T}"/> contains <paramref name="element"/>; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetAddress(T element, out Int64 address);
		/// <summary>
		/// Gets an element at an address in the <see cref="ISubset{T}"/> if the <see cref="ISubset{T}"/> contains the element at the address.
		/// </summary>
		/// <param name="address">The address.</param>
		/// <param name="element">The element if the <see cref="ISubset{T}"/> contains the element at <paramref name="address"/>; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="ISubset{T}"/> contains the element at <paramref name="address"/>; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetAt(Int64 address, out T element);
	}
}