using System.Reflection;
using System.Reflection.Emit;

namespace Simplesoft.Sets
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
}