namespace Simplesoft.Concepts.Sets
{
	/// <summary>
	/// Represents a relation between two elements.
	/// </summary>
	/// <typeparam name="TFirst">The type of the first element.</typeparam>
	/// <typeparam name="TSecond">The type of the second element.</typeparam>
	public struct Pair<TFirst, TSecond>
	{
		/// <summary>
		/// The first element.
		/// </summary>
		public TFirst First;
		/// <summary>
		/// The second element.
		/// </summary>
		public TSecond Second;

		/// <summary>
		/// Initializes the <see cref="Pair{TFirst, TSecond}"/>.
		/// </summary>
		/// <param name="first">The first element.</param>
		/// <param name="second">The second element.</param>
		public Pair
		(
			TFirst first,
			TSecond second
		)
		{
			First = first;
			Second = second;
		}
	}
}