using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(fileName = "SceneNumbersConfig", menuName = "SceneNumbersConfig", order = 0)]
    public class SceneNumbersConfig : ScriptableObject
    {
        [field: SerializeField] public int StartScene { get; private set; }
        [field: SerializeField] public int PlayScene { get; private set; }
        [field: SerializeField] public int EndScene { get; private set; }
    }
}