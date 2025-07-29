using System;
using _Project.Scripts.Core.Models;
using _Project.Scripts.Data;
using Zenject;

namespace _Project.Scripts.Core.Controllers
{
    public class EndGameController : IInitializable, IDisposable
    {
        private readonly CirclesModel _circlesModel;
        private readonly SceneManagementService _sceneManagementService;
        private readonly SceneNumbersConfig _sceneNumbersConfig;

        public EndGameController(CirclesModel circlesModel, 
            SceneManagementService sceneManagementService, 
            SceneNumbersConfig sceneNumbersConfig)
        {
            _circlesModel = circlesModel;
            _sceneManagementService = sceneManagementService;
            _sceneNumbersConfig = sceneNumbersConfig;
        }

        public void Initialize()
        {
            _circlesModel.OnGameEnd += EndingGame;
        }

        public void Dispose()
        {
            _circlesModel.OnGameEnd -= EndingGame;
        }

        private void EndingGame()
        {
            _sceneManagementService.LoadScene(_sceneNumbersConfig.EndScene);
        }
    }
}