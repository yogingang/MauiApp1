using System.Reflection;
using System.Runtime.Loader;

namespace MauiApp1.Helper;
public class AssemblyHelper
{
    public static List<Assembly> GetAllAssemblies
        (SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var assemblyFiles = Directory.GetFiles(baseDirectory
        , "*.dll"
        , searchOption);

        var path = Directory.GetFiles(baseDirectory);
        foreach (string assemblyPath in assemblyFiles)
        {
            try
            {
                var assembly = AssemblyLoadContext
                .Default
                .LoadFromAssemblyPath(assemblyPath);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex.ToString());
            }
        }
        // return assemblies;
        return AssemblyLoadContext.Default.Assemblies.ToList();
    }

}