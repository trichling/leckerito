using System.Threading.Tasks;

namespace leckerito.Framework.Composition.Commands
{
    public interface ICommandAttacher
    {
         
        Task AttachTo<TViewModel>(TViewModel viewModel)

    }
}