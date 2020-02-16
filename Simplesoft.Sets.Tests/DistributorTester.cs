using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Simplesoft.Sets.Tests
{
	static internal class Dynamic
	{
		static internal readonly ModuleBuilder _moduleBuilder;

		static Dynamic()
		{
			AssemblyName assemblyName = new AssemblyName(nameof(Simplesoft) + "." + nameof(Sets) + "." + nameof(Dynamic));
			AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
			_moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyBuilder.FullName);
		}
	}
	/// <summary>
	/// Represents a distributor of elements of a set.
	/// </summary>
	/// <typeparam name="T">The type of the elements.</typeparam>
	public abstract class Distributor<T>
	{
		static private readonly Distributor<T> _instance;

		static Distributor()
		{
			Type type;
			Type pointerType;
			Type distributorType;
			TypeBuilder typeBuilder;
			ConstructorBuilder constructorBuilder;
			ILGenerator generator;
			MethodBuilder methodBuilder;

			static Boolean isManagedType(Type type)
			{
				FieldInfo[] fields;

				if (type.IsPrimitive)
					return false;
				if (!type.IsValueType)
					return true;
				fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
				foreach (FieldInfo field in fields)
					if (isManagedType(field.FieldType))
						return true;
				return false;
			}

			type = typeof(T);
			if (type.IsValueType && isManagedType(type))
				return;
			pointerType = type.MakePointerType();
			distributorType = typeof(Distributor<T>);
			typeBuilder = Dynamic._moduleBuilder.DefineType(type.FullName + distributorType.Name, TypeAttributes.Sealed | TypeAttributes.NotPublic, distributorType);
			constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
			generator = constructorBuilder.GetILGenerator();
			generator.Emit(OpCodes.Ldarg_0);
			generator.Emit(OpCodes.Call, distributorType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null));
			generator.Emit(OpCodes.Ret);
			methodBuilder = typeBuilder.DefineMethod(nameof(GetClusterIndex), MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.Final, CallingConventions.Standard, typeof(Int64), new Type[] { type });
			generator = methodBuilder.GetILGenerator();
			if (type.IsValueType)
			{
				LocalBuilder pointerLocalBuilder;
				Int32 size;
				Int32 offset;
				Boolean accumulating;

				pointerLocalBuilder = generator.DeclareLocal(pointerType);
				generator.Emit(OpCodes.Ldarga, 0x1);
				generator.Emit(OpCodes.Conv_U);
				generator.Emit(OpCodes.Stloc, pointerLocalBuilder.LocalIndex);
				size = Unsafe.SizeOf<T>();
				offset = 0x0;
				accumulating = false;
				for (; size - offset >= sizeof(UInt64); offset += sizeof(UInt64))
				{
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I8);
					if (accumulating)
						generator.Emit(OpCodes.Xor);
					else
						accumulating = true;
				}
				if (size - offset >= sizeof(UInt32))
				{
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I4);
					generator.Emit(OpCodes.Conv_I8);
					if (accumulating)
						generator.Emit(OpCodes.Xor);
					else
						accumulating = true;
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I4);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x20);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					offset += sizeof(UInt32);
				}
				if (size - offset >= sizeof(UInt16))
				{
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I2);
					generator.Emit(OpCodes.Conv_I8);
					if (accumulating)
						generator.Emit(OpCodes.Xor);
					else
						accumulating = true;
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I2);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x10);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I2);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x20);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I2);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x30);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					offset += sizeof(UInt16);
				}
				if (size - offset >= sizeof(Byte))
				{
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I1);
					generator.Emit(OpCodes.Conv_I8);
					if (accumulating)
						generator.Emit(OpCodes.Xor);
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I1);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x8);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I1);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x10);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I1);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x18);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I1);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x20);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I1);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x28);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I1);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x30);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
					generator.Emit(OpCodes.Ldloc, pointerLocalBuilder.LocalIndex);
					generator.Emit(OpCodes.Ldc_I4, offset);
					generator.Emit(OpCodes.Add);
					generator.Emit(OpCodes.Ldind_I1);
					generator.Emit(OpCodes.Conv_I8);
					generator.Emit(OpCodes.Ldc_I4, 0x38);
					generator.Emit(OpCodes.Shl);
					generator.Emit(OpCodes.Xor);
				}
				generator.Emit(OpCodes.Ret);
			}
			else
			{
				Label emitNullHashCode = generator.DefineLabel();
				Type objectType;

				generator.Emit(OpCodes.Ldarg_1);
				generator.Emit(OpCodes.Ldnull);
				generator.Emit(OpCodes.Ceq);
				generator.Emit(OpCodes.Brtrue, emitNullHashCode);
				generator.Emit(OpCodes.Ldarg_1);
				objectType = typeof(Object);
				generator.Emit(OpCodes.Call, objectType.GetMethod(nameof(GetHashCode)));
				generator.Emit(OpCodes.Conv_I8);
				generator.Emit(OpCodes.Dup);
				generator.Emit(OpCodes.Ldc_I4, 0x20);
				generator.Emit(OpCodes.Shl);
				generator.Emit(OpCodes.Or);
				generator.Emit(OpCodes.Ret);
				generator.MarkLabel(emitNullHashCode);
				generator.Emit(OpCodes.Ldc_I8, 0x0L);
				generator.Emit(OpCodes.Ret);
			}
			typeBuilder.DefineMethodOverride(methodBuilder, distributorType.GetMethod(nameof(GetClusterIndex)));
			_instance = (Distributor<T>)Activator.CreateInstance(typeBuilder.CreateType());
		}

		/// <summary>
		/// The default <see cref="Distributor{T}"/> of the set (only for reference types and unmanaged value types).
		/// </summary>
		static public Distributor<T> Instance => _instance;

		/// <summary>
		/// Initializes the <see cref="Distributor{T}"/>.
		/// </summary>
		protected Distributor() { }

		/// <summary>
		/// Gets an index of a cluster of an element of the set.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns>An index of a cluster of <paramref name="element"/>.</returns>
		public abstract Int64 GetClusterIndex(T element);
	}
	[TestClass]
	public class DistributorTester
	{
		public struct MyStruct
		{
			public UInt64 A;
			public UInt64 B;
			public UInt64 C;
			public Byte D;
		}

		[TestMethod]
		public unsafe void TestMethod1()
		{
			Int32 size = sizeof(MyStruct);
			Int32 size2 = Marshal.SizeOf<MyStruct>();
			Distributor<MyStruct> distributor = Distributor<MyStruct>.Instance;
			MyStruct obj = new MyStruct() { D = 0xFF };
			Int64 clusterIndex = distributor.GetClusterIndex(obj);
			Int32 hashCode = (Int32)clusterIndex;
			Int32 hashCode2 = obj.GetHashCode();
		}
	}
}