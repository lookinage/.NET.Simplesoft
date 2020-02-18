using System;

namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents an order of elements of a set.
	/// </summary>
	/// <typeparam name="T">The type of the elements.</typeparam>
	public interface IOrder<T>
	{
		/// <summary>
		/// Represents an editor of an <see cref="IOrder{T}"/>.
		/// </summary>
		public interface IEditor
		{
			/// <summary>
			/// Provides exceptions for get accessor of Item property.
			/// </summary>
			static public class ItemPropertySetAccessorExceptions
			{
				/// <summary>
				/// Represents the exception that is thrown when the offset argument value is greater than or equal to the number of elements of the <see cref="IOrder{T}"/>.
				/// </summary>
				public sealed class OffsetInvalidException : Exception
				{
					/// <summary>
					/// Initializes the <see cref="OffsetInvalidException"/>.
					/// </summary>
					public OffsetInvalidException() { }
				}
			}

			/// <summary>
			/// Sets an element at an offset from the beginning of the <see cref="IOrder{T}"/>.
			/// </summary>
			/// <param name="offset">The offset.</param>
			/// <exception cref="ItemPropertySetAccessorExceptions.OffsetInvalidException"/>
			T this[NonNegativeInteger offset] { set; }

			/// <summary>
			/// Removes all the elements from the <see cref="IOrder{T}"/> and causes the <see cref="ClearEvent"/> on the <see cref="IOrder{T}"/>.
			/// </summary>
			void Clear();
		}

		/// <summary>
		/// Provides exceptions for get accessor of Item property.
		/// </summary>
		static public class ItemPropertyGetAccessorExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the offset argument value is greater than or equal to the number of elements of the <see cref="IOrder{T}"/>.
			/// </summary>
			public sealed class OffsetInvalidException : Exception
			{
				/// <summary>
				/// Initializes the <see cref="OffsetInvalidException"/>.
				/// </summary>
				public OffsetInvalidException() { }
			}
		}

		/// <summary>
		/// References a method that responds to the <see cref="ClearEvent"/>.
		/// </summary>
		/// <param name="order">The <see cref="IOrder{T}"/> the <see cref="ClearEvent"/> has happened to.</param>
		/// <param name="count">The number of removed elements.</param>
		public delegate void ClearEventResponder
		(
			IOrder<T> order,
			Integer count
		);

		/// <summary>
		/// Gets the <see cref="ISequence{T}"/> of the elements of the <see cref="IOrder{T}"/>.
		/// </summary>
		public ISequence<T> ElementSequence { get; }
		/// <summary>
		/// Gets the number of elements of the <see cref="IOrder{T}"/>.
		/// </summary>
		Integer Count { get; }
		/// <summary>
		/// Gets an element at an offset from the beginning of the <see cref="IOrder{T}"/>.
		/// </summary>
		/// <param name="offset">The offset.</param>
		/// <exception cref="ItemPropertyGetAccessorExceptions.OffsetInvalidException"/>
		T this[NonNegativeInteger offset] { get; }

		/// <summary>
		/// Occurs when all elements are removed from the <see cref="IOrder{T}"/>.
		/// </summary>
		public event ClearEventResponder ClearEvent;
	}
}