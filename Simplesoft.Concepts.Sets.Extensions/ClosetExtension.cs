using System;

namespace Simplesoft.Concepts.Sets.Extensions
{
	/// <summary>
	/// Provides extensions for instances of <see cref="ICloset{T}"/> and derived types.
	/// </summary>
	static public class ClosetExtension
	{
		/// <summary>
		/// Provides exceptions for <see cref="Add{TCloset, T}(TCloset, int, T)"/> method.
		/// </summary>
		static public class AddMethodExceptions
		{
			/// <summary>
			/// Represents the exception that is thrown when the editor argument value is <see langword="null"/>.
			/// </summary>
			public sealed class EditorNullException : Exception
			{
				/// <summary>
				/// Initializes the <see cref="EditorNullException"/>.
				/// </summary>
				public EditorNullException() { }
			}
			/// <summary>
			/// Represents the exception that is thrown when the editor argument value contains the maximum number of elements.
			/// </summary>
			public sealed class OverflowedException : Exception
			{
				/// <summary>
				/// Initializes the <see cref="OverflowedException"/>.
				/// </summary>
				public OverflowedException() { }
			}
			/// <summary>
			/// Represents the exception that is thrown when the <see cref="ICloset{T}"/> already contains the element.
			/// </summary>
			public sealed class DoubledElementException : Exception
			{
				/// <summary>
				/// Initializes the <see cref="DoubledElementException"/>.
				/// </summary>
				public DoubledElementException() { }
			}
		}

		/// <summary>
		/// Adds an element to an <see cref="ICloset{T}"/> shelf.
		/// </summary>
		/// <typeparam name="TEditor">The type of the <see cref="ICloset{T}.IEditor"/> of the <see cref="ICloset{T}"/>.</typeparam>
		/// <typeparam name="T">The type of the elements.</typeparam>
		/// <param name="editor">The <see cref="ICloset{T}.IEditor"/> of the <see cref="ICloset{T}"/>.</param>
		/// <param name="shelf">The shelf of the <see cref="ICloset{T}"/>.</param>
		/// <param name="element">The element.</param>
		/// <returns>The position of the element in the <see cref="ICloset{T}"/>.</returns>
		/// <exception cref="AddMethodExceptions.EditorNullException"/>
		/// <exception cref="AddMethodExceptions.OverflowedException"/>
		/// <exception cref="AddMethodExceptions.DoubledElementException"/>
		static public int Add<TEditor, T>(this TEditor editor, int shelf, T element) where TEditor : ICloset<T>.IEditor
		{
			if (editor == null)
				throw new AddMethodExceptions.EditorNullException();
			try
			{
				if (!editor.TryAdd(shelf, element, out int position))
					throw new AddMethodExceptions.DoubledElementException();
				return position;
			}
			catch (ICloset<T>.IEditor.TryAddMethodExceptions.OverflowedException) { throw new AddMethodExceptions.OverflowedException(); }
		}
	}
}