using System.Collections.Generic;

namespace leckerito.Framework.Composition.ViewModels
{
    public interface IViewModelAppenderProvider
    {
        IEnumerable<IViewModelAppender<T>> AppendersFor<T>();
    }
}