using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace leckerito.Framework.Composition.ViewModelComposing
{

    public class ViewModelAppenderLocator : IViewModelAppenderProvider
    {

        public IEnumerable<IViewModelAppender> Appenders { get; set; }

        public IEnumerable<IViewModelAppender> AppendersFor<T>()
        {
            return Appenders.Where(a => a.WillAppendTo(typeof(T)))
                .Cast<IViewModelAppender<T>>();
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
                    .Where(t => typeof(IViewModelAppender).IsAssignableFrom(t))
                    .Select(t => t.AsType());

            Appenders = viewModelAppender
                            .Select(Activator.CreateInstance)
                            .Cast<IViewModelAppender>()
                            .ToList();
        }

       
    }
}