using System;
using _Project.Scripts.Data;
using UnityEngine;

namespace _Project.Scripts.Core.Models
{
    public class CirclesModel
    {
        public event Action OnGameEnd;
        
        private GameCircle[,] _circles = new GameCircle[3,3];

        private readonly ScoreModel _scoreModel;
        private readonly ScoreConfig _scoreConfig;

        public CirclesModel(ScoreModel scoreModel, 
            ScoreConfig scoreConfig)
        {
            _scoreModel = scoreModel;
            _scoreConfig = scoreConfig;
        }

        public void AddCircle(GameCircle touchedCircle,  GameCircle addCircle)
        {
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    if (_circles[x, y] == touchedCircle)
                    {
                        _circles[x, y + 1] = addCircle;
                        CheckCircles();
                        return;
                    }
                }
            }
            
            Debug.Log("Circle doesn't exist or y is maximum");
        }
        
        public void AddCircle(int indexX, GameCircle circle)
        {
            _circles[indexX, 0] = circle; 
        }
        
        private void CheckCircles()
        {
            for (int i = 0; i < 3; i++)
            {
                CheckLine(_circles[i, 0], _circles[i, 1], _circles[i, 2]);
                CheckLine(_circles[0, i], _circles[1, i], _circles[2, i]);
            }
            
            CheckLine(_circles[0, 0], _circles[1, 1], _circles[2, 2]);
            CheckLine(_circles[0, 2], _circles[1, 1], _circles[2, 0]);
            
            if (_circles[0, 2] != null && _circles[1, 2] != null && _circles[2, 2] != null)
            {
                OnGameEnd?.Invoke();
            }
        }

        private void CheckLine(GameCircle a, GameCircle b, GameCircle c)
        {
            if (a == b && b == c)
            {
                a.DestroyIt();
                b.DestroyIt();
                c.DestroyIt();
                _scoreModel.AddScore(_scoreConfig.Score);
            }
        }
    }
}