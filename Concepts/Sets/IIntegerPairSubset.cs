using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an <see cref="IPairSubset{TFirst, TSecond}"/> of integers.
	/// </summary>
	public interface IIntegerPairSubset : IPairSubset<Integer, Integer>
	{
		/// <summary>
		/// Represents an editor of an <see cref="IIntegerPairSubset"/>.
		/// </summary>
		public new interface IEditor : IPairSubset<Integer, Integer>.IEditor { }

		/// <summary>
		/// Gets an ascending by first element <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/>.
		/// </summary>
		ISequence<Pair<Integer, Integer>> AscendingByFirstSequence { get; }
		/// <summary>
		/// Gets a descending by first element <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/>.
		/// </summary>
		ISequence<Pair<Integer, Integer>> DescendingByFirstSequence { get; }
		/// <summary>
		/// Gets an ascending by second element <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/>.
		/// </summary>
		ISequence<Pair<Integer, Integer>> AscendingBySecondSequence { get; }
		/// <summary>
		/// Gets a descending by second element <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/>.
		/// </summary>
		ISequence<Pair<Integer, Integer>> DescendingBySecondSequence { get; }

		/// <summary>
		/// Gets an ascending by first element <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>An ascending <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Pair<Integer, Integer>> GetAscendingByFirstSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a descending by first element <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>A descending <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Pair<Integer, Integer>> GetDescendingByFirstSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets an ascending by second element <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>An ascending <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Pair<Integer, Integer>> GetAscendingBySecondSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a descending by second element <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>A descending <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Pair<Integer, Integer>> GetDescendingBySecondSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a pairs of the <see cref="IIntegerPairSubset"/> first of which is greater than or equal to a threshold integer if such a pair exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="pair">The the pair if such a pair exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if such a pair exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotLessThanByFirst
		(
			Integer threshold, 
			out Pair<Integer, Integer> pair
		);
		/// <summary>
		/// Gets a pairs of the <see cref="IIntegerPairSubset"/> first of which is less than or equal to a threshold integer if such a pair exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="pair">The the pair if such a pair exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if such a pair exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotGreaterThanByFirst
		(
			Integer threshold,
			out Pair<Integer, Integer> pair
		);
		/// <summary>
		/// Gets a pairs of the <see cref="IIntegerPairSubset"/> second of which is greater than or equal to a threshold integer if such a pair exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="pair">The the pair if such a pair exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if such a pair exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotLessThanBySecond
		(
			Integer threshold,
			out Pair<Integer, Integer> pair
		);
		/// <summary>
		/// Gets a pairs of the <see cref="IIntegerPairSubset"/> second of which is less than or equal to a threshold integer if the pair exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="pair">The the pair if such a pair exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if such a pair exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotGreaterThanBySecond
		(
			Integer threshold,
			out Pair<Integer, Integer> pair
		);
	}
}