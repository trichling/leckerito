using System.Collections.Generic;

namespace leckerito.Framework.Composition.CommandExecution
{
    public interface ICommandAttacherProvider
    {
        IEnumerable<ICommandAttacher> AttachersFor<T>();
         
    }
}