using _Game.Source.Application.Utilities.Input;
using _Game.Source.DI;
using UnityEngine;
using VContainer;

namespace _Game.Source.Installers.InputInstallers
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