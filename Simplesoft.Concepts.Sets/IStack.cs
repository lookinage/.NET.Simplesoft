using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an order of elements implemented as a stack.
	/// </summary>
	/// <typeparam name="T">The type of elements.</typeparam>
	public interface IStack<T> : IOrder<T>
	{
		/// <summary>
		/// References a method that responds to the <see cref="RemoveEvent"/>.
		/// </summary>
		/// <param name="stack">The <see cref="IStack{T}"/> the <see cref="RemoveEvent"/> has happened to.</param>
		/// <param name="element">The element that is removed from the <see cref="IStack{T}"/>.</param>
		public delegate void RemoveEventResponder(IStack<T> stack, T element);
		/// <summary>
		/// References a method that responds to the <see cref="AddEvent"/>.
		/// </summary>
		/// <param name="stack">The <see cref="IStack{T}"/> the <see cref="AddEvent"/> has happened to.</param>
		/// <param name="element">The element that is added to the <see cref="IStack{T}"/>.</param>
		public delegate void AddEventResponder(IStack<T> stack, T element);

		/// <summary>
		/// Represents an editor of an <see cref="IStack{T}"/>.
		/// </summary>
		public new interface IEditor : IOrder<T>.IEditor
		{
			/// <summary>
			/// Provides exceptions for <see cref="Add(T)"/> method.
			/// </summary>
			static public class AddMethodExceptions
			{
				/// <summary>
				/// Represents the exception that is thrown when the <see cref="IStack{T}"/> contains the maximum number of elements.
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
			/// Removes an element from the end of the <see cref="IStack{T}"/>, causes the <see cref="RemoveEvent"/> on the <see cref="IStack{T}"/> if the <see cref="IStack{T}"/> is not empty.
			/// </summary>
			/// <param name="element">The element if the <see cref="IStack{T}"/> is not empty; otherwise, the default value.</param>
			/// <returns><see langword="true"/> whether the element is removed from the <see cref="IStack{T}"/>; otherwise, <see langword="false"/>.</returns>
			Boolean Remove(out T element);
			/// <summary>
			/// Adds an element at the end of the <see cref="IStack{T}"/> and causes the <see cref="AddEvent"/> on the <see cref="IStack{T}"/>.
			/// </summary>
			/// <param name="element">The element.</param>
			/// <exception cref="AddMethodExceptions.OverflowedException"/>
			void Add(T element);
		}

		/// <summary>
		/// Occurs when an element is removed from the <see cref="IStack{T}"/>.
		/// </summary>
		public event RemoveEventResponder RemoveEvent;
		/// <summary>
		/// Occurs when an element is added to the <see cref="IStack{T}"/>.
		/// </summary>
		public event AddEventResponder AddEvent;
	}
}