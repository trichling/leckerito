using System.Collections.Generic;

namespace leckerito.Framework.Composition.Commands
{
    public interface ICommandAttacherProvider
    {
        IEnumerable<ICommandAttacher> AttachersFor<T>();
         
    }
}