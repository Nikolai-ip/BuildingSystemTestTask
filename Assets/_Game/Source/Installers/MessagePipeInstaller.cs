using _Game.Source.DI;
using MessagePipe;
using VContainer;

namespace _Game.Source.Installers
{
    public class MessagePipeInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
        }
    }
}