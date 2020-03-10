using System.Collections.Generic;

namespace leckerito.Framework.Composition.ViewModelComposing
{
    public interface IViewModelAppenderProvider
    {
        IEnumerable<IViewModelAppender> AppendersFor<T>();
    }
}