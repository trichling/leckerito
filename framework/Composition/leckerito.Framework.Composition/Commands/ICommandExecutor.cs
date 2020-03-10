using System.Threading.Tasks;
using NServiceBus;

namespace leckerito.Framework.Composition.Commands
{
    public interface ICommandExecutor
    {
        Task ExecuteCommandsFor<TViewModel>(TViewModel viewModel, IMessageSession endpoint);
    }
}