using System;
using System.Threading.Tasks;
using NServiceBus;

namespace leckerito.Framework.Composition.Commands
{
    public abstract class CommandAttacherBase<T> : ICommandAttacher<T>
    {
        public abstract Task AttachTo(T viewModel, IMessageSession endpoint);

        public Task AttachTo(dynamic viewModel, IMessageSession endpoint)
        {
            return AttachTo((T)viewModel, endpoint);
        }

        public bool WillAttachTo(Type typeOfViewModel)
        {
            return typeof(T).IsAssignableFrom(typeOfViewModel);
        }
    }
}