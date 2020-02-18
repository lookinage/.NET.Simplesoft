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
		/// Gets an ascending by first elements <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/>.
		/// </summary>
		ISequence<Pair<Integer, Integer>> AscendingByInputsSequence { get; }
		/// <summary>
		/// Gets a descending by first elements <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/>.
		/// </summary>
		ISequence<Pair<Integer, Integer>> DescendingByInputsSequence { get; }
		/// <summary>
		/// Gets an ascending by second elements <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/>.
		/// </summary>
		ISequence<Pair<Integer, Integer>> AscendingByOutputsSequence { get; }
		/// <summary>
		/// Gets a descending by second elements <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/>.
		/// </summary>
		ISequence<Pair<Integer, Integer>> DescendingByOutputsSequence { get; }

		/// <summary>
		/// Gets an ascending by first elements <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>An ascending <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Pair<Integer, Integer>> GetAscendingByInputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a descending by first elements <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>A descending <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Pair<Integer, Integer>> GetDescendingByInputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets an ascending by second elements <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>An ascending <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Pair<Integer, Integer>> GetAscendingByOutputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a descending by second elements <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>A descending <see cref="ISequence{T}"/> of pairs of the <see cref="IIntegerPairSubset"/> within <paramref name="interval"/>.</returns>
		ISequence<Pair<Integer, Integer>> GetDescendingByOutputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a pairs of the <see cref="IIntegerPairSubset"/> first of which is greater than or equal to a threshold integer if the pair exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="pair">The the pair if such a pair exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the pair exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotLessThanByInputs
		(
			Integer threshold, 
			out Pair<Integer, Integer> pair
		);
		/// <summary>
		/// Gets a pairs of the <see cref="IIntegerPairSubset"/> first of which is less than or equal to a threshold integer if the pair exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="pair">The the pair if such a pair exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the pair exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotGreaterThanByInputs
		(
			Integer threshold,
			out Pair<Integer, Integer> pair
		);
		/// <summary>
		/// Gets a pairs of the <see cref="IIntegerPairSubset"/> second of which is greater than or equal to a threshold integer if the pair exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="pair">The the pair if such a pair exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the pair exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotLessThanByOutputs
		(
			Integer threshold,
			out Pair<Integer, Integer> pair
		);
		/// <summary>
		/// Gets a pairs of the <see cref="IIntegerPairSubset"/> second of which is less than or equal to a threshold integer if the pair exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="pair">The the pair if such a pair exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the pair exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotGreaterThanByOutputs
		(
			Integer threshold,
			out Pair<Integer, Integer> pair
		);
	}
}