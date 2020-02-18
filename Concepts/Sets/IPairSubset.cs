using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents a subset of <see cref="Pair{TFirst, TSecond}"/> instances.
	/// </summary>
	/// <typeparam name="TFirst">The type of the first element.</typeparam>
	/// <typeparam name="TSecond">The type of the second element.</typeparam>
	public interface IPairSubset<TFirst, TSecond> : ISubset<Pair<TFirst, TSecond>>
	{
		/// <summary>
		/// Represents an editor of an <see cref="IPairSubset{TFirst, TSecond}"/>.
		/// </summary>
		public new interface IEditor
		{
			/// <summary>
			/// Provides exceptions for <see cref="TryAddByFirst(TFirst, TSecond, out Integer)"/> method.
			/// </summary>
			static public class TryAddByFirstMethodExceptions
			{
				/// <summary>
				/// Represents the exception that is thrown when the <see cref="IPairSubset{TFirst, TSecond}"/> contains the maximum number of elements.
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
			/// Provides exceptions for <see cref="TryAddBySecond(TFirst, TSecond, out Integer)"/> method.
			/// </summary>
			static public class TryAddBySecondMethodExceptions
			{
				/// <summary>
				/// Represents the exception that is thrown when the <see cref="IPairSubset{TFirst, TSecond}"/> contains the maximum number of elements.
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
			/// Removes the first pair consisting of a first element from the <see cref="IPairSubset{TFirst, TSecond}"/>, causes the <see cref="ISubset{T}.RemoveEvent"/> on the <see cref="IPairSubset{TFirst, TSecond}"/> if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair.
			/// </summary>
			/// <param name="first">The first element.</param>
			/// <param name="second">The second element if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, the default value.</param>
			/// <param name="address">The address of the pair in the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, <see langword="false"/>.</returns>
			Boolean TryRemoveByFirst
			(
				TFirst first,
				out TSecond second,
				Integer address
			);
			/// <summary>
			/// Removes the first pair consisting of a second element from the <see cref="IPairSubset{TFirst, TSecond}"/>, causes the <see cref="ISubset{T}.RemoveEvent"/> on the <see cref="IPairSubset{TFirst, TSecond}"/> if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair.
			/// </summary>
			/// <param name="second">The element of the second.</param>
			/// <param name="first">The first element if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, the default value.</param>
			/// <param name="address">The address of the pair in the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, <see langword="false"/>.</returns>
			Boolean TryRemoveBySecond
			(
				TSecond second,
				out TFirst first,
				Integer address
			);
			/// <summary>
			/// Adds a pair to the <see cref="IPairSubset{TFirst, TSecond}"/>, causes the <see cref="ISubset{T}.AddEvent"/> on the <see cref="IPairSubset{TFirst, TSecond}"/> if the <see cref="IPairSubset{TFirst, TSecond}"/> does not contain a pair consisting of the element of the first set.
			/// </summary>
			/// <param name="first">The first element.</param>
			/// <param name="second">The second element.</param>
			/// <param name="address">The address of the pair in the <see cref="IPairSubset{TFirst, TSecond}"/> if the pair was added; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the pair was added to the <see cref="IPairSubset{TFirst, TSecond}"/>; otherwise, <see langword="false"/>.</returns>
			/// <exception cref="TryAddByFirstMethodExceptions.OverflowedException"/>
			Boolean TryAddByFirst
			(
				TFirst first,
				TSecond second,
				out Integer address
			);
			/// <summary>
			/// Adds a pair to the <see cref="IPairSubset{TFirst, TSecond}"/>, causes the <see cref="ISubset{T}.AddEvent"/> on the <see cref="IPairSubset{TFirst, TSecond}"/> if the <see cref="IPairSubset{TFirst, TSecond}"/> does not contain a pair consisting of the element of the second set.
			/// </summary>
			/// <param name="first">The first element.</param>
			/// <param name="second">The second element.</param>
			/// <param name="address">The address of the pair in the <see cref="IPairSubset{TFirst, TSecond}"/> if the pair was added; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the pair was added to the <see cref="IPairSubset{TFirst, TSecond}"/>; otherwise, <see langword="false"/>.</returns>
			/// <exception cref="TryAddByFirstMethodExceptions.OverflowedException"/>
			Boolean TryAddBySecond
			(
				TFirst first,
				TSecond second,
				out Integer address
			);
		}

		/// <summary>
		/// Gets the address of the first pair consisting of a first element in the <see cref="IPairSubset{TFirst, TSecond}"/> if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair.
		/// </summary>
		/// <param name="first">The first element.</param>
		/// <param name="address">The address of the pair if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetAddressByFirst
		(
			TFirst first,
			out Integer address
		);
		/// <summary>
		/// Gets the address of the first pair consisting of a second element in the <see cref="IPairSubset{TFirst, TSecond}"/> if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair.
		/// </summary>
		/// <param name="second">The second element.</param>
		/// <param name="address">The address of the pair if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetAddressBySecond
		(
			TSecond second,
			out Integer address
		);
		/// <summary>
		/// Gets second element of the first pair consisting of a first element of the <see cref="IPairSubset{TFirst, TSecond}"/> if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair.
		/// </summary>
		/// <param name="first">The first element.</param>
		/// <param name="second">The second element of the pair if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetSecondByFirst
		(
			TFirst first,
			out TSecond second
		);
		/// <summary>
		/// Gets first element of the first pair consisting of a second element of the <see cref="IPairSubset{TFirst, TSecond}"/> if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair.
		/// </summary>
		/// <param name="second">The second element.</param>
		/// <param name="first">The first element of the pair if the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, the default value.</param>
		/// <returns><see langword="true"/> whether the <see cref="IPairSubset{TFirst, TSecond}"/> contains the pair; otherwise, <see langword="false"/>.</returns>
		Boolean TryGetFirstBySecond
		(
			TSecond second,
			out TFirst first
		);
		/// <summary>
		/// Gets an <see cref="ISequence{T}"/> of second elements paired with a first element.
		/// </summary>
		/// <param name="first">The first element.</param>
		/// <returns>The <see cref="ISequence{T}"/>.</returns>
		ISequence<TSecond> TryGetFirstsByFirst(TFirst first);
		/// <summary>
		/// Gets an <see cref="ISequence{T}"/> of first elements paired with a second element.
		/// </summary>
		/// <param name="second">The second element.</param>
		/// <returns>The <see cref="ISequence{T}"/>.</returns>
		ISequence<TFirst> TryGetSecondsBySecond(TSecond second);
	}
}