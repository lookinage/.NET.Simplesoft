using System.Reflection;
using System.Reflection.Emit;

namespace Simplesoft
{
	static internal class Dynamic
	{
		static internal readonly ModuleBuilder _moduleBuilder;

		static Dynamic()
		{
			AssemblyName assemblyName;
			AssemblyBuilder assemblyBuilder;

			assemblyName = new AssemblyName(nameof(Simplesoft) + "." + nameof(Dynamic));
			assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly
			(
				assemblyName,
				AssemblyBuilderAccess.Run
			);
			_moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyBuilder.FullName);
		}
	}
}