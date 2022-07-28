using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace Technia.Infrastructure.Configuration
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(filePath => Path.GetFileName(filePath).StartsWith("Technia") && !Path.GetFileName(filePath).Contains("Configuration"))
                .Select(Assembly.LoadFrom).ToArray();

            builder.RegisterAssemblyTypes(assemblies)
                .AsImplementedInterfaces();
        }
    }
}