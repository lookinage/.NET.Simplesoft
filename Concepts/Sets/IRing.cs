using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an order of elements implemented as a ring.
	/// </summary>
	/// <typeparam name="T">The type of elements.</typeparam>
	public interface IRing<T> : IOrder<T>
	{
		/// <summary>
		/// Represents an editor of an <see cref="IRing{T}"/>.
		/// </summary>
		public new interface IEditor : IOrder<T>.IEditor
		{
			/// <summary>
			/// Provides exceptions for <see cref="AddFront(T)"/> method.
			/// </summary>
			static public class AddFrontMethodExceptions
			{
				/// <summary>
				/// Represents the exception that is thrown when the <see cref="IRing{T}"/> contains the maximum number of elements.
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
			/// Provides exceptions for <see cref="AddBack(T)"/> method.
			/// </summary>
			static public class AddBackMethodExceptions
			{
				/// <summary>
				/// Represents the exception that is thrown when the <see cref="IRing{T}"/> contains the maximum number of elements.
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
			/// Removes an element from the end of the <see cref="IRing{T}"/>, causes the <see cref="RemoveFrontEvent"/> on the <see cref="IRing{T}"/> if the <see cref="IRing{T}"/> is not empty.
			/// </summary>
			/// <param name="element">The element if the <see cref="IRing{T}"/> is not empty; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the element is removed from the <see cref="IRing{T}"/>; otherwise, <see langword="false"/>.</returns>
			Boolean RemoveBack(out T element);
			/// <summary>
			/// Removes an element from the beginning of the <see cref="IRing{T}"/>, causes the <see cref="RemoveFrontEvent"/> on the <see cref="IRing{T}"/> if the <see cref="IRing{T}"/> is not empty.
			/// </summary>
			/// <param name="element">The element if the <see cref="IRing{T}"/> is not empty; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the element is removed from the <see cref="IRing{T}"/>; otherwise, <see langword="false"/>.</returns>
			Boolean RemoveFront(out T element);
			/// <summary>
			/// Adds an element at the end of the <see cref="IRing{T}"/> and causes the <see cref="AddBackEvent"/> on the <see cref="IRing{T}"/>.
			/// </summary>
			/// <param name="element">The element.</param>
			/// <exception cref="AddBackMethodExceptions.OverflowedException"/>
			void AddBack(T element);
			/// <summary>
			/// Adds an element at the beginning of the <see cref="IRing{T}"/> and causes the <see cref="AddFrontEvent"/> on the <see cref="IRing{T}"/>.
			/// </summary>
			/// <param name="element">The element.</param>
			/// <exception cref="AddFrontMethodExceptions.OverflowedException"/>
			void AddFront(T element);
		}

		/// <summary>
		/// References a method that responds to the <see cref="RemoveBackEvent"/>.
		/// </summary>
		/// <param name="ring">The <see cref="IRing{T}"/> the <see cref="RemoveBackEvent"/> has happened to.</param>
		/// <param name="element">The element that is removed from the <see cref="IRing{T}"/>.</param>
		public delegate void RemoveBackEventResponder
		(
			IRing<T> ring,
			T element
		);
		/// <summary>
		/// References a method that responds to the <see cref="RemoveFrontEvent"/>.
		/// </summary>
		/// <param name="ring">The <see cref="IRing{T}"/> the <see cref="RemoveFrontEvent"/> has happened to.</param>
		/// <param name="element">The element that is removed from the <see cref="IRing{T}"/>.</param>
		public delegate void RemoveFrontEventResponder
		(
			IRing<T> ring,
			T element
		);
		/// <summary>
		/// References a method that responds to the <see cref="AddBackEvent"/>.
		/// </summary>
		/// <param name="ring">The <see cref="IRing{T}"/> the <see cref="AddBackEvent"/> has happened to.</param>
		/// <param name="element">The element that is added to the <see cref="IRing{T}"/>.</param>
		public delegate void AddBackEventResponder
		(
			IRing<T> ring,
			T element
		);
		/// <summary>
		/// References a method that responds to the <see cref="AddFrontEvent"/>.
		/// </summary>
		/// <param name="ring">The <see cref="IRing{T}"/> the <see cref="AddFrontEvent"/> has happened to.</param>
		/// <param name="element">The element that is added to the <see cref="IRing{T}"/>.</param>
		public delegate void AddFrontEventResponder
		(
			IRing<T> ring,
			T element
		);

		/// <summary>
		/// Occurs when an element is removed from the end of the <see cref="IRing{T}"/>.
		/// </summary>
		public event RemoveBackEventResponder RemoveBackEvent;
		/// <summary>
		/// Occurs when an element is removed from the beginning of the <see cref="IRing{T}"/>.
		/// </summary>
		public event RemoveFrontEventResponder RemoveFrontEvent;
		/// <summary>
		/// Occurs when an element is added at the end of the <see cref="IRing{T}"/>.
		/// </summary>
		public event AddBackEventResponder AddBackEvent;
		/// <summary>
		/// Occurs when an element is added at the beginning of the <see cref="IRing{T}"/>.
		/// </summary>
		public event AddFrontEventResponder AddFrontEvent;
	}
}