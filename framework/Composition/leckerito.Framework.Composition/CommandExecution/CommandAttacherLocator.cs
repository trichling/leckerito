using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace leckerito.Framework.Composition.CommandExecution
{
    public class CommandAttacherLocator : ICommandAttacherProvider
    {

        public IEnumerable<ICommandAttacher> Attachers { get; set; }

        public IEnumerable<ICommandAttacher> AttachersFor<T>()
        {
            return Attachers.Where(a => a.WillAttachTo(typeof(T)))
                .Cast<ICommandAttacher<T>>();
        }

        public void Discover()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var assemblies = FromDirectory(directory).Union(FromLoadedAssemblies());

            DiscoverFromAsseblies(assemblies);
        }

        private IEnumerable<Assembly> FromDirectory(string directory)
        {
            var assemblies = Directory.GetFiles(directory, "*.dll")
                    .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);

            return assemblies;
        }

        private IEnumerable<Assembly> FromLoadedAssemblies()
        {
            var referncedAssemblies = Assembly.GetEntryAssembly()
                    .GetReferencedAssemblies()
                    .Select(AssemblyLoadContext.Default.LoadFromAssemblyName)
                    .ToList();

            var assemblies = new List<Assembly>(referncedAssemblies);
            assemblies.Add(Assembly.GetEntryAssembly());
            assemblies.Add(Assembly.GetCallingAssembly());
            assemblies.Add(Assembly.GetExecutingAssembly());

            return assemblies;
        }

        private void DiscoverFromAsseblies(IEnumerable<Assembly> assemblies)
        {
            var viewModelAppender = assemblies.SelectMany(a => a.DefinedTypes)
                    .Where(t => !t.IsAbstract && !t.IsInterface)
                    .Where(t => typeof(ICommandAttacher).IsAssignableFrom(t))
                    .Select(t => t.AsType());

            Attachers = viewModelAppender
                            .Select(Activator.CreateInstance)
                            .Cast<ICommandAttacher>()
                            .ToList();
        }
    }
}