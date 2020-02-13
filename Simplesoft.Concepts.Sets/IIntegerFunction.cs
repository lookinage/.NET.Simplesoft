namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an <see cref="IIntegerFunction"/> where the input set and the output set are the sets of integers.
	/// </summary>
	public interface IIntegerFunction : IFunction<long, long>
	{
		/// <summary>
		/// Represents an editor of an <see cref="IIntegerFunction"/>.
		/// </summary>
		public interface IEditor : IFunction<long, long>.IEditor { }

		/// <summary>
		/// Gets an ascending by inputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/>.
		/// </summary>
		ISequence<Association<long, long>> AscendingByInputsSequence { get; }
		/// <summary>
		/// Gets a descending by inputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/>.
		/// </summary>
		ISequence<Association<long, long>> DescendingByInputsSequence { get; }
		/// <summary>
		/// Gets an ascending by outputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/>.
		/// </summary>
		ISequence<Association<long, long>> AscendingByOutputsSequence { get; }
		/// <summary>
		/// Gets a descending by outputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/>.
		/// </summary>
		ISequence<Association<long, long>> DescendingByOutputsSequence { get; }

		/// <summary>
		/// Gets an ascending by inputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>An ascending <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within <paramref name="interval"/>.</returns>
		ISequence<Association<long, long>> GetAscendingByInputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a descending by inputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>A descending <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within <paramref name="interval"/>.</returns>
		ISequence<Association<long, long>> GetDescendingByInputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets an ascending by outputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>An ascending <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within <paramref name="interval"/>.</returns>
		ISequence<Association<long, long>> GetAscendingByOutputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets a descending by outputs <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within an <see cref="IntegerInterval"/>.
		/// </summary>
		/// <param name="interval">The <see cref="IntegerInterval"/>.</param>
		/// <returns>A descending <see cref="ISequence{T}"/> of associations of the <see cref="IIntegerFunction"/> within <paramref name="interval"/>.</returns>
		ISequence<Association<long, long>> GetDescendingByOutputsSequenceWithinInterval(IntegerInterval interval);
		/// <summary>
		/// Gets an associations of the <see cref="IIntegerFunction"/> input of which is greater than or equal to a threshold integer if the association exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="input">The input of the association if the association exists; otherwise, the default value.</param>
		/// <param name="output">The output of the association if the association exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the association exists; otherwise, <see langword="false"/>.</returns>
		bool TryGetNotLessThanByInputs(long threshold, out long input, out long output);
		/// <summary>
		/// Gets an associations of the <see cref="IIntegerFunction"/> input of which is less than or equal to a threshold integer if the association exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="input">The input of the association if the association exists; otherwise, the default value.</param>
		/// <param name="output">The output of the association if the association exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the association exists; otherwise, <see langword="false"/>.</returns>
		bool TryGetNotGreaterThanByInputs(long threshold, out long input, out long output);
		/// <summary>
		/// Gets an associations of the <see cref="IIntegerFunction"/> output of which is greater than or equal to a threshold integer if the association exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="input">The input of the association if the association exists; otherwise, the default value.</param>
		/// <param name="output">The output of the association if the association exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the association exists; otherwise, <see langword="false"/>.</returns>
		bool TryGetNotLessThanByOutputs(long threshold, out long input, out long output);
		/// <summary>
		/// Gets an associations of the <see cref="IIntegerFunction"/> output of which is less than or equal to a threshold integer if the association exists.
		/// </summary>
		/// <param name="threshold">The threshold integer.</param>
		/// <param name="input">The input of the association if the association exists; otherwise, the default value.</param>
		/// <param name="output">The output of the association if the association exists; otherwise, the default value.</param>
		/// <returns><see langword="true"/> if the association exists; otherwise, <see langword="false"/>.</returns>
		bool TryGetNotGreaterThanByOutputs(long threshold, out long input, out long output);
	}
}