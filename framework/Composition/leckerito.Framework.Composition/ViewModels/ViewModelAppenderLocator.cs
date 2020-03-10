using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace leckerito.Framework.Composition.ViewModels
{

    public class ViewModelAppenderLocator : IViewModelAppenderProvider
    {

        public IEnumerable<IViewModelAppender> Appenders { get; set; }

        public IEnumerable<IViewModelAppender<T>> AppendersFor<T>()
        {
            return Appenders.Where(a => a.WillAppendTo(typeof(T)))
                .Cast<IViewModelAppender<T>>();
        }

        public void DiscoverFromCurrentAppDomainBaseDirectory()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            DiscoverFromDirectory(directory);
        }

        public void DiscoverFromDirectory(string directory)
        {
            var assemblies = Directory.GetFiles(directory, "*.dll")
                    .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);

            DiscoverFromAsseblies(assemblies);
        }

        public void DiscoverFromAllLoadedAssemblies()
        {
            var referncedAssemblies = Assembly.GetEntryAssembly()
                    .GetReferencedAssemblies()
                    .Select(AssemblyLoadContext.Default.LoadFromAssemblyName)
                    .ToList();

            var assemblies = new List<Assembly>(referncedAssemblies);
            assemblies.Add(Assembly.GetEntryAssembly());
            assemblies.Add(Assembly.GetCallingAssembly());
            assemblies.Add(Assembly.GetExecutingAssembly());

            DiscoverFromAsseblies(assemblies);
        }

        public void DiscoverFromAsseblies(IEnumerable<Assembly> assemblies)
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