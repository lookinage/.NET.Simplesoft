namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents a sequence of elements.
	/// </summary>
	/// <typeparam name="T">The type of the elements.</typeparam>
	public interface ISequence<out T>
	{
		/// <summary>
		/// Gets an <see cref="IEnumerator{T}"/> of the elements of the <see cref="ISequence{T}"/>.
		/// </summary>
		/// <returns>The <see cref="IEnumerator{T}"/>.</returns>
		IEnumerator<T> GetEnumerator();
	}
}