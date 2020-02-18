using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an enumerator of elements of an <see cref="ISequence{T}"/>.
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
			/// Represents the exception that is thrown when the current element of an <see cref="IEnumerator{T}"/> is accessed when the <see cref="IEnumerator{T}"/> is finished.
			/// </summary>
			public sealed class FinishedException : Exception
			{
				/// <summary>
				/// Initializes the <see cref="FinishedException"/>.
				/// </summary>
				public FinishedException() { }
			}
		}

		/// <summary>
		/// Gets the current element of the <see cref="IEnumerator{T}"/>.
		/// </summary>
		/// <exception cref="CurrentPropertyGetAccessorExceptions.NotStartedException"/>
		/// <exception cref="CurrentPropertyGetAccessorExceptions.FinishedException"/>
		T Current { get; }
		/// <summary>
		/// Gets the value that indicates whether the <see cref="IEnumerator{T}"/> is started.
		/// </summary>
		Boolean Started { get; }
		/// <summary>
		/// Gets the value that indicates whether the <see cref="IEnumerator{T}"/> is finished.
		/// </summary>
		Boolean Finished { get; }

		/// <summary>
		/// Sets the next element of the <see cref="ISequence{T}"/> as the current if the current element is not last.
		/// </summary>
		/// <returns><see langword="true"/> whether the <see cref="IEnumerator{T}"/> is not finished yet and the next element is set as current; otherwise, <see langword="false"/>.</returns>
		Boolean MoveNext();
	}
}