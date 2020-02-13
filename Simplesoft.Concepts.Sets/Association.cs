namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an association between an element of an input set (input) and an element of an argument set (output).
	/// </summary>
	/// <typeparam name="TInput">The type of the input.</typeparam>
	/// <typeparam name="TOutput">The type of the output.</typeparam>
	public readonly struct Association<TInput, TOutput>
	{
		private readonly TInput _input;
		private readonly TOutput _output;

		/// <summary>
		/// Initializes the <see cref="Association{TInput, TOutput}"/>.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="output">The output.</param>
		public Association(TInput input, TOutput output)
		{
			_input = input;
			_output = output;
		}

		/// <summary>
		/// Gets the input.
		/// </summary>
		public TInput Input => _input;
		/// <summary>
		/// Gets the output.
		/// </summary>
		public TOutput Output => _output;
	}
}