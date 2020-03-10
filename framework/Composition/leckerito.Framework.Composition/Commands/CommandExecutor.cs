using System.Threading.Tasks;
using NServiceBus;

namespace leckerito.Framework.Composition.Commands
{

    public class CommandExecutor : ICommandExecutor
    {
        private ICommandAttacherProvider provider;

        public CommandExecutor(ICommandAttacherProvider provider)
        {
            this.provider = provider;
        }

        public async Task ExecuteCommandsFor<TViewModel>(TViewModel viewModel, IMessageSession endpoint)
        {
            var commandAttachers = provider.AttachersFor<TViewModel>();
            foreach (var attacher in commandAttachers)
                await attacher.AttachTo(viewModel, endpoint);
        }
    }
}