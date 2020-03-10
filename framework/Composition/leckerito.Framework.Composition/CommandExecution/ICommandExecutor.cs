using System.Threading.Tasks;
using NServiceBus;

namespace leckerito.Framework.Composition.CommandExecution
{
    public interface ICommandExecutor
    {
        Task ExecuteCommandsFor<TViewModel>(TViewModel viewModel, IMessageSession endpoint);
    }
}