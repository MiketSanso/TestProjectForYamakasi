using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(fileName = "CirclesConfig", menuName = "CirclesConfig", order = 0)]
    public class CirclesConfig : ScriptableObject
    {
        [field: SerializeField] public GameCircle[] Circles { get; private set; }
    }
}