using _Project.Scripts.Core.Controllers;
using _Project.Scripts.Core.Models;
using _Project.Scripts.Data;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private CirclesConfig _circlesConfig;
    [SerializeField] private ParticleConfig _particleConfig;
    [SerializeField] private PendulumConfig _pendulumConfig;
    [SerializeField] private SceneNumbersConfig _sceneNumbersConfig;
    [SerializeField] private ScoreConfig _scoreConfig;
    
    public override void InstallBindings()
    {
        Container.Bind<CirclesConfig>().FromInstance(_circlesConfig).AsSingle();
        Container.Bind<ParticleConfig>().FromInstance(_particleConfig).AsSingle();
        Container.Bind<PendulumConfig>().FromInstance(_pendulumConfig).AsSingle();
        Container.Bind<SceneNumbersConfig>().FromInstance(_sceneNumbersConfig).AsSingle();
        Container.Bind<ScoreConfig>().FromInstance(_scoreConfig).AsSingle();
        
        Container.Bind<ScoreModel>().AsSingle();
        Container.Bind<CirclesModel>().AsSingle();
        
        Container.Bind<SceneManagementService>().AsSingle();
        
        Container.BindInterfacesAndSelfTo<EndGameController>().AsSingle();
        Container.BindInterfacesAndSelfTo<ParticleController>().AsSingle().WithArguments(gameObject.transform);
    }
}