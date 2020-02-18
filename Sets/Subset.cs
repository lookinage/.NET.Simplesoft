//using Simplesoft.Concepts.Sets;
//using System;
//using System.Collections.Generic;

//namespace Simplesoft.Sets
//{
//	/// <summary>
//	/// Represents a subset of elements of a set.
//	/// </summary>
//	/// <typeparam name="T">The type of the elements.</typeparam>
//	public class Subset<T> : ISubset<T>
//	{
//		private struct Slot
//		{
//			internal Int32 _nextSlotIndex;
//			internal Int32 _hashCode;
//			internal T _element;
//		}

//		/// <summary>
//		/// Represents an editor of an <see cref="ISubset{T}"/>.
//		/// </summary>
//		public class Editor : ISubset<T>.IEditor
//		{
//			private readonly Subset<T> _subset;

//			internal Editor(Subset<T> subset) => _subset = subset;

//			/// <summary>
//			/// Removes all the elements from the <see cref="ISubset{T}"/> and causes the <see cref="ClearEvent"/> on the <see cref="ISubset{T}"/>.
//			/// </summary>
//			public void Clear()
//			{
//				Int32 capacity;

//				Array.Clear
//				(
//					_subset._slots,
//					0x0,
//					capacity = _subset._slots.Length
//				);
//				Array.Clear
//				(
//					_subset._bucketStartIndices,
//					0x0,
//					capacity
//				);
//				_subset._freeSlotIndex = -0x1;
//				_subset._usedSlotCount = 0x0;
//				_subset._count = 0x0;
//			}
//			/// <summary>
//			/// Removes an element at an address from the <see cref="ISubset{T}"/>, causes the <see cref="RemoveEvent"/> on the <see cref="ISubset{T}"/> if the <see cref="ISubset{T}"/> contains the element at the address.
//			/// </summary>
//			/// <param name="address">The address.</param>
//			/// <param name="element">The element if the <see cref="ISubset{T}"/> contains the element at <paramref name="address"/>; otherwise, the default value.</param>
//			/// <returns><see langword="true"/> whether the element is removed from the <see cref="ISubset{T}"/>; otherwise, <see langword="false"/>.</returns>
//			public Boolean TryRemoveAt
//			(
//				Integer address,
//				out T element
//			)
//			{
//				Slot[] slots;
//				Int32 relatedElement;

//				if
//				(
//					address < 0x0 ||
//					address >= _subset._usedSlotCount ||
//					(relatedElement = (slots = _subset._slots)[address]._hashCode) == -0x1
//				)
//				{
//					element = default;
//					return false;
//				}
//				T elementBuffer = slots[address]._element;
//				Int32[] buckets;
//				Int32 bucket = relatedElement % (buckets = _subset._bucketStartIndices).Length;
//				Int32 last = -0x1;
//				for (Int32 slotIndex = buckets[bucket] - 0x1; ; last = slotIndex, slotIndex = slots[slotIndex]._nextSlotIndex)
//				{
//					if (elementBuffer == null ? slots[slotIndex]._element != null : !elementBuffer.Compare(slots[slotIndex]._element))
//						continue;
//					if (last == -0x1)
//						buckets[bucket] = slots[slotIndex]._nextSlotIndex + 0x1;
//					else
//						slots[last]._nextSlotIndex = slots[slotIndex]._nextSlotIndex;
//					slots[slotIndex]._hashCode = -0x1;
//					slots[slotIndex]._nextSlotIndex = _subset._freeSlotIndex;
//					slots[slotIndex]._element = default;
//					_subset._freeSlotIndex = slotIndex;
//					_subset._count--;
//					element = elementBuffer;
//					return true;
//				}
//			}
//			/// <summary>
//			/// Removes an element from the <see cref="ISubset{T}"/>, causes the <see cref="RemoveEvent"/> on the <see cref="ISubset{T}"/> if the <see cref="ISubset{T}"/> contains the element.
//			/// </summary>
//			/// <param name="element">The element.</param>
//			/// <param name="address">The address of <paramref name="element"/> in the <see cref="ISubset{T}"/> if <paramref name="element"/> is removed from the <see cref="ISubset{T}"/>; otherwise, the default value.</param>
//			/// <returns><see langword="true"/> whether <paramref name="element"/> is removed from the <see cref="ISubset{T}"/>; otherwise, <see langword="false"/>.</returns>
//			public Boolean TryRemove
//			(
//				T element,
//				out Integer address
//			)
//			{

//			}
//			/// <summary>
//			/// Adds an element to the <see cref="ISubset{T}"/>, causes the <see cref="AddEvent"/> on the <see cref="ISubset{T}"/> if the <see cref="ISubset{T}"/> does not contain the element.
//			/// </summary>
//			/// <param name="element">The element.</param>
//			/// <param name="address">The address of <paramref name="element"/> in the <see cref="ISubset{T}"/> if <paramref name="element"/> is added to the <see cref="ISubset{T}"/>; otherwise, the default value.</param>
//			/// <returns><see langword="true"/> whether <paramref name="element"/> is added to the <see cref="ISubset{T}"/>; otherwise, <see langword="false"/>.</returns>
//			/// <exception cref="TryAddMethodExceptions.OverflowedException"/>
//			public Boolean TryAdd
//			(
//				T element,
//				out Integer address
//			)
//			{

//			}
//		}

//		private const Int32 _defaultCapacity = 0x4;

//		private Slot[] _slots;
//		private Int32[] _bucketStartIndices;
//		private Int32 _freeSlotIndex;
//		private Int32 _usedSlotCount;
//		private Int32 _count;

//		/// <summary>
//		/// Initializes the <see cref="RandomAccessSubset{T}"/>.
//		/// </summary>
//		/// <param name="capacity">The minimum number of elements of the <see cref="RandomAccessSubset{T}"/>.</param>
//		/// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
//		public RandomAccessSubset(Int32 capacity)
//		{
//			if (capacity < 0x0)
//				throw new ArgumentOutOfRangeException(nameof(capacity));
//			_slots = new Slot[capacity];
//			_bucketStartIndices = new Int32[capacity];
//			_freeSlotIndex = -0x1;
//		}
//		/// <summary>
//		/// Initializes the <see cref="RandomAccessSubset{T}"/>.
//		/// </summary>
//		public RandomAccessSubset() : this(_defaultCapacity) { }

//		/// <summary>
//		/// Gets the number of elements of the <see cref="RandomAccessSubset{T}"/>.
//		/// </summary>
//		public Int32 Count => _count;
//		/// <summary>
//		/// Gets an element at an address in the <see cref="RandomAccessSubset{T}"/>.
//		/// </summary>
//		/// <param name="address">The address.</param>
//		/// <exception cref="ArgumentException">The <see cref="RandomAccessSubset{T}"/> does not contain the element.</exception>
//		public T this[Int32 address]
//		{
//			get
//			{
//				if (!TryGetAt(address, out T element))
//					throw new ArgumentException(SubsetHelper.GetSubsetDoesNotContainElementExceptionMessage(this));
//				return element;
//			}
//		}

//		/// <summary>
//		/// Occurs when all elements are removed from the <see cref="Subset{T}"/>.
//		/// </summary>
//		public event ISubset<T>.ClearEventResponder ClearEvent;
//		/// <summary>
//		/// Occurs when an element is removed from the <see cref="Subset{T}"/>.
//		/// </summary>
//		public event ISubset<T>.RemoveEventResponder RemoveEvent;
//		/// <summary>
//		/// Occurs when an element is added to the <see cref="Subset{T}"/>.
//		/// </summary>
//		public event ISubset<T>.AddEventResponder AddEvent;

//		private Boolean TryAdd(T element, out Int32 address)
//		{
//			void increaseCapacity(Int32 capacity)
//			{
//				Int32 previousCapacity;
//				Slot[] newSlots;
//				if ((previousCapacity = capacity) == Int32.MaxValue)
//					throw new ISubset<T>.IEditor.TryAddMethodExceptions.OverflowedException();
//				if ((capacity <<= 0x1) < 0x0)
//					capacity = Int32.MaxValue;
//				Array.Copy(_slots, newSlots = new Slot[capacity], previousCapacity);
//				Int32[] newBuckets = new Int32[capacity];
//				for (Int32 slotIndex = 0x0; slotIndex != previousCapacity; slotIndex++)
//				{
//					Int32 bucket = _slots[slotIndex]._hashCode % capacity;
//					newSlots[slotIndex]._nextSlotIndex = newBuckets[bucket] - 0x1;
//					newBuckets[bucket] = slotIndex + 0x1;
//				}
//				_slots = newSlots;
//				_bucketStartIndices = newBuckets;
//			}
//			Slot[] slots;
//			Int32 count;
//			Int32 capacity;
//			if ((count = _count) == (capacity = (slots = _slots).Length))
//			{
//				increaseCapacity(capacity);
//				capacity = (slots = _slots).Length;
//			}
//			Int32 hashCode;
//			Int32 bucket = (hashCode = element.get) % capacity;
//			Int32[] buckets;
//			Int32 slotIndex;
//			for (slotIndex = (buckets = _bucketStartIndices)[bucket] - 0x1; slotIndex != -0x1; slotIndex = slots[slotIndex]._nextSlotIndex)
//			{
//				if (element == null ? slots[slotIndex]._element != null : !element.Compare(slots[slotIndex]._element))
//					continue;
//				address = slotIndex;
//				return false;
//			}
//			Int32 freeIndex;
//			if ((freeIndex = _freeSlotIndex) != -0x1)
//				_freeSlotIndex = _slots[slotIndex = freeIndex]._nextSlotIndex;
//			else
//				slotIndex = _usedSlotCount++;
//			slots[slotIndex]._hashCode = hashCode;
//			slots[slotIndex]._nextSlotIndex = buckets[bucket] - 0x1;
//			slots[slotIndex]._element = element;
//			buckets[bucket] = slotIndex + 0x1;
//			_count = count + 0x1;
//			address = slotIndex;
//			return true;
//		}
//		private Int32 Add(T element)
//		{
//			if (!TryAdd(element, out Int32 address))
//				throw new ArgumentException(SubsetHelper.GetSubsetAlreadyContainsElementExceptionMessage(this, nameof(element)));
//			return address;
//		}
//		private Boolean TryRemove(T element)
//		{
//			Int32[] buckets;
//			Int32 bucket = element.RelatedElement % (buckets = _bucketStartIndices).Length;
//			Slot[] slots = _slots;
//			Int32 last = -0x1;
//			for (Int32 slotIndex = buckets[bucket] - 0x1; slotIndex != -0x1; last = slotIndex, slotIndex = slots[slotIndex]._nextSlotIndex)
//			{
//				if (element == null ? slots[slotIndex]._element != null : !element.Compare(slots[slotIndex]._element))
//					continue;
//				if (last == -0x1)
//					buckets[bucket] = slots[slotIndex]._nextSlotIndex + 0x1;
//				else
//					slots[last]._nextSlotIndex = slots[slotIndex]._nextSlotIndex;
//				slots[slotIndex]._hashCode = -0x1;
//				slots[slotIndex]._nextSlotIndex = _freeSlotIndex;
//				slots[slotIndex]._element = default;
//				_freeSlotIndex = slotIndex;
//				_count--;
//				return true;
//			}
//			return false;
//		}
//		private void Remove(T element)
//		{
//			if (!TryRemove(element))
//				throw new ArgumentException(SubsetHelper.GetSubsetDoesNotContainElementExceptionMessage(this, nameof(element)));
//		}
//		private Boolean TryRemoveAt(Int32 address, out T element)
//		{
//			Slot[] slots;
//			Int32 relatedElement;
//			if (address < 0x0 || address >= _usedSlotCount || (relatedElement = (slots = _slots)[address]._hashCode) == -0x1)
//			{
//				element = default;
//				return false;
//			}
//			T elementBuffer = slots[address]._element;
//			Int32[] buckets;
//			Int32 bucket = relatedElement % (buckets = _bucketStartIndices).Length;
//			Int32 last = -0x1;
//			for (Int32 slotIndex = buckets[bucket] - 0x1; ; last = slotIndex, slotIndex = slots[slotIndex]._nextSlotIndex)
//			{
//				if (elementBuffer == null ? slots[slotIndex]._element != null : !elementBuffer.Compare(slots[slotIndex]._element))
//					continue;
//				if (last == -0x1)
//					buckets[bucket] = slots[slotIndex]._nextSlotIndex + 0x1;
//				else
//					slots[last]._nextSlotIndex = slots[slotIndex]._nextSlotIndex;
//				slots[slotIndex]._hashCode = -0x1;
//				slots[slotIndex]._nextSlotIndex = _freeSlotIndex;
//				slots[slotIndex]._element = default;
//				_freeSlotIndex = slotIndex;
//				_count--;
//				element = elementBuffer;
//				return true;
//			}
//		}
//		private T RemoveAt(Int32 address)
//		{
//			if (!TryRemoveAt(address, out T element))
//				throw new ArgumentException(SubsetHelper.GetSubsetDoesNotContainElementExceptionMessage(this));
//			return element;
//		}
//		/// <summary>
//		/// Gets an <see cref="Enumerator"/> of the <see cref="RandomAccessSubset{T}"/>.
//		/// </summary>
//		/// <returns>An <see cref="Enumerator"/> of the <see cref="RandomAccessSubset{T}"/>.</returns>
//		public Enumerator GetEnumerator() => new Enumerator(this);
//		/// <summary>
//		/// Handles elements of the <see cref="RandomAccessSubset{T}"/> with an <see cref="ElementHandler{T}"/>.
//		/// </summary>
//		/// <param name="handler">The handler of the elements.</param>
//		/// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
//		public void Handle(ElementHandler<T> handler)
//		{
//			if (handler == null)
//				throw new ArgumentNullException(nameof(handler));
//			Slot[] slots = _slots;
//			Int32 usedSlotCount = _usedSlotCount;
//			for (Int32 slotIndex = 0x0; slotIndex != usedSlotCount; slotIndex++)
//				if (slots[slotIndex]._hashCode != -0x1 && handler(slots[slotIndex]._element))
//					return;
//		}
//		/// <summary>
//		/// Determines whether the <see cref="RandomAccessSubset{T}"/> contains an element.
//		/// </summary>
//		/// <param name="element">The element.</param>
//		/// <returns><see langword="true"/> whether the <see cref="RandomAccessSubset{T}"/> contains <paramref name="element"/>; otherwise, <see langword="false"/>.</returns>
//		public Boolean Contains(T element) => TryGetAddress(element, out _);
//		/// <summary>
//		/// Determines whether the <see cref="RandomAccessSubset{T}"/> contains an element.
//		/// </summary>
//		/// <param name="element">The element.</param>
//		/// <param name="address">The address of <paramref name="element"/> if the <see cref="RandomAccessSubset{T}"/> contains <paramref name="element"/>; otherwise, the default value.</param>
//		/// <returns><see langword="true"/> whether the <see cref="RandomAccessSubset{T}"/> contains <paramref name="element"/>; otherwise, <see langword="false"/>.</returns>
//		public Boolean TryGetAddress(T element, out Int32 address)
//		{
//			Int32 relatedElement = element.RelatedElement;
//			Slot[] slots = _slots;
//			for (Int32 slotIndex = _bucketStartIndices[relatedElement % slots.Length] - 0x1; slotIndex != -0x1; slotIndex = slots[slotIndex]._nextSlotIndex)
//			{
//				if (element == null ? slots[slotIndex]._element != null : !element.Compare(slots[slotIndex]._element))
//					continue;
//				address = slotIndex;
//				return true;
//			}
//			address = default;
//			return false;
//		}
//		/// <summary>
//		/// Determines whether the <see cref="RandomAccessSubset{T}"/> contains an element.
//		/// </summary>
//		/// <param name="element">The element.</param>
//		/// <returns>The address of the element.</returns>
//		/// <exception cref="ArgumentException">The <see cref="RandomAccessSubset{T}"/> does not contain <paramref name="element"/>.</exception>
//		public Int32 GetAddress(T element)
//		{
//			if (!TryGetAddress(element, out Int32 address))
//				throw new ArgumentException(SubsetHelper.GetSubsetDoesNotContainElementExceptionMessage(this, nameof(element)));
//			return address;
//		}
//		/// <summary>
//		/// Determines whether the <see cref="RandomAccessSubset{T}"/> contains an element at an address.
//		/// </summary>
//		/// <param name="address">The address.</param>
//		/// <returns><see langword="true"/> whether the <see cref="RandomAccessSubset{T}"/> contains the element; otherwise, <see langword="false"/>.</returns>
//		public Boolean ContainsAt(Int32 address) => address >= 0x0 && address < _usedSlotCount && _slots[address]._hashCode != -0x1;
//		/// <summary>
//		/// Determines whether the <see cref="RandomAccessSubset{T}"/> contains an element at an address.
//		/// </summary>
//		/// <param name="address">The address.</param>
//		/// <param name="element">The element if the <see cref="RandomAccessSubset{T}"/> contains; otherwise, the default value.</param>
//		/// <returns><see langword="true"/> whether the <see cref="RandomAccessSubset{T}"/> contains the element; otherwise, <see langword="false"/>.</returns>
//		public Boolean TryGetAt(Int32 address, out T element)
//		{
//			Slot[] slots;
//			if (address < 0x0 || address >= _usedSlotCount || (slots = _slots)[address]._hashCode == -0x1)
//			{
//				element = default;
//				return false;
//			}
//			element = slots[address]._element;
//			return true;
//		}
//		IEnumerator<T> ISequence<T>.GetEnumerator() => GetEnumerator();
//	}
//}