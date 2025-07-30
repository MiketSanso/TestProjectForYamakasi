using _Project.Scripts.Core.Presenters;
using UnityEngine;
using Zenject;

public class EndInstaller : MonoInstaller
{
    [SerializeField] private EndView _endView;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EndPresenter>().AsSingle().WithArguments(_endView);
    }
}