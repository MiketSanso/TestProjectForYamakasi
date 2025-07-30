using _Project.Scripts.Core.Presenters;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private StartView _startView;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<StartPresenter>().AsSingle().WithArguments(_startView);
    }
}