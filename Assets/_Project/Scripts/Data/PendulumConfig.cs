using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(fileName = "PendulumConfig", menuName = "PendulumConfig", order = 0)]
    public class PendulumConfig : ScriptableObject
    {
        [field: SerializeField] public float SwingAngle { get; private set; }
        [field: SerializeField] public float SwingSpeed  { get; private set; }
        [field: SerializeField] public float RopeLength { get; private set; }
        [field: SerializeField] public float BallRespawnDelay  { get; private set; }
    }
}