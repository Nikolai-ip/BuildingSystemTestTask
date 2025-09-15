using _Game.Scripts.DI;
using UnityEngine;
using VContainer;

namespace _Game.Scripts.Application.Utilities.Input.Installers
{
    public class GridVectorConverterInstaller: IInstallerMono
    {
        [SerializeField] private Grid _grid;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<GridVectorConverter>(Lifetime.Singleton).WithParameter(_grid);
        }
    }
}