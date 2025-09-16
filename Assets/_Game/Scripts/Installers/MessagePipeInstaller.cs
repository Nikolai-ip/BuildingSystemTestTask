using _Game.Scripts.DI;
using MessagePipe;
using VContainer;

namespace _Game.Scripts.Installers
{
    public class MessagePipeInstaller: IInstallerMono
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
        }
    }
}