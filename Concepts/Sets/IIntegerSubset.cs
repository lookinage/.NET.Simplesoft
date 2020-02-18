using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an <see cref="ISubset{T}"/> of integers.
	/// </summary>
	public interface IIntegerSubset : ISubset<Integer>
	{
		/// <summary>
		/// Represents an editor of an <see cref="IIntegerPairSubset"/>.
		/// </summary>
		public new interface IEditor : IPairSubset<Integer, Integer>.IEditor { }

		/// <summary>
		/// Gets an ascending <see cref="ISequence{T}"/> of elements of the <see cref="IIntegerSubset"/>.
		/// </summary>
		ISequence<Integer> AscendingSequence { get; }
		/// <summary>
		/// Gets a descending <see cref="ISequence{T}"/> of elements of the <see cref="IIntegerSubset"/>.
		/// </summary>
		ISequence<Integer> DescendingSequence { get; }

		/// <summary>
		/// Gets an ascending <see cref="ISequence{T}"/> of elements of the <see cref="IIntegerSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>An ascending <see cref="ISequence{T}"/> of elements of the <see cref="IIntegerSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Integer> GetAscendingSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a descending <see cref="ISequence{T}"/> of elements of the <see cref="IIntegerSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>A descending <see cref="ISequence{T}"/> of elements of the <see cref="IIntegerSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Integer> GetDescendingSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets an element of the <see cref="IIntegerSubset"/> that is greater than or equal to a threshold integer if the element exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="element">The element if exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the element exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotLessThan
		(
			Integer threshold, 
			out Integer element
		);
		/// <summary>
		/// Gets an element of the <see cref="IIntegerSubset"/> that is less than or equal to a threshold integer if the element exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="element">The element if exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the element exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotGreaterThan
		(
			Integer threshold, 
			out Integer element
		);
	}
}