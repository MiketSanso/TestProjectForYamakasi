using System;
using _Project.Scripts.Data;
using Zenject;

namespace _Project.Scripts.Core.Presenters
{
    public class StartPresenter : IInitializable, IDisposable
    {
        private readonly StartView _view;
        private readonly SceneManagementService _sceneManagementService;
        private readonly SceneNumbersConfig _sceneNumbersConfig;

        public StartPresenter(StartView view,
            SceneManagementService sceneManagementService,
            SceneNumbersConfig sceneNumbersConfig)
        {
            _view = view;
            _sceneManagementService = sceneManagementService;
            _sceneNumbersConfig = sceneNumbersConfig;
        }

        public void Initialize()
        {
            _view.ButtonPlay.onClick.AddListener(LoadPlayScene);
        }

        public void Dispose()
        {
            _view.ButtonPlay.onClick.RemoveListener(LoadPlayScene);
        }

        private void LoadPlayScene()
        {
            _sceneManagementService.LoadScene(_sceneNumbersConfig.PlayScene);
        }
    }
}