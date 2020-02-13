namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents a relation between elements of an input set (inputs) and elements of an output set (outputs).
	/// </summary>
	/// <typeparam name="TInput">The type of the inputs.</typeparam>
	/// <typeparam name="TOutput">The type of the outputs.</typeparam>
	public interface IFunction<TInput, TOutput>
	{
		/// <summary>
		/// References a method that responds to the <see cref="ClearEvent"/>.
		/// </summary>
		/// <param name="function">The <see cref="IFunction{TInput, TOutput}"/> the <see cref="ClearEvent"/> has happened to.</param>
		/// <param name="count">The number of removed elements.</param>
		public delegate void ClearEventResponder(IFunction<TInput, TOutput> function, long count);
		/// <summary>
		/// References a method that responds to the <see cref="RemoveEvent"/>.
		/// </summary>
		/// <param name="function">The <see cref="IFunction{TInput, TOutput}"/> the <see cref="RemoveEvent"/> has happened to.</param>
		/// <param name="input">The input of the association that is removed from the <see cref="IFunction{TInput, TOutput}"/>.</param>
		/// <param name="output">The output of the association that is removed from the <see cref="IFunction{TInput, TOutput}"/>.</param>
		/// <param name="address">The address of the association in the <see cref="IFunction{TInput, TOutput}"/>.</param>
		public delegate void RemoveEventResponder(IFunction<TInput, TOutput> function, TInput input, TOutput output, long address);

		/// <summary>
		/// Represents an editor of an <see cref="IFunction{TInput, TOutput}"/>.
		/// </summary>
		public interface IEditor
		{
			/// <summary>
			/// Removes all the associations from the <see cref="IFunction{TInput, TOutput}"/> and causes the <see cref="ClearEvent"/> on the <see cref="IFunction{TInput, TOutput}"/>.
			/// </summary>
			void Clear();
			/// <summary>
			/// Removes an association at an address from the <see cref="IFunction{TInput, TOutput}"/>, causes the <see cref="RemoveEvent"/> on the <see cref="IFunction{TInput, TOutput}"/> if the <see cref="IFunction{TInput, TOutput}"/> contains the association at the address.
			/// </summary>
			/// <param name="address">The address.</param>
			/// <param name="input">The input of the association if the <see cref="IFunction{TInput, TOutput}"/> contains the association at <paramref name="address"/>; otherwise, the default value.</param>
			/// <param name="output">The output of the association if the <see cref="IFunction{TInput, TOutput}"/> contains the association at <paramref name="address"/>; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the association is removed from the <see cref="IFunction{TInput, TOutput}"/>; otherwise, <see langword="false"/>.</returns>
			bool TryRemoveAt(long address, out TInput input, out TOutput output);
			/// <summary>
			/// Removes an association to an input from the <see cref="IFunction{TInput, TOutput}"/>, causes the <see cref="RemoveEvent"/> on the <see cref="IFunction{TInput, TOutput}"/> if the <see cref="IFunction{TInput, TOutput}"/> contains an association to the input.
			/// </summary>
			/// <param name="input">The input.</param>
			/// <param name="output">The output if the <see cref="IFunction{TInput, TOutput}"/> contains an association to <paramref name="input"/>; otherwise, the default value.</param>
			/// <param name="address">The address of the association in the <see cref="IFunction{TInput, TOutput}"/> contains an association to <paramref name="input"/>; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the <see cref="IFunction{TInput, TOutput}"/> contains an association to <paramref name="input"/>; otherwise, <see langword="false"/>.</returns>
			bool TryRemoveInput(TInput input, out TOutput output, long address);
			/// <summary>
			/// Removes an association with an output from the <see cref="IFunction{TInput, TOutput}"/>, causes the <see cref="RemoveEvent"/> on the <see cref="IFunction{TInput, TOutput}"/> if the <see cref="IFunction{TInput, TOutput}"/> contains an association with the output.
			/// </summary>
			/// <param name="output">The output.</param>
			/// <param name="input">The input if the <see cref="IFunction{TInput, TOutput}"/> contains an association with <paramref name="output"/>; otherwise, the default value.</param>
			/// <param name="address">The address of the association in the <see cref="IFunction{TInput, TOutput}"/> contains an association with <paramref name="output"/>; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the <see cref="IFunction{TInput, TOutput}"/> contains an association with <paramref name="output"/>; otherwise, <see langword="false"/>.</returns>
			bool TryRemoveOutput(TOutput output, out TInput input, long address);
		}

		/// <summary>
		/// Gets the number of associations of the <see cref="IFunction{TInput, TOutput}"/>.
		/// </summary>
		long Count { get; }
		/// <summary>
		/// Gets an <see cref="ISequence{T}"/> of the associations of the <see cref="IFunction{TInput, TOutput}"/>.
		/// </summary>
		public ISequence<Association<TInput, TOutput>> AssociationSequence { get; }

		/// <summary>
		/// Occurs when all association are removed from the <see cref="IFunction{TInput, TOutput}"/>.
		/// </summary>
		public event ClearEventResponder ClearEvent;
		/// <summary>
		/// Occurs when an association is removed from the <see cref="IFunction{TInput, TOutput}"/>.
		/// </summary>
		public event RemoveEventResponder RemoveEvent;

		/// <summary>
		/// Gets an address of an association to an input in the <see cref="IFunction{TInput, TOutput}"/> if the <see cref="IFunction{TInput, TOutput}"/> contains an association to the input.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="address">The address of the association if the <see cref="IFunction{TInput, TOutput}"/> contains an association to <paramref name="input"/>; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="IFunction{TInput, TOutput}"/> contains an association to <paramref name="input"/>; otherwise, <see langword="false"/>.</returns>
		bool TryGetAddress(TInput input, out long address);
		/// <summary>
		/// Gets an association at an address in the <see cref="IFunction{TInput, TOutput}"/> if the <see cref="IFunction{TInput, TOutput}"/> contains an association at the address.
		/// </summary>
		/// <param name="address">The address.</param>
		/// <param name="input">The input of the association if the <see cref="IFunction{TInput, TOutput}"/> contains an association at <paramref name="address"/>; otherwise, the default value.</param>
		/// <param name="output">The output of the association if the <see cref="IFunction{TInput, TOutput}"/> contains an association at <paramref name="address"/>; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="IFunction{TInput, TOutput}"/> contains an association at <paramref name="address"/>; otherwise, <see langword="false"/>.</returns>
		bool TryGetAt(long address, out TInput input, out TOutput output);
		/// <summary>
		/// Gets an output associated to an input in the <see cref="IFunction{TInput, TOutput}"/> if the <see cref="IFunction{TInput, TOutput}"/> contains an association to the input.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="output">The output of the association if the <see cref="IFunction{TInput, TOutput}"/> contains an association to <paramref name="input"/>; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="IFunction{TInput, TOutput}"/> contains an association to <paramref name="input"/>; otherwise, <see langword="false"/>.</returns>
		bool TryGetOutput(TInput input, out TOutput output);
		/// <summary>
		/// Gets an input an output associated to if the <see cref="IFunction{TInput, TOutput}"/> contains the association.
		/// </summary>
		/// <param name="output">The output.</param>
		/// <param name="input">The input if the <see cref="IFunction{TInput, TOutput}"/> contains the association; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="IFunction{TInput, TOutput}"/> contains the association; otherwise, <see langword="false"/>.</returns>
		bool TryGetInput(TOutput output, out TInput input);
	}
}