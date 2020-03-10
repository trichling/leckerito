using System;
using System.Threading.Tasks;
using NServiceBus;

namespace leckerito.Framework.Composition.CommandExecution
{
    public interface ICommandAttacher
    {
         
        bool WillAttachTo(Type typeOfViewModel);
        Task AttachTo(dynamic viewModel, IMessageSession endpoint);

    }

    public interface ICommandAttacher<TViewModel> : ICommandAttacher
    {
         
        Task AttachTo(TViewModel viewModel, IMessageSession endpoint);

    }
}