using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an <see cref="IFunction{TInput, TOutput}"/> where an output can be associated to a number of inputs.
	/// </summary>
	/// <typeparam name="TInput">The type of the inputs.</typeparam>
	/// <typeparam name="TOutput">The type of the outputs.</typeparam>
	public interface ISurjection<TInput, TOutput> : IFunction<TInput, TOutput>
	{
		/// <summary>
		/// References a method that responds to the <see cref="AddEvent"/>.
		/// </summary>
		/// <param name="surjection">The <see cref="ISurjection{TInput, TOutput}"/> the <see cref="AddEvent"/> has happened to.</param>
		/// <param name="input">The input of the association that is added to the <see cref="ISurjection{TInput, TOutput}"/>.</param>
		/// <param name="output">The output of the association that is added to the <see cref="ISurjection{TInput, TOutput}"/>.</param>
		/// <param name="address">The address of the association in the <see cref="ISurjection{TInput, TOutput}"/>.</param>
		public delegate void AddEventResponder(ISurjection<TInput, TOutput> surjection, TInput input, TOutput output, long address);

		/// <summary>
		/// Represents an editor of an <see cref="ISurjection{TInput, TOutput}"/>.
		/// </summary>
		public interface IEditor : IFunction<TInput, TOutput>.IEditor
		{
			/// <summary>
			/// Provides exceptions for <see cref="TryAdd(TInput, TOutput, out long)"/> method.
			/// </summary>
			static public class TryAddMethodExceptions
			{
				/// <summary>
				/// Represents the exception that is thrown when the <see cref="ISurjection{TInput, TOutput}"/> contains the maximum number of elements.
				/// </summary>
				public sealed class OverflowedException : Exception
				{
					/// <summary>
					/// Initializes the <see cref="OverflowedException"/>.
					/// </summary>
					public OverflowedException() { }
				}
			}

			/// <summary>
			/// Adds an association between an input and an output to the <see cref="ISurjection{TInput, TOutput}"/>, causes the <see cref="AddEvent"/> on the <see cref="ISurjection{TInput, TOutput}"/> if the <see cref="ISurjection{TInput, TOutput}"/> does not contain an association to the input.
			/// </summary>
			/// <param name="input">The input.</param>
			/// <param name="output">The output.</param>
			/// <param name="address">The address of the association in the <see cref="ISurjection{TInput, TOutput}"/> if the association is added; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the association is added to the <see cref="ISurjection{TInput, TOutput}"/>; otherwise, <see langword="false"/>.</returns>
			/// <exception cref="TryAddMethodExceptions.OverflowedException"/>
			bool TryAdd(TInput input, TOutput output, out long address);
		}

		/// <summary>
		/// Occurs when an association is added to the <see cref="ISurjection{TInput, TOutput}"/>.
		/// </summary>
		public event AddEventResponder AddEvent;

		/// <summary>
		/// Gets an <see cref="ISequence{T}"/> of inputs an output associated to.
		/// </summary>
		/// <param name="output">The output.</param>
		/// <returns>An <see cref="ISequence{T}"/> of inputs an output associated to.</returns>
		ISequence<TInput> TryGetInputs(TOutput output);
	}
}