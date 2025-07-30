using System;
using _Project.Scripts.Data;
using UnityEngine;

namespace _Project.Scripts.Core.Models
{
    public class CirclesModel
    {
        public event Action OnGameEnd;
        
        private GameCircle[,] _circles = new GameCircle[3, 3];
        private bool _isChecking;

        private readonly ScoreModel _scoreModel;
        private readonly ScoreConfig _scoreConfig;

        public CirclesModel(ScoreModel scoreModel, ScoreConfig scoreConfig)
        {
            _scoreModel = scoreModel;
            _scoreConfig = scoreConfig;
        }

        public void AddCircle(GameCircle touchedCircle, GameCircle addCircle)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    if (_circles[x, y] == touchedCircle)
                    {
                        if (_circles[x, y + 1] == null)
                        {
                            _circles[x, y + 1] = addCircle;
                            
                            if (!_isChecking)
                            {
                                _isChecking = true;
                                CheckCircles();
                                _isChecking = false;
                            }
                        }
                    }
                }
            }
        }

        public void AddCircle(int indexX, GameCircle circle)
        {
            _circles[indexX, 0] = circle;
            Debug.Log(circle + " " + _circles[indexX, 1]);
        }

        private void CheckCircles()
        {
            bool matchFound = false;
            
            for (int y = 0; y < 3; y++)
            {
                if (CheckLine(0, y, 1, y, 2, y))
                    matchFound = true;
            }
            
            for (int x = 0; x < 3; x++)
            {
                if (CheckLine(x, 0, x, 1, x, 2))
                    matchFound = true;
            }
            
            if (CheckLine(0, 0, 1, 1, 2, 2)) 
                matchFound = true;
            
            if (CheckLine(0, 2, 1, 1, 2, 0))
                matchFound = true;
            
            if (matchFound)
            {
                CheckCircles();
            }
            else
            {
                CheckGameEnd();
            }
        }

        private bool CheckLine(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            GameCircle a = GetValidCircle(x1, y1);
            GameCircle b = GetValidCircle(x2, y2);
            GameCircle c = GetValidCircle(x3, y3);


            if (a == null || b == null || c == null)
                return false;

            if (a.ID == b.ID && b.ID == c.ID)
            {
                RemoveCircle(x1, y1);
                RemoveCircle(x2, y2);
                RemoveCircle(x3, y3);
                
                _scoreModel.AddScore(_scoreConfig.Score);
                return true;
            }
            return false;
        }

        private GameCircle GetValidCircle(int x, int y)
        {
            if (x < 0 || x >= 3 || y < 0 || y >= 3)
                return null;

            GameCircle circle = _circles[x, y];
            return circle != null && circle.gameObject.activeSelf ? circle : null;
        }

        private void RemoveCircle(int x, int y)
        {
            if (x < 0 || x >= 3 || y < 0 || y >= 3)
                return;

            if (_circles[x, y] != null)
            {
                _circles[x, y].DestroyIt();
                _circles[x, y] = null;
            }
        }

        private void CheckGameEnd()
        {
            if (_circles[0, 2] != null && _circles[1, 2] != null && _circles[2, 2] != null)
            {
                OnGameEnd?.Invoke();
            }
        }
    }
}