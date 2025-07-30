using System;
using _Project.Scripts.Core.Models;
using _Project.Scripts.Data;
using Zenject;

namespace _Project.Scripts.Core.Presenters
{
    public class EndPresenter : IInitializable, IDisposable
    {
        private readonly EndView _view;
        private readonly SceneManagementService _sceneManagementService;
        private readonly SceneNumbersConfig _sceneNumbersConfig;
        private readonly ScoreModel _scoreModel;

        public EndPresenter(EndView view,
            SceneManagementService sceneManagementService,
            SceneNumbersConfig sceneNumbersConfig,
            ScoreModel scoreModel)
        {
            _view = view;
            _sceneManagementService = sceneManagementService;
            _sceneNumbersConfig = sceneNumbersConfig;
            _scoreModel = scoreModel;
        }

        public void Initialize()
        {
            _view.ButtonMenu.onClick.AddListener(LoadStartScene);
            _view.ButtonReplay.onClick.AddListener(LoadPlayScene);
            ChangeScoreText();
        }

        public void Dispose()
        {
            _view.ButtonMenu.onClick.RemoveListener(LoadStartScene);
            _view.ButtonReplay.onClick.RemoveListener(LoadPlayScene);
        }

        private void ChangeScoreText()
        {
            _view.TextScore.text = $"Очки: {_scoreModel.Score}";
        }

        private void LoadStartScene()
        {
            _sceneManagementService.LoadScene(_sceneNumbersConfig.StartScene);
            _scoreModel.ClearScore();
        }

        private void LoadPlayScene()
        {
            _sceneManagementService.LoadScene(_sceneNumbersConfig.PlayScene);
            _scoreModel.ClearScore();
        }
    }
}