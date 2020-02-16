using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an enumerator of elements.
	/// </summary>
	/// <typeparam name="T">The type of the elements.</typeparam>
	public interface IEnumerator<out T> : IDisposable
	{
		/// <summary>
		/// Provides exceptions for get accessor of <see cref="Current"/> property.
		/// </summary>
		static public class CurrentPropertyGetAccessorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the current element of an <see cref="IEnumerator{T}"/> is accessed when the <see cref="IEnumerator{T}"/> is not started.
			/// </summary>
			public sealed class NotStartedException : Exception
			{
				/// <summary>
				/// Initializes the <see cref="NotStartedException"/>.
				/// </summary>
				public NotStartedException() { }
			}
			/// <summary>
			/// Represents the exception that is thrown when the current element of an <see cref="IEnumerator{T}"/> is accessed when the <see cref="IEnumerator{T}"/> is exhausted.
			/// </summary>
			public sealed class ExhaustedException : Exception
			{
				/// <summary>
				/// Initializes the <see cref="ExhaustedException"/>.
				/// </summary>
				public ExhaustedException() { }
			}
		}

		/// <summary>
		/// Gets the current element of the <see cref="IEnumerator{T}"/>.
		/// </summary>
		/// <exception cref="CurrentPropertyGetAccessorExceptions.NotStartedException"/>
		/// <exception cref="CurrentPropertyGetAccessorExceptions.ExhaustedException"/>
		T Current { get; }

		/// <summary>
		/// Sets the next element of the enumeration as current.
		/// </summary>
		/// <returns><see langword="true"/> whether the <see cref="IEnumerator{T}"/> is not exhausted yet and the next element is set; otherwise, <see langword="false"/>.</returns>
		Boolean MoveNext();
	}
}