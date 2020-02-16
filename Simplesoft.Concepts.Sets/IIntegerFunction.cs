using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an <see cref="IIntegerFunction"/> where the input set and the output set are the sets of integers.
	/// </summary>
	public interface IIntegerFunction : IFunction<Int64, Int64>
	{
		/// <summary>
		/// Represents an editor of an <see cref="IIntegerFunction"/>.
		/// </summary>
		public new interface IEditor : IFunction<Int64, Int64>.IEditor { }

		/// <summary>
		/// Gets an ascending by inputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/>.
		/// </summary>
		ISequence<Association<Int64, Int64>> AscendingByInputsSequence { get; }
		/// <summary>
		/// Gets a descending by inputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/>.
		/// </summary>
		ISequence<Association<Int64, Int64>> DescendingByInputsSequence { get; }
		/// <summary>
		/// Gets an ascending by outputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/>.
		/// </summary>
		ISequence<Association<Int64, Int64>> AscendingByOutputsSequence { get; }
		/// <summary>
		/// Gets a descending by outputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/>.
		/// </summary>
		ISequence<Association<Int64, Int64>> DescendingByOutputsSequence { get; }

		/// <summary>
		/// Gets an ascending by inputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>An ascending <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within <paramref name="interval"/>.</returns>
		ISequence<Association<Int64, Int64>> GetAscendingByInputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a descending by inputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>A descending <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within <paramref name="interval"/>.</returns>
		ISequence<Association<Int64, Int64>> GetDescendingByInputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets an ascending by outputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>An ascending <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within <paramref name="interval"/>.</returns>
		ISequence<Association<Int64, Int64>> GetAscendingByOutputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a descending by outputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>A descending <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within <paramref name="interval"/>.</returns>
		ISequence<Association<Int64, Int64>> GetDescendingByOutputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets an associations of the <see cref="IIntegerFunction"/> input of which is greater than or equal to a threshold integer if the association exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="input">The input of the association if the association exists; otherwise, the default value.</param>
		/// <param name="output">The output of the association if the association exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the association exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotLessThanByInputs
		(
			Int64 threshold, 
			out Int64 input, 
			out Int64 output
		);
		/// <summary>
		/// Gets an associations of the <see cref="IIntegerFunction"/> input of which is less than or equal to a threshold integer if the association exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="input">The input of the association if the association exists; otherwise, the default value.</param>
		/// <param name="output">The output of the association if the association exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the association exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotGreaterThanByInputs
		(
			Int64 threshold, 
			out Int64 input, 
			out Int64 output
		);
		/// <summary>
		/// Gets an associations of the <see cref="IIntegerFunction"/> output of which is greater than or equal to a threshold integer if the association exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="input">The input of the association if the association exists; otherwise, the default value.</param>
		/// <param name="output">The output of the association if the association exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the association exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotLessThanByOutputs
		(
			Int64 threshold, 
			out Int64 input, 
			out Int64 output
		);
		/// <summary>
		/// Gets an associations of the <see cref="IIntegerFunction"/> output of which is less than or equal to a threshold integer if the association exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="input">The input of the association if the association exists; otherwise, the default value.</param>
		/// <param name="output">The output of the association if the association exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the association exists; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetNotGreaterThanByOutputs
		(
			Int64 threshold, 
			out Int64 input, 
			out Int64 output
		);
	}
}