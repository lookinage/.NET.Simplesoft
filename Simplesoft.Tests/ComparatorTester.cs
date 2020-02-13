using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Simplesoft.Tests
{
	[TestClass]
	public class ComparatorTester
	{
		public struct MyStruct
		{
			public uint B;
		}

		private const int _testCount = 0x10000000;

		static public uint Value1;
		static public uint Value2;
		static public bool Result;

		[TestMethod]
		public unsafe void Test1()
		{
			Comparator<uint> comparator = Comparator<uint>.Instance;
			for (int testIndex = 0x0; testIndex != _testCount; testIndex++)
				Result = comparator.Compare(Value1, Value2);
		}
		[TestMethod]
		public unsafe void Test2()
		{
			for (int testIndex = 0x0; testIndex != _testCount; testIndex++)
				Result = Value1 == Value2;
		}
	}
}