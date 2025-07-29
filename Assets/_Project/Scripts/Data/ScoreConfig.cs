using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(fileName = "ScoreConfig", menuName = "ScoreConfig", order = 0)]
    public class ScoreConfig : ScriptableObject
    {
        [field: SerializeField] public int Score { get; private set; }
    }
}