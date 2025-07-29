namespace _Project.Scripts.Core.Models
{
    public class ScoreModel
    {
        public int Score { get; private set; }

        public void AddScore(int score)
        {
            Score += score;
        }
    }
}